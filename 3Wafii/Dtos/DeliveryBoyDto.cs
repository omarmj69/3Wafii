using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _3Wafii.Dtos
{
    public class DeliveryBoyDto
    {
        [Required]
        public int del_id { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber, ErrorMessage = "phone must be a number")]
        public string phone { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]

        public string username { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber, ErrorMessage = "id must be a number")]
        public int u_id { get; set; }

    }
}