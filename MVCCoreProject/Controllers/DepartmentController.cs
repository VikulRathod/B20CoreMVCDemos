using Microsoft.AspNetCore.Mvc;

namespace MVCCoreProject.Controllers
{
    public class DepartmentController : Controller
    {
        // normal c# method = action method
        public string Welcome()
        {
            var cities = Cities();
            // we will bind these cities to any UI control on view

            return "Hello from department controller";
        }

        // non action method = its a normal c# method
        string Private()
        {
            return "Private method called";
        }

        // normal c# method = action method
        // any way to make it non action method
        [NonAction]
        public string Public()
        {
            return "Public method called";
        }

        [NonAction]
        public List<string> Cities()
        {
            return new List<string> 
            {
            "Pune", "Mumbai", "Delhi"
            };
        }
    }
}
