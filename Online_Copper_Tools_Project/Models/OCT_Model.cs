using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Online_Copper_Tools_Project.Models
{
    public class OCT_Model : DbContext
    {
        public OCT_Model()
            : base("name=OCT_Model")
        {
        }

        public DbSet<Product_Category> productCategories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Customer_Complaint> customerCompaints { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Cart> carts { get; set; }
        public DbSet<Cart_Detail> cartDetails { get; set; }
        public DbSet<Customer_Address> customersAddress { get; set; }
        public DbSet<Admin> admins { get; set; }
    }
}