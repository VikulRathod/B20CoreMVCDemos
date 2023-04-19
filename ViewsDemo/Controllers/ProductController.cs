using Microsoft.AspNetCore.Mvc;
using ViewsDemo.Models;

namespace ViewsDemo.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            // return View(); // Index.cshtml
            return View("demo");
        }

        public ViewResult Details()
        {
            ProductModel product = new ProductModel() 
            {
            Name = "Casual Shirt",
            Price = 599,
            CategoryName = "Mens Wear"
            };

            List<FeedbackModel> feedbacks = new List<FeedbackModel>()
            {
            new FeedbackModel(){ Username = "Atul", Comment = "Happy"},
            new FeedbackModel(){ Username = "Vishal", Comment = "Not bad"},
            };

            ViewBag.feedbacks = feedbacks;

            return View(product);
        }

        public ViewResult Edit(int? id)
        {
            ProductModel product = new ProductModel()
            {
                Name = "Casual Shirt",
                Price = 599,
                CategoryName = "Mens Wear"
            };

            return View(product);
        }
    }
}
