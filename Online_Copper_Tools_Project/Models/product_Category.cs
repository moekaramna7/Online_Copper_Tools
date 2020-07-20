using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_Copper_Tools_Project.Models
{
    public class Product_Category
    {
        [Key]
        public int categoryId { get; set; }
        public string categoryName { get; set; }
    }
}