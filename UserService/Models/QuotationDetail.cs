using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserService.Models
{
    public class QuotationDetail
    {
        public int quotationDetailId { get; set; }
        public int quotationId { get; set; }
        public int productId { get; set; }
        public string name { get; set; }
        public decimal unitPrice { get; set; }
        public decimal supplierDiscount { get; set; }
        public int quantity { get; set; }
        public decimal? requestDiscount { get; set; }
    }
}