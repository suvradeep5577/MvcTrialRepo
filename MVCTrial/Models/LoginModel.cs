using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVCTrial.Models
{
    public class LoginModel
    {

        [Required(ErrorMessage = "Please Enter your Email")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Please Enter ProperEmail")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Please Enter your Password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
       
        public string Pasword { get; set; }


        public bool RememberMe { get; set; }

    }
}
