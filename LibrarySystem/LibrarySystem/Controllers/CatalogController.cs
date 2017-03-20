using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibrarySystem.Models;
using LibraryDAL;
using System.Data.Entity;

namespace LibrarySystem.Controllers
{
    public class CatalogController : Controller
    {
        
        public ActionResult Details()
        {
            LibraryContext libraryContext = new LibraryContext();
           List<Catalog> catalogs= libraryContext.Catalogs.Where(ca => ca.Status == "Available").ToList();
            return View(catalogs);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCatalog(Catalog cata)
        {
            LibraryContext libraryContext = new LibraryContext();
            libraryContext.Catalogs.Add(cata);
            libraryContext.SaveChanges();
            return RedirectToAction("Details");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            LibraryContext libraryContext = new LibraryContext();

            Catalog catalog = libraryContext.Catalogs.Single(c => c.BookId == id);

            return View(catalog);
        }

        [HttpPost] //strongly typed view model comes from view 
        public ActionResult EditCatalog(Catalog cata)
        {
            LibraryContext libraryContext = new LibraryContext();
            libraryContext.Entry(cata).State = EntityState.Modified;
            libraryContext.SaveChanges();

            return RedirectToAction("Details");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            LibraryContext libraryContext = new LibraryContext();

            Catalog catalog = libraryContext.Catalogs.Single(c => c.BookId == id);

            return View(catalog);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteCatalog(int id)
        {
            LibraryContext libraryContext = new LibraryContext();
            Catalog cata = libraryContext.Catalogs.Where(c => c.BookId == id).FirstOrDefault();
            libraryContext.Catalogs.Remove(cata);
            libraryContext.SaveChanges();

            return RedirectToAction("Details");
        }
    }
}