using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibrarySystem.Models;
using LibraryDAL;

namespace LibrarySystem.Controllers
{
    public class LibraryController : Controller
    {
        
        public ActionResult LibraryInfo()
        {
            LibraryContext libraryContext = new LibraryContext();
            Library library = libraryContext.Library.FirstOrDefault();
            return View(library);
        }
    }
}