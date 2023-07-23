using Microsoft.AspNetCore.Mvc;
using MVCTrial.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using MVCTrial.Helper;

namespace MVCTrial.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration conobj = null;
        // private readonly MyCustomSevices objser = null;

        private readonly IMyCustomSevices objsrvc;

        private readonly IMyCustomEmailService Emailobj;


        public HomeController( IConfiguration obj, IMyCustomSevices obj2, IMyCustomEmailService Emailobj2)
        {
            conobj = obj;
            //objser = obj2;
            objsrvc = obj2;
            Emailobj = Emailobj2;
        }

        public async Task TestEmail()
        {
            UserEmailOption data = new UserEmailOption() {

                Placeholders = new List<KeyValuePair<string, string>>()
                {

                    new KeyValuePair<string, string>("{{UserName}}","SSR")

                }
             
             };
            await Emailobj.TestingForEmail(data);
        }
        [Authorize]
        public IActionResult Index()
        {
          
            var result = conobj["AppName"];
            var key1 = conobj["INFOobj:key1"];
            var key2 = conobj["INFOobj:key2"];
            var key3 = conobj["INFOobj:key3:key3obj"];


            var res1 = conobj["AppBoolValue"];
            var res2 = conobj.GetValue<bool>("AppBoolValue");


            var res3 = conobj.GetValue<bool>("DemoBookObj:BoolValue");
            var res4 = conobj.GetValue<string>("DemoBookObj:BookName");
            var bookob = conobj.GetSection("DemoBookObj");
            var res5 = bookob.GetValue<bool>("BoolValue");
            var res6 = bookob.GetValue<string>("BookName");


            ConModel com = new ConModel();
            conobj.Bind("DemoBookObj",com);
            bool data1 = com.BoolValue;
            string data2 = com.BookName;

            SMTPEmailModel eobj = new SMTPEmailModel();
            conobj.Bind("SMTPConfig", eobj);
            
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
        //[Route("contact-us/{id:int}")]
        [Route("contact-us")]
        [Authorize]
        public IActionResult ContactUs()
        
        {
            // var userid = objser.getuserid();
            var userid = objsrvc.getuserid();
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        //[Authorize]
        [Authorize(Roles ="Admin")]
        public IActionResult AboutUs()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
    }
}
