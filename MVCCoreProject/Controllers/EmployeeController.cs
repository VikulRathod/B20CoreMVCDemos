using Microsoft.AspNetCore.Mvc;

namespace MVCCoreProject.Controllers
{
    [Route("[controller]/[action]")]
    public class EmployeeController : Controller
    {
        // employee/index
        public IActionResult Index()
        {
            return View();
        }

        // employee/index1/10
        public IActionResult Index1(int id)
        {
            return View();
        }

        // employee/details/10/2
        public IActionResult Details(int id, int deptid)
        {
            return View();
        }

        [Route("{id?}/{name?}")]
        // employee/edit/10/2
        public IActionResult Edit(int id, string name)
        {
            return View();
        }

        public string GetMessage()
        {
            return "Hello, Good Morning!!";
        }
    }
}
