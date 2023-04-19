using Microsoft.AspNetCore.Mvc;
using ViewsDemo.Models;

namespace ViewsDemo.Components
{
    public class FeedbackViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            List<FeedbackModel> feedbacks = new List<FeedbackModel>() 
            {
            new FeedbackModel(){ Username = "Atul", Comment = "Happy"},
            new FeedbackModel(){ Username = "Vishal", Comment = "Not bad"},
            };

            return View("~/Views/Components/Feedback.cshtml", feedbacks);
        }
    }
}
