namespace TaxiNavigator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usermail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderForms", "UserMail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderForms", "UserMail");
        }
    }
}
