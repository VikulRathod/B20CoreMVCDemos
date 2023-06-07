using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebApiClient.Models;

namespace WebApiClient.Controllers
{
    public class AccountController : Controller
    {
        HttpClient client;
        string baseAddress;

        public AccountController(IConfiguration configuration)
        {
            this.client = new HttpClient();
            baseAddress = configuration["apiAddress"];
            this.client.BaseAddress = new Uri(baseAddress);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            //call login api
            var response =
                 client.PostAsJsonAsync<LoginModel>("account/login", loginModel).Result;

            // result type = HttpResponseMessage
            if (response.IsSuccessStatusCode)
            {
                string jsonData = response.Content.ReadAsStringAsync().Result;

                UserModel user =
                JsonSerializer.Deserialize<UserModel>(jsonData);

                if (user != null)
                {
                    string accessToken = user.AccessToken;
                    HttpContext.Session.SetString("accessToken", accessToken);

                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("UserName", "Invalid username and/or password");

            return View();
        }
    }
}
