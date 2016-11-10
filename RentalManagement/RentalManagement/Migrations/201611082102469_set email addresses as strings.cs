namespace RentalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setemailaddressesasstrings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PropertyManagers", "EmailAddress", c => c.String());
            AddColumn("dbo.Tenants", "EmailAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tenants", "EmailAddress");
            DropColumn("dbo.PropertyManagers", "EmailAddress");
        }
    }
}
