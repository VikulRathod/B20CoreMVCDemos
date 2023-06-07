using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebApiClient.Models;
using System.Net.Http.Headers;

namespace WebApiClient.Controllers
{
    public class CategoriesController : Controller
    {
        HttpClient client;
        string baseAddress;

        public CategoriesController(IConfiguration configuration)
        {
            this.client = new HttpClient();
            baseAddress = configuration["apiAddress"];
            this.client.BaseAddress = new Uri(baseAddress);
        }

        public IActionResult Index()
        {
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("https://localhost:7292/api/");

            //string result =
            //    client.GetStringAsync(baseAddress + "Categories/?type="+"true").Result;

            string accessToken = HttpContext.Session.GetString("accessToken");

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", accessToken);

            string result =
                client.GetStringAsync(baseAddress + "Categories").Result;

            List<CategoryModel> categories =
                JsonSerializer.Deserialize<List<CategoryModel>>(result);

            return View(categories);
        }

        public IActionResult Details(int id)
        {
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("https://localhost:7292/api/");

            string result =
                client.GetStringAsync(baseAddress + $"Categories/{id}").Result;

            CategoryModel category =
                JsonSerializer.Deserialize<CategoryModel>(result);

            return View(category);
        }


    }
}
