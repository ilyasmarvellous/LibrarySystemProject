namespace LibraryDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteonCascade : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "BookId", "dbo.Catalogs");
            DropForeignKey("dbo.Customers", "LibraryId", "dbo.Libraries");
            DropForeignKey("dbo.Catalogs", "LibraryId", "dbo.Libraries");
            DropForeignKey("dbo.Transactions", "BookId", "dbo.Catalogs");
            DropForeignKey("dbo.Transactions", "LibraryId", "dbo.Libraries");
            DropForeignKey("dbo.Transactions", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Catalogs", new[] { "LibraryId" });
            DropIndex("dbo.Customers", new[] { "LibraryId" });
            DropIndex("dbo.Customers", new[] { "BookId" });
            AddForeignKey("dbo.Transactions", "BookId", "dbo.Catalogs", "BookId", cascadeDelete: true);
            AddForeignKey("dbo.Transactions", "LibraryId", "dbo.Libraries", "LibraryId", cascadeDelete: true);
            AddForeignKey("dbo.Transactions", "CustomerId", "dbo.Customers", "CustomerId", cascadeDelete: true);
            DropColumn("dbo.Catalogs", "LibraryId");
            DropColumn("dbo.Customers", "LibraryId");
            DropColumn("dbo.Customers", "BookId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "BookId", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "LibraryId", c => c.Int(nullable: false));
            AddColumn("dbo.Catalogs", "LibraryId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Transactions", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Transactions", "LibraryId", "dbo.Libraries");
            DropForeignKey("dbo.Transactions", "BookId", "dbo.Catalogs");
            CreateIndex("dbo.Customers", "BookId");
            CreateIndex("dbo.Customers", "LibraryId");
            CreateIndex("dbo.Catalogs", "LibraryId");
            AddForeignKey("dbo.Transactions", "CustomerId", "dbo.Customers", "CustomerId");
            AddForeignKey("dbo.Transactions", "LibraryId", "dbo.Libraries", "LibraryId");
            AddForeignKey("dbo.Transactions", "BookId", "dbo.Catalogs", "BookId");
            AddForeignKey("dbo.Catalogs", "LibraryId", "dbo.Libraries", "LibraryId");
            AddForeignKey("dbo.Customers", "LibraryId", "dbo.Libraries", "LibraryId");
            AddForeignKey("dbo.Customers", "BookId", "dbo.Catalogs", "BookId", cascadeDelete: true);
        }
    }
}
