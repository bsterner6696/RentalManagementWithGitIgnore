namespace RentalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIsAvailableandDateAvailabletoapartment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Apartments", "IsAvailable", c => c.Boolean(nullable: false));
            AddColumn("dbo.Apartments", "DateAvailable", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Apartments", "DateAvailable");
            DropColumn("dbo.Apartments", "IsAvailable");
        }
    }
}
