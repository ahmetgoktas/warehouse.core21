using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Stock()
        {
            ViewData["Message"] = "Stock List";

            return View();
        }

        public IActionResult Plant()
        {
            ViewData["Message"] = "Plant List";

            return View();
        }

        public IActionResult Location()
        {
            ViewData["Message"] = "Location List";

            return View();
        }

        public IActionResult MovementType()
        {
            ViewData["Message"] = "Movement Type List";

            return View();
        }

        public IActionResult User()
        {
            ViewData["Message"] = "User List";

            return View();
        }

        public IActionResult Product()
        {
            ViewData["Message"] = "Product List";

            return View();
        }

        public IActionResult LocationType()
        {
            ViewData["Message"] = "Location Type List";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
