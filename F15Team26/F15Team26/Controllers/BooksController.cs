using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using F15Team26.Models;

namespace F15Team26.Controllers
{
    public class BooksController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Books
        public ActionResult Index()
        {
            return View(db.Books.ToList());
        }

        // GET: Books/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Books books = db.Books.Find(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UniqueNumber,AuthorFirst,AuthorLast,Title,Price,PublicationDate,PriceLastPaid,Inventory,ReorderPoint,Reviews,Ratings,Genre")] Books books)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(books);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(books);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Books books = db.Books.Find(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UniqueNumber,AuthorFirst,AuthorLast,Title,Price,PublicationDate,PriceLastPaid,Inventory,ReorderPoint,Reviews,Ratings,Genre")] Books books)
        {
            if (ModelState.IsValid)
            {
                db.Entry(books).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(books);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Books books = db.Books.Find(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Books books = db.Books.Find(id);
            db.Books.Remove(books);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        //public ActionResult Search()//no search parameters given
        //{
        //    return View(db.Song.ToList());
        //}

        public ActionResult Search(string searchTitle, SearchTypes? searchType, string searchAuthor, string searchUniqueNumber, string searchGenre, bool? ORSearch)
        {
            var books = from s in db.Books
                        select s;

            //books.Include(s => s.Author);
            if (ORSearch == false) //this is an AND search
            {
                if (String.IsNullOrEmpty(searchTitle) == false)
                {
                    if (searchType == SearchTypes.KEYWORD)
                    {
                        books = books.Where(s => s.Title.Contains(searchTitle));
                    }

                    else
                    {
                        books = books.Where(s => s.Title == searchTitle);
                    }
                }

                if (searchAuthor != null && searchAuthor != "") //there is something to search for in author
                {
                    books = books.Where(s => s.AuthorFirst == searchAuthor || s.AuthorLast == searchAuthor || s.AuthorFirst + s.AuthorLast == searchAuthor);
                }

            }
            else if (ORSearch == true) //this is an or search
            {
                if (searchType == SearchTypes.KEYWORD)
                {
                    books = books.Where(s => s.Title.Contains(searchTitle) || s.AuthorFirst == searchAuthor || s.AuthorLast == searchAuthor);
                }
                else if (searchType == SearchTypes.EXACT)
                {
                    books = books.Where(s => s.Title == searchTitle || s.AuthorFirst + s.AuthorLast == searchAuthor);
                }
                else if (searchType == SearchTypes.EXACT)
                {
                    books = books.Where(s => s.AuthorFirst == searchAuthor);
                }
                else if (searchType == SearchTypes.EXACT)
                {
                    books = books.Where(s => s.AuthorLast == searchAuthor);
                }
                ////else if (searchType == SearchTypes.EXACT)
                //{
                //    books = books.Where(s => s.UniqueNumber == searchUniqueNumber);
                //}
                //else if (searchType == SearchTypes.KEYWORD)
                //{
                //    books = books.Where(s => s.UniqueNumber.Contains(searchUniqueNumber));
                //}
                else if (searchType == SearchTypes.EXACT)
                {
                    books = books.Where(s => s.Genre == searchGenre);
                }

            }

            //ViewBag.AllBooks = UpdateBooks.GetAllBooksWithAll(db);
            return View(books.ToList());






        }
    }
}
