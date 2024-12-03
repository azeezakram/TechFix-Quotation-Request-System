using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserService.Models
{
    public class Quotation
    {
        public int quotationId { get; set; }
        public int supplierId { get; set; }
        public string supplierName { get; set; }
        public DateTime requestDate { get; set; }
        public DateTime? approveDate { get; set; }
        

    }
}