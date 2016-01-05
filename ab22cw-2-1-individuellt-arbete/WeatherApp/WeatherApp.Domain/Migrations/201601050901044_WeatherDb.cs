namespace WeatherApp.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WeatherDb : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dbo.Location", newSchema: "weatherApp");
            MoveTable(name: "dbo.Weather", newSchema: "weatherApp");
        }
        
        public override void Down()
        {
            MoveTable(name: "weatherApp.Weather", newSchema: "dbo");
            MoveTable(name: "weatherApp.Location", newSchema: "dbo");
        }
    }
}
