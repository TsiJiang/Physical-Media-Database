using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediaDatabase.Models;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace MediaDatabase.Controllers
{
    public class UserController : Controller
    {
        //   F i e l d s   &   P r o p e r t i e s

        private IUserRepository repository;

        //   C o n s t r u c t o r s

        public UserController(IUserRepository repository)
        {
            this.repository = repository;
        }

        //   M e t h o d s
        [HttpGet]
        public IActionResult Create() 
        {
            User newUser = new User();
            return View(newUser);
        }
        [HttpPost]
        public IActionResult Create(User user, string pass, string pass2) 
        {
            if (pass == pass2)
            {
                repository.Create(user);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Create");
            
        }
        public IActionResult Index()
        {
            IQueryable<User> allUsers =
               repository.GetAllUsers();
            return View(allUsers);
        }
        public IActionResult Detail(int id)
        {
            User user = repository.GetUserById(id);
            if (user != null)
            {
                return View(user);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Search(string keyword)
        {
            IEnumerable<User> users =
               repository.GetUsersByKeyword(keyword);
            return View(users);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            User user = repository.GetUserById(id);
            if (user != null)
            {
                return View(user);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(User user, int id, string oldPass, string newPass, string newPass2)
        {
            if (user.Password == oldPass && newPass == newPass2)
            {
                user.Password = newPass;
                repository.UpdateUser(user);
            }
            return RedirectToAction("Detail", "User", new { id });
        }
        [HttpGet]
        public IActionResult Delete(int id) 
        {
            User user = repository.GetUserById(id);
            if (user != null) 
            {
                return View(user);
            }
            return RedirectToAction("Detail", "User", new { id });
        }
        [HttpPost]
        public IActionResult Delete(User user, int id, string pass) 
        {
            if (pass == user.Password)
            {
                repository.DeleteUser(id);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Detail", "User", new { id });
        }
    }

}
