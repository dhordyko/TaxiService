namespace TaxiNavigator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newreverse : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrderForms", "OrderDate", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderForms", "OrderDate", c => c.String());
        }
    }
}
