using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace F15Team26.Models
{
    public class Suppliers
    {
        public int SuppliersID { get; set; }

        [Required]
        public String SupplierName { get; set; }
        
        [Required]
        public int OrderAmount { get; set; }
    }
}