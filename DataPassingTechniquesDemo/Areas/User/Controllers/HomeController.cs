using Microsoft.AspNetCore.Mvc;

namespace DataPassingTechniquesDemo.Areas.User.Controllers
{
    [Area("user")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
