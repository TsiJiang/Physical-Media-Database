using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediaDatabase.Models;

namespace MediaDatabase.Controllers
{
    public class MediaTypesController : Controller
    {
        private IMediaTypeRepository repository;

        public MediaTypesController(IMediaTypeRepository repository) 
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Create(int userId) 
        {
            MediaType mediaType = new MediaType();
            mediaType.UserId = userId;
            return View(mediaType);
        }

        [HttpPost]
        public IActionResult Create(MediaType mediaType) 
        {
            repository.CreateMediaType(mediaType);
            int id = mediaType.Id;
            return RedirectToAction("Detail", "User", new { id });
        }

        public IActionResult Index(int id)
        {
            if (id > 0)
            {
                return RedirectToAction("Detail", "User", new { id });
            }
            return RedirectToAction("Index", "User");
        }

        [HttpGet]
        public IActionResult Update(int id, int userId)
        {
            MediaType mediaType = repository.GetMediaTypeById(id);
            if(mediaType != null && userId == repository.GetLoggedUser())
            {
                return View(mediaType); 
            }
            return RedirectToAction("Detail", "User", new { id = repository.GetLoggedUser() });
        }

        [HttpPost]
        public IActionResult Update(MediaType mediaType) 
        {
            repository.UpdateMediaType(mediaType);
            return RedirectToAction("Detail", "User", new { id = repository.GetLoggedUser() });
        }

        [HttpGet]
        public IActionResult Delete(int id, int userId) 
        {
            MediaType mediaType = repository.GetMediaTypeById(id);
            if (mediaType != null && userId == repository.GetLoggedUser()) 
            {
                return View(mediaType);
            }
            return RedirectToAction("Detail", "User", new { id = repository.GetLoggedUser() });
        }
        [HttpPost]
        public IActionResult Delete(MediaType mediaType) 
        {
            repository.DeleteMediaType(mediaType.Id);
            return RedirectToAction("Detail", "User", new { id = repository.GetLoggedUser() });
        }
    }
}
