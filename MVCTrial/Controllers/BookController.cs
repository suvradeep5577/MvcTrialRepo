using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCTrial.BookRepositary;
using MVCTrial.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace MVCTrial.Controllers
{
    public class BookController : Controller


    {
        private readonly IRepositaryDemo ob1 = null;
        private readonly ILanRepositary ob2 = null;
        //private readonly IWebHostEnvironment hostobj = null;
        private readonly IHostingEnvironment hostobj2 = null;


        public BookController(IHostingEnvironment hostobj1,IRepositaryDemo obj2, ILanRepositary obj3)
        {
            //ob1 = new RepositaryDemo();
            //ob2 = new LanRepositary();
            ob1 = obj2;
            ob2 = obj3;
            hostobj2 = hostobj1;
        }

        private List<Language> getLanguage()
        {
            var data = new List<Language>()
            {
                new Language(){ID=1, text="Bengali"},
                new Language(){ID=2, text="Hindi"},
                new Language(){ID=3, text="English"},
                new Language(){ID=4, text="Spanish"}


            };

            return data;
        }

        public IActionResult getAllBook()
        {

            var data = ob1.getAllBook();
            return View(data);
        }
        //public ViewResult getAllBook()
        //{
        //    return View();
        //}
        //public BookModel getbookDetail(int id)
        //{
        //    return ob1.getBookDetail(id);
        //}
        [Route("detail-book/{id}",Name ="bookroute")]
        public IActionResult GetbookDetail(int id)
        {


            var data = ob1.getBookDetail(id);
            return View(data);

        }
        public IActionResult AddNewData()
        {
            //var model = new BookModel()
            //{
            //    Language = "Bengali"

            //};
            var listdata = new List<string>()
            {
                "Bengali","Hindi","English"
            };


            // ViewBag.language = listdata;
            //ViewBag.language = new SelectList(getLanguage(), "ID", "text"); 


            //ViewBag.language = getLanguage().Select(x => new SelectListItem
            //{

            //    Text = x.text,
            //    Value = x.ID.ToString()

            //}).ToList();


            //var group1 = new SelectListGroup() { Name = "Group1" };
            //var group2 = new SelectListGroup() { Name = "Group2" };


            //ViewBag.language = new List<SelectListItem>()
            //{
            //    new SelectListItem (){Text="Benali", Value="1", Group=group1},
            //     new SelectListItem (){Text="English", Value="2", Group=group2},
            //      new SelectListItem (){Text="Hindi", Value="3", Group=group2},
            //       new SelectListItem (){Text="spanish", Value="4", Group=group1}

            //};
            ViewBag.language = new SelectList(ob2.getLanguage(), "ID", "text");


            return View();
        }


        [HttpPost]
        public IActionResult AddNewData( BookModel info)


        {

            var listdata = new List<string>()
            {
                "Bengali","Hindi","English"
            };

            //ViewBag.language = listdata;

            // ViewBag.language = new SelectList(getLanguage(), "ID", "text");


            //ViewBag.language = getLanguage().Select(x => new SelectListItem
            //{

            //    Text = x.text,
            //    Value = x.ID.ToString()

            //}).ToList();


            //var group1 = new SelectListGroup() { Name = "Group1" };
            //var group2 = new SelectListGroup() { Name = "Group2" };


            //ViewBag.language = new List<SelectListItem>()
            //{
            //    new SelectListItem (){Text="Benali", Value="1", Group=group1},
            //     new SelectListItem (){Text="English", Value="2", Group=group2},
            //      new SelectListItem (){Text="Hindi", Value="3", Group=group2},
            //       new SelectListItem (){Text="spanish", Value="4", Group=group1}

            //};


            ViewBag.language = new SelectList(ob2.getLanguage(), "ID", "text");

            if (ModelState.IsValid) // for serverside model validation
            {
                if(info.imge!=null)
                {
                    string folder = "Book Images/";
                    folder += Guid.NewGuid().ToString() + "_" + info.imge.FileName;
                    string serverfolder = Path.Combine(hostobj2.WebRootPath, folder);// create path of the image

                    info.imge.CopyTo(new FileStream(serverfolder, FileMode.Create));// store or copy into particular folder

                    string imgpath = "/" + folder; //for database store
                    info.ImagePath = imgpath;
                }

                

                var id = ob1.Addbook(info);

                if (id > 0)
                {
                    return RedirectToAction("getAllBook");

                }
                else
                {
                    return View();
                }



            }
            else
            {
                return View();
            }


            //return View();


        }
    }

    public interface IWebHostEnvironment
    {
    }
}
