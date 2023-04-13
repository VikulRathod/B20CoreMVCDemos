using Microsoft.AspNetCore.Mvc;

namespace MVCCoreProject.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public string GetMessage()
        {
            return "Hello, Good Morning!!";
        }
    }
}
