using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_Copper_Tools_Project.Models
{
    public class Customer_Complaint
    {
        [Key]
        public int complaintId { get; set; }
        public string customerEmail { get; set; }
        public string complaintMessage { get; set; }
    }
}