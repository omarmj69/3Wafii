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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class db_a72f14_fooddelivery02Entities : DbContext
    {
        public db_a72f14_fooddelivery02Entities()
            : base("name=db_a72f14_fooddelivery02Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Complaint> Complaints { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<DeliveryBoy> DeliveryBoys { get; set; }
        public virtual DbSet<Meal> Meals { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Resturant> Resturants { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
