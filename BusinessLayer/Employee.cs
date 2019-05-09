using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{
    public class Employee
    {
        public int Id { get; set; }

        [Required , StringLength(20 , MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public string Gender { get; set; }

        public string City { get; set; }

        [DataType(DataType.Date),DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DateOfBirth { get; set; }

        [Required , DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required , DataType(DataType.Password)]
        public string Password { get; set; }

        [Required , DataType(DataType.Password) , Compare("Password") ,
         Display(Name = "Confirm Password")]
        public string confirmPass {get; set;}
    }
}
