using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVCTrial.Helper
{
    public class MyCustomValidation : ValidationAttribute

    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if(value!=null)
            {
                var stng = value.ToString();
                if(stng.Contains("Demo"))
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult(ErrorMessage ?? "Book name doe not contain deire value");
        }
    }
}
