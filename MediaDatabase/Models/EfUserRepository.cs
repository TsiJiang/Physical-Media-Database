using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace MediaDatabase.Models
{
    public class EfUserRepository : IUserRepository
    {
        //   F i e l d s   &   P r o p e r t i e s

        private AppDbContext context;
        private readonly IHttpContextAccessor httpContextAccessor;

        //   C o n s t r u c t o r s

        public EfUserRepository(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
        }

        //   M e t h o d s
        public User Create(User user) 
        {
            user = Crypto(user);
            context.Users.Add(user);
            context.SaveChanges();
            httpContextAccessor.HttpContext.Session.SetInt32("_UserId", user.Id);
            return user;
        }

        public IQueryable<User> GetAllUsers()
        {
            return context.Users.OrderBy(u => u.Email);
        }

        public User GetUserById(int id)
        {
            return context.Users
                .Where(u => u.Id == id)
                .Include(u => u.MediaEntries)
                .FirstOrDefault();
        }

        public IQueryable<User> GetUsersByKeyword(string keyword)
        {
            return context.Users
               .Where(u => u.Email.Contains(keyword));
        }
        public int GetLoggedUser() 
        {
            if (httpContextAccessor.HttpContext.Session.GetInt32("_UserId") != null)
            {
                return (int)httpContextAccessor.HttpContext.Session.GetInt32("_UserId");
            }
            return 0;
        }
        public User UpdateUser(User user) 
        {
            User userToUpdate = context.Users.SingleOrDefault(u => u.Id == user.Id);
            if (userToUpdate != null) 
            {
                userToUpdate.Email = user.Email;
                userToUpdate.Password = user.Password;
                userToUpdate = Crypto(userToUpdate);
                context.SaveChanges();
            }
            return userToUpdate;
        }
        public bool DeleteUser(int id) 
        {
            User userToDelete = context.Users.FirstOrDefault(u => u.Id == id);
            if (userToDelete == null) 
            {
                return false;
            }
            context.Users.Remove(userToDelete);
            context.SaveChanges();
            return true;
        }
        public bool Login(User user, String pass) 
        {
            bool login = Crypto(user, pass);
            if(login) 
            {
                httpContextAccessor.HttpContext.Session.SetInt32("_UserId", user.Id);
            }
            return login;
        }
        public void RemoveLoggedUser() 
        {
            if (GetLoggedUser() != 0) 
            {
                httpContextAccessor.HttpContext.Session.Clear();
            }
        }
        private User Crypto(User user)
        {
            user.Salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(user.Salt);
            }
            user.Password = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: user.Password,
                salt: user.Salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            return user;
        }
        private bool Crypto(User user, string pass) 
        {
            if (user.Salt == null) 
            {
                user.Salt = new byte[128 / 8];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(user.Salt);
                }
                user.Password = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: user.Password,
                salt: user.Salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
                context.SaveChanges();
            }
            pass = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: pass,
                salt: user.Salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            if (pass == user.Password)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }
    }

}
