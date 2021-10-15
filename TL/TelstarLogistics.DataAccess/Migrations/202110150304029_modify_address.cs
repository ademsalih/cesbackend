namespace TelstarLogistics.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modify_address : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customer", "Address_AddressId", "dbo.Address");
            DropForeignKey("dbo.Route", "RouteSegment_RouteSegmentId", "dbo.RouteSegment");
            DropIndex("dbo.Customer", new[] { "Address_AddressId" });
            DropIndex("dbo.Route", new[] { "RouteSegment_RouteSegmentId" });
            AddColumn("dbo.Customer", "Address", c => c.String());
            AddColumn("dbo.Customer", "City", c => c.String());
            DropColumn("dbo.Customer", "Address_AddressId");
            DropTable("dbo.Address");
            DropTable("dbo.Route");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Route",
                c => new
                    {
                        RouteId = c.Int(nullable: false, identity: true),
                        Price = c.Double(nullable: false),
                        AdjustedPrice = c.Double(nullable: false),
                        Duration = c.Double(nullable: false),
                        RouteSegment_RouteSegmentId = c.Int(),
                    })
                .PrimaryKey(t => t.RouteId);
            
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        AddressLine = c.String(),
                        PostCode = c.String(),
                        City = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.AddressId);
            
            AddColumn("dbo.Customer", "Address_AddressId", c => c.Int());
            DropColumn("dbo.Customer", "City");
            DropColumn("dbo.Customer", "Address");
            CreateIndex("dbo.Route", "RouteSegment_RouteSegmentId");
            CreateIndex("dbo.Customer", "Address_AddressId");
            AddForeignKey("dbo.Route", "RouteSegment_RouteSegmentId", "dbo.RouteSegment", "RouteSegmentId");
            AddForeignKey("dbo.Customer", "Address_AddressId", "dbo.Address", "AddressId");
        }
    }
}
