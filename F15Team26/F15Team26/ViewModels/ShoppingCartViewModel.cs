using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using F15Team26.Models;

namespace F15Team26.ViewModels
{
    public class ShoppingCartViewModel
    {
        //list of items in the cart
        public List<Cart> CartItems { get; set; }
        //decimal value to hold the total price for all items in the cart 
        public decimal CartTotal { get; set; }
    }
}