using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ST10303347_CLDV6211POE2024.Data.myMethods;
using ST10303347_CLDV6211POE2024.Models;
using System.Diagnostics;

namespace ST10303347_CLDV6211POE2024.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Productmethods _myMethods;

       
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
          return View();

        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ShowWork()
        {
            return View("MyWorkPage");
        }
        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Contact_Us()
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
