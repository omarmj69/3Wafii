using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3Wafii.Dtos
{
    public class CustmerDto
    {
        public int cus_id { get; set; }
        public string phone { get; set; }
        public string addresss { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string hash { get; set; }
        public string salt { get; set; }

    }
}