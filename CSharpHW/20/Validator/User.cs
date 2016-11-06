using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace RegistrationForm
{
    class User
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z\s]{1,255}$",
         ErrorMessage = "Only letters are allowed at first name field (length: 1-255)")]
        public string FirstName{get; set;}
        
        [Required]
        [RegularExpression(@"^[a-zA-Z\s]{1,255}$",
         ErrorMessage = "Only letters are allowed at last name field (length: 1-255)")]
        public string LastName{get; set;}

        [Range(1,31)]
        public int BirthDay { get; set; }
        
        [Range(1,12)]
        public int BirthMonth { get; set; }
        
        [YearValidation]
        public int BirthYear { get; set; }

        [RegularExpression(@"^((M|m)ale)|((F|f)emale)$",
         ErrorMessage = "Only 'male' or 'female' is allowed at gender field")]
        public string Gender { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Phone]
        [StringLength(12, MinimumLength = 12)]
        public string PhoneNumber { get; set; }
        
        [StringLength(2000)]
        public string AdditionalInfo { get; set; }
    }
}
