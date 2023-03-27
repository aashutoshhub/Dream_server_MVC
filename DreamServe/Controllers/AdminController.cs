using DreamServe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;


namespace DreamServe.Controllers
{
    public class AdminController : Controller
    {
        AdminModel admObj = new AdminModel();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dboard()
        {
            return View();
        }
       

        //NewJob
        public IActionResult NewJob()
        {
            return View();
        }


        [HttpPost]
        public IActionResult NewJob(AdminModel am)
        {
            bool res;
            admObj = new AdminModel();
             res = admObj.insert(am);

            if (res)
            {
                TempData["msg"] = "new job inserted Successfully";
                
            }
            else
            {
                TempData["msg"] = "Something went wrong!!";

            }

            return View();
        }


        //JobList
        public IActionResult JobList()
        {
            admObj = new AdminModel();
            List<AdminModel> lst = admObj.getJobListData();
            return View(lst);
        }



        public IActionResult UserList()
        {
            admObj = new AdminModel();
            List<AdminModel> lst = admObj.getData();
            return View(lst);
        }



    }
}
