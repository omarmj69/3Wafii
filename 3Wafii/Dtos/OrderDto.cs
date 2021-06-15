using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3Wafii.Dtos
{
    public class OrderDto
    {
        public int or_id { get; set; }
        public int total_price { get; set; }
        public int or_count { get; set; }
        public int cus_id { get; set; }

    }
}