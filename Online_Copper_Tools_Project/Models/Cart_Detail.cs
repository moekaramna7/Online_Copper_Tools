using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_Copper_Tools_Project.Models
{
    public class Cart_Detail
    {
        [Key]
        public int cartDetailId { get; set; }
        public int cartId { get; set; }
        public int productId { get; set; }
        public int productQuantity { get; set; }
        public DateTime dateAdded { get; set; }
    }
}