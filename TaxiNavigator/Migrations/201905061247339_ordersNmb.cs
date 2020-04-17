namespace TaxiNavigator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ordersNmb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderForms", "OrderNmb", c => c.String());
            DropColumn("dbo.OrderForms", "OrdersId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderForms", "OrdersId", c => c.Int(nullable: false));
            DropColumn("dbo.OrderForms", "OrderNmb");
        }
    }
}
