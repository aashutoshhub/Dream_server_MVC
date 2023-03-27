using DreamServe.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DreamServe.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        AdminModel admObj = new AdminModel();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            admObj = new AdminModel();
            List<AdminModel> lst = admObj.getJobListData();
            return View(lst);
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