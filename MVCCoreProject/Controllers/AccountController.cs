using Microsoft.AspNetCore.Mvc;
using MVCCoreProject.Models;

namespace MVCCoreProject.Controllers
{
    public class AccountController : Controller
    {
        public ViewResult Users()
        {
            // hit database to fetch all users
            List<UserModel> users = new List<UserModel>()
            {
            new UserModel(){Name="Vishal", Email = "v@v.com"},
            new UserModel(){Name="Mahesh", Email = "m@v.com"},
            new UserModel(){Name="Shital", Email = "s@v.com"},
            new UserModel(){Name="Akash", Email = "a@v.com"},
            new UserModel(){Name="Supriya", Email = "s@v.com"},
            };

            ViewBag.name = "Vhaash Technologies";
            ViewData["email"] = "vhaash@gmail.com";

            //// ViewBag.Users = users;
            //ViewData["Users"] = users;

            return View(users);
        }

        public ViewResult Details()
        {
            UserModel user =
                new UserModel() { Name = "Vishal", Email = "v@v.com" };

            return View(user);
        }

        public IActionResult Index()
        {
            // return View(); // Index.cshtml
            return View("RazorDemo");
        }

        //public string Login()
        //{
        //    return "Name: <input type='text'/> <br/> Password: <input type='password'/><br/><input type='submit' value='Log In'/>";
        //}

        // [Route("")] // url : localhost
        [Route("vhaash-home")] // url : localhost/vhaash-home
        [HttpGet]
        // public IActionResult Login()
        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password))
            {
                return RedirectToAction("Welcome", "Department"); // redirection
            }

            return View();
        }
    }
}
