using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using F15Team26.Models;
using F15Team26.ViewModels;

namespace F15Team26.Controllers
{
    public class ShoppingCartController : Controller
    {

        AppDbContext storeDB = new AppDbContext();

        // GET: ShoppingCart
        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };
            // Return the view
            return View(viewModel);
        }
        //
        // GET: /Store/AddToCart/5

        public ActionResult AddToCart(int id)
        {
            // Retrieve the album from the database
            var addedBook = storeDB.Books.Single(Books => Books.BooksID == id);
            // Add it to the shopping cart
            var cart = ShoppingCart.GetCart(this.HttpContext);
            cart.AddToCart(addedBook);
            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // Remove the item from the cart
            var cart = ShoppingCart.GetCart(this.HttpContext);
            // Get the name of the book to display confirmation
            string bookName = storeDB.Cart.Single(item => item.RecordID == id).Books.Title;
            // Remove from cart
            int itemCount = cart.RemoveFromCart(id);
            // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(bookName) +
                " has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }

        //
        // GET: /ShoppingCart/CartSummary
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }



        // GET: ShoppingCart/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingCart shoppingCart = storeDB.ShoppingCart.Find(id);
            if (shoppingCart == null)
            {
                return HttpNotFound();
            }
            return View(shoppingCart);
        }

        // GET: ShoppingCart/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShoppingCart/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShoppingCartID,TotalAmount,FirstBookShipping,AdditionalBookShipping")] ShoppingCart shoppingCart)
        {
            if (ModelState.IsValid)
            {
                storeDB.ShoppingCart.Add(shoppingCart);
                storeDB.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shoppingCart);
        }

        // GET: ShoppingCart/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingCart shoppingCart = storeDB.ShoppingCart.Find(id);
            if (shoppingCart == null)
            {
                return HttpNotFound();
            }
            return View(shoppingCart);
        }

        // POST: ShoppingCart/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShoppingCartID,TotalAmount,FirstBookShipping,AdditionalBookShipping")] ShoppingCart shoppingCart)
        {
            if (ModelState.IsValid)
            {
                storeDB.Entry(shoppingCart).State = EntityState.Modified;
                storeDB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shoppingCart);
        }

        // GET: ShoppingCart/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingCart shoppingCart = storeDB.ShoppingCart.Find(id);
            if (shoppingCart == null)
            {
                return HttpNotFound();
            }
            return View(shoppingCart);
        }

        // POST: ShoppingCart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShoppingCart shoppingCart = storeDB.ShoppingCart.Find(id);
            storeDB.ShoppingCart.Remove(shoppingCart);
            storeDB.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                storeDB.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
