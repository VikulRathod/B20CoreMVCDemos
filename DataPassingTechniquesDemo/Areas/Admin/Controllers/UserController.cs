using Microsoft.AspNetCore.Mvc;

namespace DataPassingTechniquesDemo.Areas.Admin.Controllers
{
    // to manage website users
    // [Area("Admin")]
    public class UserController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
