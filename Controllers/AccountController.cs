using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.MVCCoreWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Asp.MVCCoreWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> SignInManager;

        public AccountController( SignInManager<IdentityUser> SignInManager)
        {
           
            this.SignInManager = SignInManager;
        }


        public IActionResult Index()
        {
            
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginModel authdetail)
        {


            if (ModelState.IsValid)
            {
                var result = await SignInManager.PasswordSignInAsync(authdetail.UserName, authdetail.Password, authdetail.RemeberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login attemp");

            }
            return View();
        }

        public async Task<IActionResult> Logout() {

           await SignInManager.SignOutAsync();

           return RedirectToAction("login","Account");
        }


    }
}