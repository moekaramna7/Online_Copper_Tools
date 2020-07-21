using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Online_Copper_Tools_Project.Models
{
    public class Customer_Complaint
    {
        [Key]
        public int complaintId { get; set; }

        [ForeignKey("Customer")]
        public int customerId { get; set; }

        [ForeignKey("Cart")]
        public int cartId { get; set; }

        public string complaintMessage { get; set; }
        public bool isReplied { get; set; }

        public virtual Customer customer { get; set; }
    }
}