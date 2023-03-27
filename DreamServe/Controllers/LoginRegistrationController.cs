
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using DreamServe.Models;

namespace DreamServe.Controllers
{

    public class LoginRegistrationController : Controller
	{
		AccountModel amodel = new AccountModel();
		public IActionResult Registration()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Registration(AccountModel am)
		{
			amodel = new AccountModel();
			bool res = amodel.insert(am);

			if (res)
			{
				TempData["msg"] = "Register Successfully";
				//Response.Redirect('')
			}
			else
			{
				TempData["msg"] = "Something went wrong!!";

			}

			return View();
		}



		[HttpGet]
		public IActionResult Login(string Email)
		{
			var row = amodel.getData().Where(model => model.email == Email).FirstOrDefault();
			return View(row);
		}

		[HttpPost]
		public IActionResult Login(AccountModel am)
		{
			var data = amodel.getData().Where(model => model.email == am.email && model.pass == am.pass).FirstOrDefault();

			if (data != null)
			{
                if (am.email == "admin@gmail.com" && am.pass == "adminadmin")
				{
                    return RedirectToAction("Index", "admin");
				}
				else
				{
                    return RedirectToAction("Index", "Home");
                }
                    
                //TempData["msg"] = "Login Successfully"+am.email;
		
            }

            else
			{
				TempData["msg"] = "Something went wrong!";
			}
			return View();
		}



		[HttpPost]
		public IActionResult LogOut()
		{
			HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Login", "Account");
		}
	}
}