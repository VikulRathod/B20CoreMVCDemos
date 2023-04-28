using Microsoft.AspNetCore.Mvc;

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

            return View();
        }
    }
}
