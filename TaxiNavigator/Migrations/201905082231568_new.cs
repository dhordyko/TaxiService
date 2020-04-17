namespace TaxiNavigator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrderForms", "OrderDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderForms", "OrderDate", c => c.String(nullable: false));
        }
    }
}
