using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserService.Models
{
    public class Order
    {
        public int orderId { get; set; }
        public int supplierId {  get; set; }
        public string supplierName { get; set; }
        public DateTime orderDate { get; set; }
        public decimal totalAmount { get; set; }
    }
}