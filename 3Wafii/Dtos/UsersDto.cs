using _3Wafii.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _3Wafii.Dtos
{
    public class UsersDto
    {

        [Required]
        [DataType(DataType.PhoneNumber,ErrorMessage ="id must be a number")]
        public int u_id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string u_name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        [Range(1,2,ErrorMessage = "constraint must be 1 to system manger or 2 to resturant manger")]
        public string constraint { get; set; }
        public string salt { get; set; }

    }
}