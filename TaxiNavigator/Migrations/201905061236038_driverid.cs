namespace TaxiNavigator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class driverid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderForms", "DriverNmb", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderForms", "DriverNmb");
        }
    }
}
