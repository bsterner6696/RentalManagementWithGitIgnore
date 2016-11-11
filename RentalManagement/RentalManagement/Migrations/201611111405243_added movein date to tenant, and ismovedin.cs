namespace RentalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedmoveindatetotenantandismovedin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tenants", "MoveInDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tenants", "OccupyingApartment", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tenants", "Balance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tenants", "Balance", c => c.Double(nullable: false));
            DropColumn("dbo.Tenants", "OccupyingApartment");
            DropColumn("dbo.Tenants", "MoveInDate");
        }
    }
}
