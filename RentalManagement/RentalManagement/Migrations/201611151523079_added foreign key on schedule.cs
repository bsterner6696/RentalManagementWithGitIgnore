namespace RentalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedforeignkeyonschedule : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "ApartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Schedules", "ApartmentId");
            AddForeignKey("dbo.Schedules", "ApartmentId", "dbo.Apartments", "Id", cascadeDelete: true);
            DropColumn("dbo.Schedules", "Apartment");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Schedules", "Apartment", c => c.String());
            DropForeignKey("dbo.Schedules", "ApartmentId", "dbo.Apartments");
            DropIndex("dbo.Schedules", new[] { "ApartmentId" });
            DropColumn("dbo.Schedules", "ApartmentId");
        }
    }
}
