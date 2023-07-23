using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MVCTrial.Models;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace MVCTrial.Helper
{
    public class MyCustomClaim : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        public MyCustomClaim(UserManager<ApplicationUser> usermanager, 
            RoleManager<IdentityRole> rolemanager, IOptions<IdentityOptions> options)
            :base(usermanager,rolemanager,options)
        {


        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var res= await base.GenerateClaimsAsync(user);

            res.AddClaim(new Claim("UserFirstName", user.FirstName));

            res.AddClaim(new Claim("UserLastName", user.LastName));

            return res;


        }

    }
}
