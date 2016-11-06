using System;
using System.ComponentModel.DataAnnotations;

namespace RegistrationForm
{
    [AttributeUsage(AttributeTargets.Property)]
    class YearValidationAttribute : ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            int year;
            try
            {
                year = (int)value;
            } catch (Exception)
            {
                ErrorMessage = "Year should be int!";
                return false;
            }
            
            
            if ((year<1900)||(year>=DateTime.Now.Year))
            {
                ErrorMessage = "Year should be > 1990 and < current year.";
                return false;
            }

            return true;
        }
    }
}
