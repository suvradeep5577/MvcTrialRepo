using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCTrial.Areas.Financial.Controllers
{

    [Area("Financial")]
    [Route("Financial/[controller]/[action]")] // for link creation from other page
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Graph()
        {
            return View();
        }
    }
}
