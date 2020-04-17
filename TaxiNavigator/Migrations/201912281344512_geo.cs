namespace TaxiNavigator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class geo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderForms", "Geo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderForms", "Geo");
        }
    }
}
