using Microsoft.AspNetCore.Mvc;
using MVCTrial.BookRepositary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCTrial.MyViewComponent
{
    public class BookViewComponent : ViewComponent
    {

        private readonly IRepositaryDemo obj = null;

        public BookViewComponent(  IRepositaryDemo ob){

            obj = ob;

         }

         public async Task<IViewComponentResult> InvokeAsync(int count)
        {
            var   data = await obj.TopBook(count);
             return View(data);
        }
    }
}
