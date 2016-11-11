namespace RentalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reinit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Apartments", "IsAvailable", c => c.Boolean(nullable: false));
            AddColumn("dbo.Apartments", "DateAvailable", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tenants", "MoveOutDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Apartments", "RentPerMonth", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Apartments", "RentPerMonth", c => c.Double(nullable: false));
            DropColumn("dbo.Tenants", "MoveOutDate");
            DropColumn("dbo.Apartments", "DateAvailable");
            DropColumn("dbo.Apartments", "IsAvailable");
        }
    }
}
