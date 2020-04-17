namespace TaxiNavigator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignkey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderForms", "Driver_Id", "dbo.Drivers");
            DropIndex("dbo.OrderForms", new[] { "Driver_Id" });
            RenameColumn(table: "dbo.OrderForms", name: "Driver_Id", newName: "DriverId");
            AlterColumn("dbo.OrderForms", "DriverId", c => c.Byte(nullable: false));
            CreateIndex("dbo.OrderForms", "DriverId");
            AddForeignKey("dbo.OrderForms", "DriverId", "dbo.Drivers", "Id", cascadeDelete: true);
            DropColumn("dbo.OrderForms", "DriverNmb");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderForms", "DriverNmb", c => c.Byte(nullable: false));
            DropForeignKey("dbo.OrderForms", "DriverId", "dbo.Drivers");
            DropIndex("dbo.OrderForms", new[] { "DriverId" });
            AlterColumn("dbo.OrderForms", "DriverId", c => c.Byte());
            RenameColumn(table: "dbo.OrderForms", name: "DriverId", newName: "Driver_Id");
            CreateIndex("dbo.OrderForms", "Driver_Id");
            AddForeignKey("dbo.OrderForms", "Driver_Id", "dbo.Drivers", "Id");
        }
    }
}
