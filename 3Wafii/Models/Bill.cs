//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _3Wafii.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bill
    {
        public int waiting_time { get; set; }
        public int bi_price { get; set; }
        public int bi_id { get; set; }
        public int bi_date { get; set; }
        public int del_id { get; set; }
        public int or_id { get; set; }
    
        public virtual DeliveryBoy DeliveryBoy { get; set; }
        public virtual Order Order { get; set; }
    }
}