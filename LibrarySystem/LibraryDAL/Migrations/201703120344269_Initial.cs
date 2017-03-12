namespace LibraryDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Catalogs",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Author = c.String(),
                        price = c.Int(nullable: false),
                        LibraryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.Libraries", t => t.LibraryId)
                .Index(t => t.LibraryId);
            
            CreateTable(
                "dbo.Libraries",
                c => new
                    {
                        LibraryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.LibraryId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.Double(nullable: false),
                        Address = c.String(),
                        LibraryId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.Catalogs", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Libraries", t => t.LibraryId)
                .Index(t => t.LibraryId)
                .Index(t => t.BookId);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionId = c.Int(nullable: false, identity: true),
                        DateOfIssue = c.DateTime(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                        LibraryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionId)
                .ForeignKey("dbo.Catalogs", t => t.BookId)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.Libraries", t => t.LibraryId)
                .Index(t => t.CustomerId)
                .Index(t => t.BookId)
                .Index(t => t.LibraryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Catalogs", "LibraryId", "dbo.Libraries");
            DropForeignKey("dbo.Transactions", "LibraryId", "dbo.Libraries");
            DropForeignKey("dbo.Transactions", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Transactions", "BookId", "dbo.Catalogs");
            DropForeignKey("dbo.Customers", "LibraryId", "dbo.Libraries");
            DropForeignKey("dbo.Customers", "BookId", "dbo.Catalogs");
            DropIndex("dbo.Transactions", new[] { "LibraryId" });
            DropIndex("dbo.Transactions", new[] { "BookId" });
            DropIndex("dbo.Transactions", new[] { "CustomerId" });
            DropIndex("dbo.Customers", new[] { "BookId" });
            DropIndex("dbo.Customers", new[] { "LibraryId" });
            DropIndex("dbo.Catalogs", new[] { "LibraryId" });
            DropTable("dbo.Transactions");
            DropTable("dbo.Customers");
            DropTable("dbo.Libraries");
            DropTable("dbo.Catalogs");
        }
    }
}
