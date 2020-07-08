using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediaDatabase.Models;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;

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
        public IActionResult Register() 
        {
            User newUser = new User();
            return View(newUser);
        }
        [HttpPost]
        public IActionResult Register(User user, string pass, string pass2) 
        {
            if (pass == pass2)
            {
                user.Email = user.Email.ToLower();
                user.Password = pass;
                repository.Create(user);
                return RedirectToAction("Index", "MediaEntry");
            }
            return RedirectToAction("Register");   
        }
        [HttpGet]
        public IActionResult Login() 
        {
            if (repository.GetLoggedUser() == 0) 
            {
                User user = new User();
                return View(user); 
            }
            return RedirectToAction("Index", "MediaEntry", new { id = repository.GetLoggedUser() });
        }
        [HttpPost]
        public IActionResult Login(User query) 
        {
            User user = repository.GetUserById(repository.GetUsersByKeyword(query.Email.ToLower()).FirstOrDefault().Id);
            if (user != null) 
            {
                if(repository.Login(user, query.Password))
                {
                    return RedirectToAction("Index", "MediaEntry", new { id = repository.GetLoggedUser() }); 
                }
            }
            return RedirectToAction("Login");
        }
        public IActionResult Logout() 
        {
            repository.RemoveLoggedUser();
            return RedirectToAction("Index", "User");
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
            if (user != null && user.Id == repository.GetLoggedUser())
            {
                return View(user);
            }
            return RedirectToAction("Index", "User");
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
            if (user != null && user.Id == repository.GetLoggedUser())
            {
                return View(user);
            }
            return RedirectToAction("Index", "MediaEntry", new { id });
        }

        [HttpPost]
        public IActionResult Update(User user, int id, string oldPass, string newPass, string newPass2)
        {
            if (repository.Login(user, oldPass) && newPass == newPass2)
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
            if (repository.Login(user, pass))
            {
                repository.DeleteUser(id);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Detail", "User", new { id });
        }
    }

}
