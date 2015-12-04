using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace F15Team26.Models
{
    public partial class ShoppingCart
    {
        AppDbContext storeDB = new AppDbContext();

        public string ShoppingCartID { get; set; }
        public const string CartSessionKey = "CartID";

        //static method which allows our controllers to obtain a cart object. It uses the GetCartId method to handle reading the CartId from the user’s session. The GetCartId method requires the HttpContextBase so that it can read the user’s CartId from user’s session.
        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartID = cart.GetCartID(context);
            return cart;
        }
        // Helper method to simplify shopping cart calls
        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }

        //takes an Album as a parameter and adds it to the user’s cart. Since the Cart table tracks quantity for each album, it includes logic to create a new row if needed or just increment the quantity if the user has already ordered one copy of the album.
        public void AddToCart(Books book)
        {
            // Get the matching cart and Books instances
            var cartItem = storeDB.Cart.SingleOrDefault(c => c.CartID.Equals(ShoppingCartID) && c.BooksID == book.BooksID);
            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists
                cartItem = new Cart
                {
                    BooksID = book.BooksID,
                    CartID = Convert.ToInt32(ShoppingCartID),
                    Count = 1,
                    //DateCreated = DateTime.Now
                };
                storeDB.Cart.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart, then add one to the quantity
                cartItem.Count++;
            }
            // Save changes
            storeDB.SaveChanges();
        }
        public int RemoveFromCart(int id)
        {
            // Get the cart
            var cartItem = storeDB.Cart.Single(cart => cart.CartID.Equals(ShoppingCartID) && cart.RecordID == id);
            int itemCount = 0;
            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                }
                else
                {
                    storeDB.Cart.Remove(cartItem);
                }
                // Save changes
                storeDB.SaveChanges();
            }
            return itemCount;
        }

        //empty cart 
        public void EmptyCart()
        {
            var cartItems = storeDB.Cart.Where(cart => cart.CartID.Equals(ShoppingCartID));
            foreach (var cartItem in cartItems)
            {
                storeDB.Cart.Remove(cartItem);
            }
            // Save changes
            storeDB.SaveChanges();
        }

        //retrieves a list of CartItems for display or processing 
        public List<Cart> GetCartItems()
        {
            return storeDB.Cart.Where(cart => cart.CartID.ToString() == ShoppingCartID).ToList();
        }

        //retrieves the total number of albums a user has in their shopping cart 
        public int GetCount()
        {
            // Get the count of each item in the cart and sum them up
            int? count = (from cartItems in storeDB.Cart
                          where cartItems.CartID.Equals(ShoppingCartID)
                          select (int?)cartItems.Count).Sum();
            // Return 0 if all entries are null
            return count ?? 0;
        }

        // Multiply book price by count of that book then add all books' totals to get the cart total
        public decimal GetTotal()
        {
            decimal? total = (from cartItems in storeDB.Cart
                              where cartItems.CartID.ToString().Equals(ShoppingCartID)
                              select (int?)cartItems.Count * cartItems.Books.Price).Sum();
            return total ?? decimal.Zero;
        }

        //converts the shopping cart to an order during the checkout phase
        public int CreateOrder(Orders order)
        {
            decimal orderTotal = 0;
            var cartItems = GetCartItems();
            // Iterate over the items in the cart, adding the order details for each
            foreach (var item in cartItems)
            {
                var orderDetail = new OrderDetail
                {
                    BooksID = item.BooksID,
                    OrderID = order.OrdersID,
                    UnitPrice = item.Books.Price,
                    Quantity = item.Count
                };
                // Set the order total of the shopping cart
                orderTotal += (item.Count * item.Books.Price);
                storeDB.OrderDetail.Add(orderDetail);
            }
            // Set the order's total to the orderTotal count
            order.Total = orderTotal;
            // Save the order
            storeDB.SaveChanges();
            // Empty the shopping cart
            EmptyCart();
            // Return the OrderId as the confirmation number
            return order.OrdersID;
        }

        // We're using HttpContextBase to allow access to cookies.
        public string GetCartID(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] = context.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class
                    Guid tempCartID = Guid.NewGuid();
                    // Send tempCartID back to client as a cookie
                    context.Session[CartSessionKey] = tempCartID.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }
        // When a user has logged in, migrate their shopping cart to
        // be associated with their username
        public void MigrateCart(string userName)
        {
            var shoppingCart = storeDB.Cart.Where(c => c.CartID.Equals(ShoppingCartID));
            foreach (Cart item in shoppingCart)
            {
                item.CartID = Convert.ToInt32(userName);
            }
            storeDB.SaveChanges();
        }
    }
}





//public class ShoppingCart
//{
//    public int ShoppingCartID { get; set; }

//    public virtual List<Books> Books { get; set; }

//    public virtual List<Customers> Customer { get; set; }

//    public Decimal FirstBookShipping
//    {
//        get
//        {
//            return FirstBookShipping;
//        }
//        set
//        {
//            FirstBookShipping = 3.50M;
//        }
//    }

//    public Decimal AdditionalBookShipping
//    {
//        get
//        {
//            return AdditionalBookShipping;
//        }
//        set
//        {
//            AdditionalBookShipping = 1.50M;
//        }
//    }

//    public Decimal SubTotal { get; set; }

//    public Decimal Total { get; set; }
//}
    
