using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaDatabase.Models
{
    public interface IUserRepository
    {
        //   C r e a t e
        User Create(User user);
        //   R e a d
        IQueryable<User> GetAllUsers();
        User GetUserById(int UserId);
        IQueryable<User> GetUsersByKeyword(string keyword);
        bool Login(User user, string pass);
        int GetLoggedUser();
        void RemoveLoggedUser();
        //   U p d a t e
        User UpdateUser(User user);
        //   D e l e t e
        bool DeleteUser(int id);
    }
}
