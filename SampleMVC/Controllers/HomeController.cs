using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SampleMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return Content("Hello from About Controller");
        }

        public IActionResult Contact()
        {

            return Content("Hello from Contact Controller");

        }
    }
}