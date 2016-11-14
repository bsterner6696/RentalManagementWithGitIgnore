namespace RentalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedleasepdffilenametotenant : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tenants", "LeasePdfFileName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tenants", "LeasePdfFileName");
        }
    }
}
