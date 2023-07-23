using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCTrial.Data;
using MVCTrial.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using MVCTrial.Helper;
using Microsoft.AspNetCore.Mvc;

namespace MVCTrial.BookRepositary
{
    public class AccountRepositary : IAccountRepositary
    {
        //private readonly UserManager<IdentityUser> usermanager;

        //public AccountRepositary(UserManager<IdentityUser> obj)
        //{
        //    usermanager = obj;
        //}

        private readonly UserManager<ApplicationUser> usermanager;

        private readonly SignInManager<ApplicationUser> signinmanager;

        private readonly IConfiguration conobj;

        private readonly IMyCustomEmailService emobj;

        public AccountRepositary(UserManager<ApplicationUser> obj, SignInManager<ApplicationUser> obj2, IConfiguration conobj2, IMyCustomEmailService emobj2)
        {
            usermanager = obj;
            signinmanager = obj2;
            conobj = conobj2;
            emobj = emobj2;
        }

        public async Task<IdentityResult> SignUpData(SignUpUserData info)
        {
            int res = 0;

            //var user = new IdentityUser()
            //{
            //    Email = info.Email,
            //    UserName = info.Email


            //};

            var user = new ApplicationUser()
            {
                Email = info.Email,
                UserName = info.Email,
                FirstName = info.FirstName,
                LastName = info.LastName,
                DOB = info.DOB
                


            };


            var result = await usermanager.CreateAsync(user, info.Pasword);

            if(result.Succeeded)
            {
                var token = await usermanager.GenerateEmailConfirmationTokenAsync(user);

                if(token!=null && token!="")
                {
                    await sendEmailconfirmLink(user,token);
                }
            }

            return result;
        }


        public async Task<Microsoft.AspNetCore.Identity.SignInResult> PasswordCheck(LoginModel info)
        {
            var res = await signinmanager.PasswordSignInAsync(info.Email, info.Pasword, info.RememberMe, false);

            return res;
        }

        public async Task<IdentityResult> EmailConfirm(string uid, string token)
        {
            ApplicationUser userob = new ApplicationUser();
            userob = await usermanager.FindByIdAsync(uid);

            token = token.Replace(' ', '+');

            return await usermanager.ConfirmEmailAsync(userob, token);
           
        }

        public async Task logout()
        {
           await signinmanager.SignOutAsync();
        }

        private async Task sendEmailconfirmLink(ApplicationUser user, string token)
        {
            string appDomain = conobj.GetSection("Application:AppDomain").Value;
            string confirmlink = conobj.GetSection("Application:EmailConfirmation").Value;
             
            UserEmailOption option = new UserEmailOption()
            {
                Placeholders=new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("{{UserName}}", user.FirstName),
                    new KeyValuePair<string, string>(" {{Link}}",
                                                    string.Format(appDomain + confirmlink,user.Id, token))

                }

            };
            await emobj.SendEmailConfirmation(option);
            
        }
       

        //int IAccountRepositary.SignUp(SignUpUserData info)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
