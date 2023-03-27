using DreamServe.Models;
using Microsoft.AspNetCore.Mvc;

namespace DreamServe.Controllers
{
    public class PageController : Controller
    {

        AdminModel admObj = new AdminModel();

        public IActionResult Home()
        {
            return View();
        }
        
        public IActionResult FindaJobs()
        {
            admObj = new AdminModel();
            List<AdminModel> lst = admObj.getJobListData();
            return View(lst);
        }
    

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }


    }
}
