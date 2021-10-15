namespace TelstarLogistics.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class idfix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RouteSegment", "CityFrom_PersonId", "dbo.City");
            DropForeignKey("dbo.RouteSegment", "CityTo_PersonId", "dbo.City");
            RenameColumn(table: "dbo.RouteSegment", name: "CityFrom_PersonId", newName: "CityFrom_Id");
            RenameColumn(table: "dbo.RouteSegment", name: "CityTo_PersonId", newName: "CityTo_Id");
            RenameIndex(table: "dbo.RouteSegment", name: "IX_CityFrom_PersonId", newName: "IX_CityFrom_Id");
            RenameIndex(table: "dbo.RouteSegment", name: "IX_CityTo_PersonId", newName: "IX_CityTo_Id");
            DropPrimaryKey("dbo.City");
            AddColumn("dbo.City", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.City", "Id");
            AddForeignKey("dbo.RouteSegment", "CityFrom_Id", "dbo.City", "Id");
            AddForeignKey("dbo.RouteSegment", "CityTo_Id", "dbo.City", "Id");
            DropColumn("dbo.City", "PersonId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.City", "PersonId", c => c.Int(nullable: false));
            DropForeignKey("dbo.RouteSegment", "CityTo_Id", "dbo.City");
            DropForeignKey("dbo.RouteSegment", "CityFrom_Id", "dbo.City");
            DropPrimaryKey("dbo.City");
            DropColumn("dbo.City", "Id");
            AddPrimaryKey("dbo.City", "PersonId");
            RenameIndex(table: "dbo.RouteSegment", name: "IX_CityTo_Id", newName: "IX_CityTo_PersonId");
            RenameIndex(table: "dbo.RouteSegment", name: "IX_CityFrom_Id", newName: "IX_CityFrom_PersonId");
            RenameColumn(table: "dbo.RouteSegment", name: "CityTo_Id", newName: "CityTo_PersonId");
            RenameColumn(table: "dbo.RouteSegment", name: "CityFrom_Id", newName: "CityFrom_PersonId");
            AddForeignKey("dbo.RouteSegment", "CityTo_PersonId", "dbo.City", "PersonId");
            AddForeignKey("dbo.RouteSegment", "CityFrom_PersonId", "dbo.City", "PersonId");
        }
    }
}
