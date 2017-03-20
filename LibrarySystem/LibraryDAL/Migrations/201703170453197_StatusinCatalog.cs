namespace LibraryDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StatusinCatalog : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Catalogs", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Catalogs", "Status");
        }
    }
}
