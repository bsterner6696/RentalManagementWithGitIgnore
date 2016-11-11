namespace RentalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedmoveoutdatetotenant : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tenants", "MoveOutDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tenants", "MoveOutDate");
        }
    }
}
