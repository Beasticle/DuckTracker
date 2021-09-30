using DuckTracker.Data;
using DuckTracker.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuckTracker.Controllers
{
    public class DuckPageController : Controller
    {

        private readonly DuckContext _context;
        public DuckPageController(DuckContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var ducksList = _context.Set<Duck>().ToList();

            return View(ducksList);
        }
    }
}
