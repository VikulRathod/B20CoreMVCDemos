using DataPassingTechniquesDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataPassingTechniquesDemo.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            ViewData["site"] = "VHaaSh Technologies";
            ViewBag.welcome = "Good Morning!!!";

            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel user)
        {
            if (user.Username == "user" &&
                user.Password == "user")
            {
                return RedirectToAction("Index", "Home", new { area = "user" });
            }
            else if (user.Username == "admin" &&
                user.Password == "admin")
            {
                return RedirectToAction("Index", "Home", new { area = "admin" });
            }

            return View();
        }
    }
}
