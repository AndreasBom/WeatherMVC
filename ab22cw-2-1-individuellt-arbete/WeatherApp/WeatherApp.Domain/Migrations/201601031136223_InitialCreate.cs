namespace WeatherApp.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        Latitude = c.Single(nullable: false),
                        Longitude = c.Single(nullable: false),
                        LocationText = c.String(),
                    })
                .PrimaryKey(t => t.LocationId);
            
            CreateTable(
                "dbo.Weather",
                c => new
                    {
                        WeatherId = c.Int(nullable: false, identity: true),
                        LocationId = c.Int(nullable: false),
                        ValidTime = c.DateTime(nullable: false),
                        Temperature = c.Single(nullable: false),
                        ThunderProbability = c.Int(nullable: false),
                        CloudFactor = c.Int(nullable: false),
                        Preciptation = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WeatherId)
                .ForeignKey("dbo.Location", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.LocationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Weather", "LocationId", "dbo.Location");
            DropIndex("dbo.Weather", new[] { "LocationId" });
            DropTable("dbo.Weather");
            DropTable("dbo.Location");
        }
    }
}
