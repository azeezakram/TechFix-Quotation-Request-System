using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserService.Models
{
    public class Product
    {
        public int productId { get; set; }
        public int supplierId { get; set; }
        public string name { get; set; }
        public int stock { get; set; }
        public double unitPrice { get; set; }
        public double discount { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; } 
    }

}