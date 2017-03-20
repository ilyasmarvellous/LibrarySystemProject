using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibrarySystem.Models;
using LibraryDAL;
using System.Data.Entity;
using LibrarySystem;

namespace LibrarySystem.Controllers
{
    [Log]
    
    public class CustomerController : Controller
    {
        public ActionResult Details()
        {
            LibraryContext libraryContext = new LibraryContext();
            List<Customer> customer = libraryContext.Customers.ToList();
            
            return View(customer);
            
        }

        public ActionResult DetailsById(int id)
        {
            LibraryContext libraryContext = new LibraryContext();
            Customer customer= libraryContext.Customers.Single(cu=>cu.CustomerId==id);
            return View(customer);
        }

        [HttpGet]
        public ViewResult Create()
        {
                      return View();
        }
        [Log]
        [HttpPost] //strongly typed view model comes from view 
        public ActionResult CreateCustomer(Customer cust)
        {
            LibraryContext libraryContext = new LibraryContext();
            libraryContext.Customers.Add(cust);
            libraryContext.SaveChanges();

            return RedirectToAction("Details");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            LibraryContext libraryContext = new LibraryContext();

           Customer customer= libraryContext.Customers.Single(c => c.CustomerId == id);
            
            return View(customer);
        }

        [HttpPost] //strongly typed view model comes from view 
        public ActionResult EditCustomer(Customer cust)
        {
            LibraryContext libraryContext = new LibraryContext();
            libraryContext.Entry(cust).State = EntityState.Modified;
            libraryContext.SaveChanges();

            return RedirectToAction("Details");
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            LibraryContext libraryContext = new LibraryContext();

            Customer customer = libraryContext.Customers.Single(c => c.CustomerId == id);

            return View(customer);
        }

        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteCustomer(int id)
        {
            LibraryContext libraryContext = new LibraryContext();
            Customer cust=  libraryContext.Customers.Where(c=> c.CustomerId == id).FirstOrDefault();
            libraryContext.Customers.Remove(cust);
            libraryContext.SaveChanges();
            
            return RedirectToAction("Details");
        }

    }
}