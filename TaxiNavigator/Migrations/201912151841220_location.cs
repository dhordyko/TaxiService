namespace TaxiNavigator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class location : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Geolocation = c.Geography(),
                        lat = c.Double(),
                        lng = c.Double(),
                        Distance = c.Double(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Locations");
        }
    }
}
