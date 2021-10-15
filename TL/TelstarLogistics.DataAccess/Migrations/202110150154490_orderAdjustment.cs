namespace TelstarLogistics.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderAdjustment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Order", "Route_RouteId", "dbo.Route");
            DropIndex("dbo.Order", new[] { "Route_RouteId" });
            AddColumn("dbo.Order", "CityFrom", c => c.String());
            AddColumn("dbo.Order", "CityTo", c => c.String());
            AddColumn("dbo.Order", "Cost", c => c.Double(nullable: false));
            AddColumn("dbo.Order", "Duration", c => c.Double(nullable: false));
            DropColumn("dbo.Order", "Route_RouteId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order", "Route_RouteId", c => c.Int());
            DropColumn("dbo.Order", "Duration");
            DropColumn("dbo.Order", "Cost");
            DropColumn("dbo.Order", "CityTo");
            DropColumn("dbo.Order", "CityFrom");
            CreateIndex("dbo.Order", "Route_RouteId");
            AddForeignKey("dbo.Order", "Route_RouteId", "dbo.Route", "RouteId");
        }
    }
}
