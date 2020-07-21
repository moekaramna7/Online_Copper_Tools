using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Online_Copper_Tools_Project.Models
{
    public class Cart
    {
        [Key]
        public int cartId { get; set; }
        [ForeignKey("Customer")]
        public int customerId { get; set; }
        public virtual Cart_Detail cartDetail { get; set; }
        public DateTime datePlaced { get; set; }
    }
}