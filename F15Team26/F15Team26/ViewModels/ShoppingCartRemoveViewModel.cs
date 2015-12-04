using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using F15Team26.Models;

namespace F15Team26.ViewModels
{
    public class ShoppingCartRemoveViewModel
    {
        public string Message { get; set; }
        public decimal CartTotal { get; set; }
        public int CartCount { get; set; }
        public int ItemCount { get; set; }
        public int DeleteId { get; set; }
    }
}