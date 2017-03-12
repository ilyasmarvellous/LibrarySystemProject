using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Models;

namespace LibraryDAL
{
    class LibraryRepo
    {
        private LibraryContext context;
        public LibraryRepo()
        {
            context = new LibraryContext();
        }
        //CRUD Operations

        public Library GetByLibraryId(int LibraryId)
        {
            Library library = context.Library.Where(s => s.LibraryId == LibraryId).FirstOrDefault();
            return library;
        }

        public void InsertLibrary(Library library)
        {
            context.Library.Add(library);
            context.SaveChanges();
        }

        public void UpdateLibrary(Library library)
        {
            Library update = context.Library.Where(p => p.LibraryId == library.LibraryId).FirstOrDefault();
            context.SaveChanges();
        }

        public void DeleteLibrary(Library library)
        {
            context.Library.Remove(library);
            context.SaveChanges();
        }
    }
}
