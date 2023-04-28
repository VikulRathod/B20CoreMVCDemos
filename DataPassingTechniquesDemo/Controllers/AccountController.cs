using DataPassingTechniquesDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using System.Text.Json;

namespace DataPassingTechniquesDemo.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            ViewData["site"] = "VHaaSh Technologies";
            ViewBag.welcome = "Good Morning!!!";

            TempData["commonData"] = "Common Data For All Views";                       

            return View();
        }

        [HttpPost]
        // public IActionResult Login(LoginModel user)
        public IActionResult Login(IFormCollection form)
        {
            string loginAs = form["LogInAs"];
            string site = form["website"]; // hidden field
            LoginModel user = new LoginModel()
            {
                Username = form["Username"],
                Password = form["Password"]
            };

            TempData["user"] = JsonSerializer.Serialize(user);

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

        [HttpGet]
        public IActionResult Welcome(int? id, string name, int? age)
        {
            // to read query parameters
            string userName = Request.Query["name"];
            int userAge = int.Parse(Request.Query["age"]);

            //to pass value in query string with encoding
            string value = "Vikul&Vihaan";
            string enValue = HttpUtility.UrlEncode(value); // Vikul%26Vihaan

            ViewBag.name = name;
            ViewBag.age = age;
            return View();
        }
    }
}
