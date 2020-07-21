using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_Copper_Tools_Project.Models
{
    public class Admin
    {
        [Key]
        public int adminId { get; set; }
        public string adminFullName { get; set; }
        public string adminEmail { get; set; }
        public string adminPassword { get; set; }
        public string adminPhoneNumber { get; set; }
    }
}