using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static Online_Copper_Tools_Project.Tools.Enums;

namespace Online_Copper_Tools_Project.Models
{
    public class Product
    {
        [Key]
        public int productId { get; set; }
        public string productName { get; set; }
        public string productCategory { get; set; }
        public virtual productSize? productSize { get; set; }
        public decimal productPrice { get; set; }
        public int productDiscount { get; set; }
    }
}