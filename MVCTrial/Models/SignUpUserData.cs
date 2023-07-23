using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVCTrial.Models
{
    public class SignUpUserData
    {
        [Required(ErrorMessage ="Please Enter your Email")]
        [Display(Name ="Email")]
        [EmailAddress(ErrorMessage = "Please Enter ProperEmail")]
         public string Email { get; set; }


        [Required(ErrorMessage = "Please Enter your Password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword",ErrorMessage ="Password Not matched")]
        public string Pasword { get; set; }


        [Required(ErrorMessage = "Please Enter your Password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }


        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DOB { get; set; }
    }
}
