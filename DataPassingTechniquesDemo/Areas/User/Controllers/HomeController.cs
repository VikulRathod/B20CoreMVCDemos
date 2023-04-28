using Microsoft.AspNetCore.Mvc;

namespace DataPassingTechniquesDemo.Areas.User.Controllers
{
    [Area("user")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // ViewBag.CommonData = TempData["commonData"];

            ViewBag.CommonData = TempData.Peek("commonData");
            return View();
        }
    }
}
