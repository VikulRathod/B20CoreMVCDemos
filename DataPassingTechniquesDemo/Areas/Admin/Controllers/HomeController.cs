﻿using Microsoft.AspNetCore.Mvc;

namespace DataPassingTechniquesDemo.Areas.Admin.Controllers
{
    // [Area("Admin")]
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
