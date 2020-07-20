using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_Copper_Tools_Project.Models
{
    public class Cart
    {
        [Key]
        public int cartId { get; set; }
        public int customerId { get; set; }
        public DateTime datePlaced { get; set; }
    }
}