using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MVCTrial.Helper;
using Microsoft.AspNetCore.Http;

namespace MVCTrial.Models
{
    public class BookModel
    {
        public int ID { get; set; }

        [StringLength(500,MinimumLength =5)]
        [Required (ErrorMessage ="Please Enter author name")]
        public string author { get; set; }


        [StringLength(500, MinimumLength = 5)]
        [Required(ErrorMessage = "Please Enter title")]

        [MyCustomValidation(ErrorMessage ="Does not match with contain mvc")]
        public string title { get; set; }

        
        [DataType(DataType.EmailAddress)]
        [Display(Name ="Email Address")]
        [Required(ErrorMessage ="Please enter Email ")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please select a language")]
        public string Language { get; set; }


        
        public List<string> MultiLanguage { get; set; }


        [Display(Name ="Book Image")]
        public IFormFile imge { get; set; }

        //[Required(ErrorMessage = "Please select a language")]
        //public int Language { get; set; }

        public string ImagePath { get; set; }

    }
}
