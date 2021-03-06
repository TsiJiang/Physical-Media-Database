﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediaDatabase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;

namespace MediaDatabase.Controllers
{
    public class MediaEntryController : Controller
    {
        //   F i e l d s   &   P r o p e r t i e s

        private IMediaEntryRepository repository;

        //   C o n s t r u c t o r s

        public MediaEntryController(IMediaEntryRepository repository)
        {
            this.repository = repository;
        }

        //   M e t h o d s
        [HttpGet]
        public IActionResult Create(int userId) 
        {
            MediaEntry newMediaEntry = new MediaEntry();
            newMediaEntry.UserId = userId;
            return View(newMediaEntry);
        }
        [HttpPost]
        public IActionResult Create(MediaEntry mediaEntry) 
        {
            mediaEntry.LastModified = System.DateTime.Now;
            repository.Create(mediaEntry);
            int id = mediaEntry.UserId;
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
        public IActionResult Detail(int id, int userId)
        {
            MediaEntry mediaEntry = repository.GetMediaEntryById(id);
            if (mediaEntry != null)
            {
                return View(mediaEntry);
            }
            id = userId;
            return RedirectToAction("Detail","User", new { id });
        }

        public IActionResult Search(string keyword, int userId)
        {
            IEnumerable<MediaEntry> mediaEntries =
               repository.GetMediaEntriesByKeyword(keyword,userId);
            return View(mediaEntries);
        }
        [HttpGet]
        public IActionResult Update(int id, int userId)
        {
            MediaEntry mediaEntry = repository.GetMediaEntryById(id);
            if (mediaEntry != null && userId == repository.GetLoggedUser())
            {
                mediaEntry.UserId = repository.GetLoggedUser();
                return View(mediaEntry);
            }
            return RedirectToAction("Detail","User", new { id = repository.GetLoggedUser() });
        }

        [HttpPost]
        public IActionResult Update(MediaEntry mediaEntry)
        {
            mediaEntry.LastModified = System.DateTime.Now;
            repository.UpdateMediaEntry(mediaEntry);
            int id = mediaEntry.Id;
            return RedirectToAction("Detail","MediaEntry", new { id, userId = repository.GetLoggedUser() });
        }

        [HttpGet]
        public IActionResult Delete(int id, int userId) 
        {
            MediaEntry mediaEntry = repository.GetMediaEntryById(id);
            if (mediaEntry != null) 
            {
                return View(mediaEntry);
            }
            id = userId;
            return RedirectToAction("Detail","User", new { id });
        }
        [HttpPost]
        public IActionResult Delete(MediaEntry mediaEntry, int id, int userId) 
        {
            repository.DeleteMediaEntry(id);
            id = userId;
            return RedirectToAction("Detail","User", new { id });
        }
    }

}
