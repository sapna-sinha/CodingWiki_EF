﻿using CodingWiki_DataAccess.Data;
using CodingWiki_Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingWiki_Web.Controllers
{
    public class PublisherController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PublisherController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Publisher> publisherList = _db.Publishers.ToList();
            return View(publisherList);
        }

        public IActionResult Upsert(int? id)
        {
            Publisher obj = new Publisher();
            if (id == null || id == 0)
            {
                //create
                return View(obj);
            }
            obj = _db.Publishers.FirstOrDefault(u=>u.Publisher_Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Publisher obj)
        {
            if (ModelState.IsValid)
            {
                if (obj == null)
                {
                    //create
                   await _db.Publishers.AddAsync(obj);
                }
                else
                {
                    //update
                    _db.Publishers.Update(obj);
                }
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }


        public async Task<IActionResult> Delete(int id)
        {
            Publisher obj = new Publisher();
            obj = _db.Publishers.FirstOrDefault(u => u.Publisher_Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            
            _db.Publishers.Remove(obj);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index)); 
        }

       
    }
}
