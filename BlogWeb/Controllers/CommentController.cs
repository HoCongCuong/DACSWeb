﻿using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
