using Microsoft.AspNetCore.Mvc;
using P.Pager.Mvc.Core9.Example.Models;
using System.Diagnostics;

namespace P.Pager.Mvc.Core9.Example.Controllers
{
    public class HomeController(ILogger<HomeController> logger) : Controller
    {
        DemoData _data = new DemoData();

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
