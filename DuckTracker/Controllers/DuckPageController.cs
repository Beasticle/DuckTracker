using DuckTracker.Data;
using DuckTracker.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DuckTracker.Controllers
{
    public class DuckPageController : Controller
    {

        private readonly DuckContext _context;
        //private DuckContext Context;
        public DuckPageController(DuckContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var ducksList = _context.Set<Duck>().ToList();

            return View(ducksList);
        }

        public IActionResult AddDuck(string Name, string Location)
        {
            return View();
        }

        [HttpPost]
        [ActionName("addDuck")]

        public IActionResult AddDuck_Post([Bind("Name,Location,Details")] Duck duck)
        {
            if (ModelState.IsValid)
            {
                var duckNameCheck = _context.Set<Duck>().Where(d => d.Name == duck.Name && d.Id != duck.Id).FirstOrDefault();

                if (duckNameCheck == null)
                {
                    //do stuff
                    _context.Set<Duck>().Add(duck);
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


         
    }
}
