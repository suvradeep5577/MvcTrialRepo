using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
namespace MVCTrial.Helper
{
    public class MyCustomSevices : IMyCustomSevices
    {
        private readonly IHttpContextAccessor httpcon;

        public MyCustomSevices(IHttpContextAccessor httpcon2)
        {
            httpcon = httpcon2;

        }

        public string getuserid()
        {
            return httpcon.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }

    }
}
