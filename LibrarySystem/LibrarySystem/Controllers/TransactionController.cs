using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibrarySystem.Models;
using LibraryDAL;
namespace LibrarySystem.Controllers
{
    public class TransactionController : Controller
    {

        public ActionResult Details()
        {
            LibraryContext libraryContext = new LibraryContext();
            List<Transaction> transactions = libraryContext.Transactions.ToList();
            return View(transactions);
        }

        [HttpGet]
        public ActionResult Create(Transaction transaction)
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult CreateTransaction(Transaction transaction)
        {
            LibraryContext libraryContext = new LibraryContext();
            libraryContext.Transactions.Add(transaction);

            Catalog book = libraryContext.Catalogs.Where(c => c.BookId == transaction.BookId).FirstOrDefault();
            book.Status = "Unavailable";
            libraryContext.Entry(book).State = System.Data.Entity.EntityState.Modified;

            libraryContext.SaveChanges();
            return RedirectToAction("Details");

        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            LibraryContext libraryContext = new LibraryContext();
           Transaction t= libraryContext.Transactions.Where(c => c.TransactionId == id).FirstOrDefault();
            return View(t);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteTransaction(int id)
        {
            LibraryContext libraryContext = new LibraryContext();
           Transaction tran= libraryContext.Transactions.Where(t=>t.TransactionId==id).FirstOrDefault();
           Catalog cata= libraryContext.Catalogs.Where(c => c.BookId == tran.BookId).FirstOrDefault();
            cata.Status = "Available";
            libraryContext.Transactions.Remove(tran);
            libraryContext.SaveChanges();
            return RedirectToAction("Details");
           
        }
    }
}