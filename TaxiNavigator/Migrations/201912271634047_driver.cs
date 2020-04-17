namespace TaxiNavigator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class driver : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "Driver_Id", c => c.Byte());
            CreateIndex("dbo.Locations", "Driver_Id");
            AddForeignKey("dbo.Locations", "Driver_Id", "dbo.Drivers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locations", "Driver_Id", "dbo.Drivers");
            DropIndex("dbo.Locations", new[] { "Driver_Id" });
            DropColumn("dbo.Locations", "Driver_Id");
        }
    }
}
