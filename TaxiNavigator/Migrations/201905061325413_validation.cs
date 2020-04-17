namespace TaxiNavigator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrderForms", "Adress", c => c.String(nullable: false));
            AlterColumn("dbo.OrderForms", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.OrderForms", "SecondName", c => c.String(nullable: false));
            AlterColumn("dbo.OrderForms", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.OrderForms", "OrderDate", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderForms", "OrderDate", c => c.String());
            AlterColumn("dbo.OrderForms", "PhoneNumber", c => c.String());
            AlterColumn("dbo.OrderForms", "SecondName", c => c.String());
            AlterColumn("dbo.OrderForms", "Name", c => c.String());
            AlterColumn("dbo.OrderForms", "Adress", c => c.String());
        }
    }
}
