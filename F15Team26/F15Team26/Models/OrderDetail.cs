using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace F15Team26.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderID { get; set; }
        public int BooksID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public virtual Books Book { get; set; }
        public virtual Orders Order { get; set; }
    }
}