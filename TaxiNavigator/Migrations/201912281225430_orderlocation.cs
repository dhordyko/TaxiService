namespace TaxiNavigator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Spatial;
    
    public partial class orderlocation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderForms", "Geolocation", c => c.Geography());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderForms", "Geolocation");
        }
    }
}
