using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _3Wafii.Dtos
{
    public class MealsDto
    {
        [Required]
        [DataType(DataType.PhoneNumber, ErrorMessage = "id must be a number")]
        public int m_id { get; set; }
        [Required]
        public string image { get; set; }
        [Required]
        [Range(100, 30000, ErrorMessage = "Price must be between 100 and 30000")]
        public int price { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber, ErrorMessage = "count must be a number")]
        public int m_count { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string m_name { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string Description { get; set; }

    }
}