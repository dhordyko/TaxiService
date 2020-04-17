namespace TaxiNavigator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderform : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderForms", "lat", c => c.Double());
            AddColumn("dbo.OrderForms", "lng", c => c.Double());
            AddColumn("dbo.OrderForms", "Distance", c => c.Double());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderForms", "Distance");
            DropColumn("dbo.OrderForms", "lng");
            DropColumn("dbo.OrderForms", "lat");
        }
    }
}
