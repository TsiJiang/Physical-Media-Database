using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MediaDatabase.Models
{
    public class EfUserRepository : IUserRepository
    {
        //   F i e l d s   &   P r o p e r t i e s

        private AppDbContext context;

        //   C o n s t r u c t o r s

        public EfUserRepository(AppDbContext context)
        {
            this.context = context;
        }

        //   M e t h o d s
        public User Create(User user) 
        {
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }

        public IQueryable<User> GetAllUsers()
        {
            return context.Users;
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
        public User UpdateUser(User user) 
        {
            User userToUpdate = context.Users.SingleOrDefault(u => u.Id == user.Id);
            if (userToUpdate != null) 
            {
                userToUpdate.Email = user.Email;
                userToUpdate.Password = user.Password;
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
    }

}
