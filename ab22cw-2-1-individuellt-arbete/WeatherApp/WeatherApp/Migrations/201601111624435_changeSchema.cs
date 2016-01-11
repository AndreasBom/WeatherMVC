namespace WeatherApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeSchema : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "weatherApp.AspNetRoles", newSchema: "dbo");
            MoveTable(name: "weatherApp.AspNetUserClaims", newSchema: "dbo");
            MoveTable(name: "weatherApp.AspNetUserLogins", newSchema: "dbo");
            MoveTable(name: "weatherApp.AspNetUserRoles", newSchema: "dbo");
            MoveTable(name: "weatherApp.AspNetUsers", newSchema: "dbo");
            
        }

        public override void Down()
        {
            MoveTable(name: "dbo.AspNetRoles", newSchema: "weatherApp");
            MoveTable(name: "dbo.AspNetUserClaims", newSchema: "weatherApp");
            MoveTable(name: "dbo.AspNetUserLogins", newSchema: "weatherApp");
            MoveTable(name: "dbo.AspNetUserRoles", newSchema: "weatherApp");
            MoveTable(name: "dbo.AspNetUsers", newSchema: "weatherApp");
        }
    }
}
