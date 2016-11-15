namespace RentalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedscheduletable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Schedules", "ApartmentId", "dbo.Apartments");
            DropIndex("dbo.Schedules", new[] { "ApartmentId" });
            AddColumn("dbo.Schedules", "Apartment", c => c.String());
            DropColumn("dbo.Schedules", "ApartmentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Schedules", "ApartmentId", c => c.Int(nullable: false));
            DropColumn("dbo.Schedules", "Apartment");
            CreateIndex("dbo.Schedules", "ApartmentId");
            AddForeignKey("dbo.Schedules", "ApartmentId", "dbo.Apartments", "Id", cascadeDelete: true);
        }
    }
}
