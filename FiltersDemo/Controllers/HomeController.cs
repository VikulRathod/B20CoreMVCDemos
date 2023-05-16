using FiltersDemo.Filters;
using FiltersDemo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FiltersDemo.Controllers
{
    //     [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // [AllowAnonymous]
        public IActionResult Register()
        {
            throw new Exception("Exception for demo");
            return View();
        }

        // [AllowAnonymous] // anyone without login
        [MyResourceFilter]
        [MyActionFilter]
        // [MyExceptionFilter]
        public IActionResult Login()
        {
            //try
            //{
                Console.WriteLine("Login starts");

                int a = 10, b = 0;
                int c = a / b;

                Console.WriteLine("Login ends");
            //}
            //catch
            //{

            //}
            return View();
        }

        // [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        // [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ErrorView()
        {
            return View();
        }
    }
}