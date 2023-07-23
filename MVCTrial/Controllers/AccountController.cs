using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCTrial.Models;
using MVCTrial.BookRepositary;

namespace MVCTrial.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepositary accrep=null;
        public AccountController( IAccountRepositary obj)
        {
            accrep = obj;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpUserData info )
        {
            if(ModelState.IsValid)
            {

                var res = await accrep.SignUpData(info);

                if(!res.Succeeded)
                {
                    foreach( var item in res.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }


                    return View(info);
                }

                ModelState.Clear();

            }
            
            
            return View(info);
        }


        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel info)
        {
           
            if(ModelState.IsValid)
            {
                var res = await accrep.PasswordCheck(info);

                if (res.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid Details");


            }

            //ModelState.Clear();


            return View(info);


        }

        public async Task<IActionResult> Logout()
        {
            await accrep.logout();
            return RedirectToAction("Login", "Account");
        }

        [Route("confirm-email")]
        public async Task<IActionResult> EmailConfirmation(string uid, string token)
        {
            if(!string.IsNullOrEmpty(uid) && !string.IsNullOrEmpty(token))
            {
               var res= await accrep.EmailConfirm(uid, token);

                if(res.Succeeded)
                {
                    ViewBag.IsSuccess = true;
                }

            }

            return View();
        }
    }
}
