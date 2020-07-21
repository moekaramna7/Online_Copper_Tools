using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_Copper_Tools_Project.Models
{
    public class Customer
    {
        [Key]
        public int customerId { get; set; }
        public string customerFullName { get; set; }
        public string customerEmail { get; set; }
        public string customerPassword { get; set; }
        public string customerPhoneNumber { get; set; }

        public virtual Customer_Address customerAddress { get; set; }
    }
}