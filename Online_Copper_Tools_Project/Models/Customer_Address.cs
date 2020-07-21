using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Online_Copper_Tools_Project.Models
{
    public class Customer_Address
    {
        [ForeignKey("Customer")]
        public int customerAddressId { get; set; }

        public string customerAddress { get; set; }
        public string customerCity { get; set; }
        public string customerStreet { get; set; }
        public int customerZipcode { get; set; }

        public virtual Customer customer { get; set; }
    }
}