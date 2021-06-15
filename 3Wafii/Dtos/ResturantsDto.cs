using _3Wafii.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _3Wafii.Dtos
{
    public class ResturantsDto
    {
        [Required]
        public string image { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]

        public string address { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string rest_name { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber, ErrorMessage = "must be a number")]
        [StringLength(14, MinimumLength = 7, ErrorMessage = "Number should be between 7 and 14 numbers")]
        public string phone { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber, ErrorMessage = "id must be a number")]
        public int rest_id { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber, ErrorMessage = "id must be a number")]
        public int u_id { get; set; }
        public string geo_location_latitude { get; set; }
        public string geo_location_longitude { get; set; }


    }
}