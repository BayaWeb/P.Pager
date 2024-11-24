﻿using Microsoft.AspNetCore.Mvc;
using P.Pager.Mvc.Core7.Example.Models;
using System.Diagnostics;

namespace P.Pager.Mvc.Core7.Example.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        DemoData _data;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _data = new DemoData();
        }

        public IActionResult Index(int page = 1)
        {
            var pager = _data.GetMembers().ToPagerList(page, 2);
            return View(pager);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
