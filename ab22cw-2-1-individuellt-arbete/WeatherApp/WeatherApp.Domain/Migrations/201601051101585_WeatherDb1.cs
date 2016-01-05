namespace WeatherApp.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WeatherDb1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("weatherApp.Location", "PlaceCode", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("weatherApp.Location", "LocationText", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("weatherApp.Location", "LocationText", c => c.String());
            AlterColumn("weatherApp.Location", "PlaceCode", c => c.String());
        }
    }
}
