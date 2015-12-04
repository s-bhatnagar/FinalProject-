using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

//This class tracks summary and delivery information for an order

namespace F15Team26.Models
{
    public partial class Orders
    {
        public int OrdersID { get; set; }

        
        public virtual List<Customers> Customer { get; set; }

       
        public String UniqueNumber { get; set; }
       
        [Required]
        public Decimal Total { get; set; }

        //public DateTime Date { get; set; }
        public System.DateTime OrderDate { get; set; }


        public List<OrderDetail> OrderDetails { get; set; }

    }
}