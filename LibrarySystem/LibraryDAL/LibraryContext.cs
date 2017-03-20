using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LibraryDAL
{
   public class LibraryContext:DbContext
    {
        public LibraryContext():base("name=LibraryContext")
        {
            Database.SetInitializer<LibraryContext>(new DropCreateDatabaseIfModelChanges<LibraryContext>());
        }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Catalog> Catalogs { get; set; }
        public virtual DbSet<Library> Library { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Transaction>()
    .HasRequired<Library>(l => l.Library)
    .WithMany(l => l.Transactions)
    .HasForeignKey(i => i.LibraryId)
    .WillCascadeOnDelete(true);

            modelBuilder.Entity<Transaction>()
   .HasRequired<Catalog>(l => l.Catalog)
   .WithMany(l => l.Transactions)
   .HasForeignKey(i => i.BookId)
   .WillCascadeOnDelete(true);

            modelBuilder.Entity<Transaction>()
   .HasRequired<Customer>(l => l.Customer)
   .WithMany(l => l.Transactions)
   .HasForeignKey(i => i.CustomerId)
   .WillCascadeOnDelete(true);
          
        }
    }
}
