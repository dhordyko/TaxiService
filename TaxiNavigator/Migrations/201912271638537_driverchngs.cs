namespace TaxiNavigator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class driverchngs : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Locations", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Locations", "Name", c => c.String());
        }
    }
}
