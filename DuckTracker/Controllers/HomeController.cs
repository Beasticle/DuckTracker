using DuckTracker.Data;
using DuckTracker.Data.Entities;
using DuckTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DuckTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DuckContext _context;

        public HomeController(ILogger<HomeController> logger, DuckContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            
            var ducksList = _context.Set<Duck>().ToList();

            return View(ducksList);
        }



        public IActionResult Edit(int id)
        {
            // get from database by id
            var editDuck = _context.Set<Duck>().Where(d => d.Id == id).FirstOrDefault();
            return View(editDuck);
        }

        [HttpPost]
        [ActionName("Edit")]
        public IActionResult Edit_Post([Bind("Id,Name,Location")] Duck duck)
        {
            // editing
            if (ModelState.IsValid)
            {
                var duckNameCheck = _context.Set<Duck>().Where(d => d.Name == duck.Name && d.Id != duck.Id).FirstOrDefault();

                if(duckNameCheck == null)
                {
                    //do stuff
                    _context.Set<Duck>().Update(duck);
                    _context.SaveChanges();
                } 
                else
                {
                    ModelState.AddModelError("Name", "A duck with this name already exists.");
                    return View(duck);
                }
            }
         

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var delDuck = _context.Set<Duck>().Where(d => d.Id == id).FirstOrDefault();
            return View(delDuck);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult Delete_Post([Bind("Id,Name,Location")] Duck duck)
        {
            if (ModelState.IsValid)
            {
                var duckNameCheck = _context.Set<Duck>().Where(d => d.Name == duck.Name && d.Id != duck.Id).FirstOrDefault();
                
                if (duckNameCheck == null)
                {
                    _context.Set<Duck>().Remove(duck);
                    _context.SaveChanges();
                } 
                else
                {
                    ModelState.AddModelError("Name", "A duck with the same name exists.");
                    return View(duck);
                }
            }

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
