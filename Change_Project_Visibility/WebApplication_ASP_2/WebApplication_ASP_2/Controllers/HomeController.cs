using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication_ASP_2.Models;

namespace WebApplication_ASP_2.Controllers
{
    [ApiController]
    public class HomeController : Controller
    {
        [Route("/")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/about")]
        [HttpGet]
        public IActionResult About()
        {
            ViewData["Message"] = "Description page.";

            return View();
        }

        [Route("/contact")]
        [HttpGet]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Contact page.";

            return View();
        }

        [Route("/privacy")]
        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("/error")]
        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
