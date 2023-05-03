using DataPassingTechniquesDemo.Models;
using Microsoft.AspNetCore.Mvc;
// using Newtonsoft.Json;
using System.Text.Json;

namespace DataPassingTechniquesDemo.Areas.Admin.Controllers
{
    // [Area("Admin")]
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            //ViewBag.CommonData = TempData["commonData"];
            //TempData.Keep("commonData"); // to keep value for next requests

            ViewBag.CommonData = TempData.Peek("commonData");

            //ViewBag.CookieData = Request.Cookies["DemoUsername"];

            //ViewBag.userDetails = JsonSerializer.Deserialize<LoginModel>
            //    (Request.Cookies["userDetails"]);

            ViewBag.SessionUserName = HttpContext.Session.GetString("sessionUsername");

            string user1 = HttpContext.Session.GetString("NewUser");
            if (user1 != null)
            {
                ViewBag.NewUser = JsonSerializer.Deserialize<LoginModel>(user1);
            }
            else
            {
                ViewBag.NewUser = "Session expired.";
            }

            return View();
        }
    }
}
