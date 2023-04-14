using Microsoft.AspNetCore.Mvc;

namespace MVCCoreProject.Controllers
{
    public class AccountController : Controller
    {
        //public string Login()
        //{
        //    return "Name: <input type='text'/> <br/> Password: <input type='password'/><br/><input type='submit' value='Log In'/>";
        //}

        [Route("")]
        [Route("vhaash-home")]
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
