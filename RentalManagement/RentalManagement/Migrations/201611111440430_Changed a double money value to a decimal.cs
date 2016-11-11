namespace RentalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changedadoublemoneyvaluetoadecimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Apartments", "RentPerMonth", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Apartments", "RentPerMonth", c => c.Double(nullable: false));
        }
    }
}
