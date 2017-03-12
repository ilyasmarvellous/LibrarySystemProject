using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Models;

namespace LibraryDAL
{
    class CatalogRepo
    {
        private LibraryContext context;
        public CatalogRepo()
        {
            context = new LibraryContext();
        }
       //CREATE operation
        public Catalog GetBookById(int BookId)
        {
            Catalog catalog = context.Catalogs.Where(c => c.BookId == BookId).FirstOrDefault();
            return catalog;
        }

        //Insert

        public void InsertCatalog(Catalog catalog)
        {
            context.Catalogs.Add(catalog);
            context.SaveChanges();
        }

    //Update
     public void UpdateCatalog(Catalog catalog)
        {
            Catalog update = context.Catalogs.Where(ct => ct.BookId == catalog.BookId).FirstOrDefault();
            context.SaveChanges();
        }
    }
}
