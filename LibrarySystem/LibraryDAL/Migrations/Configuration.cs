namespace LibraryDAL.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LibraryDAL.LibraryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LibraryDAL.LibraryContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var CustomerList = new List<Customer>()
            {
                new Customer {CustomerId=1,FirstName="Virat",LastName="Kohli",Email="vk@gmail.com",PhoneNumber=9963487077,Address = "Dallas"},
                new Customer {CustomerId=2,FirstName="MS",LastName="Dhoni",Email="ms@gmail.com",PhoneNumber=9975487077,Address = "Ranch"},
                new Customer {CustomerId=3,FirstName="Rahul",LastName="Dravid",Email="vk@gmail.com",PhoneNumber=9234567765,Address = "Banglore"},
                new Customer {CustomerId=4,FirstName="Sachin",LastName="Tendu",Email="vk@gmail.com",PhoneNumber=9346630434,Address = "Hyd"},
                new Customer {CustomerId=5,FirstName="Rajesh",LastName="Rahul",Email="kl@gmail.com",PhoneNumber=9963446998,Address = "Delhi"}
               };
            CustomerList.ForEach(s => context.Customers.Add(s));

            var CatalogList = new List<Catalog>()
            {
                new Catalog {BookId=201,Name="GameOfThrones",Author="RRMartin",price=500,Status="Available"},
                new Catalog {BookId=202,Name="PrisonBreak",Author="Michael",price=550,Status="Available"},
                new Catalog {BookId=203,Name="StrangerThings",Author="Natalie",price=400,Status="Available"},
                new Catalog {BookId=204,Name="WalkingDead",Author="Sara",price=700,Status="Available"},
                new Catalog {BookId=205,Name="BigBangThoery",Author="Penny",price=500,Status="Available"}
            };
            CatalogList.ForEach(p => context.Catalogs.Add(p));

            var LibraryData = new List<Library>()
            {
                new Library {LibraryId=101, Name ="StarkLibrary",Address="Irving",PhoneNumber=2165719138 }
            };
            LibraryData.ForEach(l => context.Library.Add(l));

            var TransactionList = new List<Transaction>()
            {
                new Transaction {TransactionId=333,DateOfIssue=new DateTime(2017,01,02),CustomerId=1,BookId=201,LibraryId=101 },
                new Transaction {TransactionId=334,DateOfIssue=new DateTime(2017,06,09),CustomerId=2,BookId=202,LibraryId=101 },
                new Transaction {TransactionId=335,DateOfIssue=new DateTime(2016,11,12),CustomerId=3,BookId=203,LibraryId=101 },
                new Transaction {TransactionId=336,DateOfIssue=new DateTime(2017,03,08),CustomerId=4,BookId=204,LibraryId=101 },
                new Transaction {TransactionId=337,DateOfIssue=new DateTime(2017,07,09),CustomerId=5,BookId=205,LibraryId=101 }
            };
            TransactionList.ForEach(t => context.Transactions.Add(t));
        }
    }
 }
