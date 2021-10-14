namespace TelstarLogistics.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Mail = c.String(),
                    })
                .PrimaryKey(t => t.PersonId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DeliveryDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreatedBy_PersonId = c.Int(),
                        Customer_PersonId = c.Int(),
                        Parcel_ParcelId = c.Int(),
                        Route_RouteId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Employee", t => t.CreatedBy_PersonId)
                .ForeignKey("dbo.Customer", t => t.Customer_PersonId)
                .ForeignKey("dbo.Parcel", t => t.Parcel_ParcelId)
                .ForeignKey("dbo.Route", t => t.Route_RouteId)
                .Index(t => t.CreatedBy_PersonId)
                .Index(t => t.Customer_PersonId)
                .Index(t => t.Parcel_ParcelId)
                .Index(t => t.Route_RouteId);
            
            CreateTable(
                "dbo.Parcel",
                c => new
                    {
                        ParcelId = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Weight = c.Double(nullable: false),
                        SizeLength = c.Double(nullable: false),
                        SizeWidth = c.Double(nullable: false),
                        SizeHeight = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ParcelId);
            
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
                .PrimaryKey(t => t.RouteId)
                .ForeignKey("dbo.RouteSegment", t => t.RouteSegment_RouteSegmentId)
                .Index(t => t.RouteSegment_RouteSegmentId);
            
            CreateTable(
                "dbo.RouteSegment",
                c => new
                    {
                        RouteSegmentId = c.Int(nullable: false, identity: true),
                        CityTo = c.String(),
                        CityFrom = c.String(),
                        Price = c.Double(nullable: false),
                        Duration = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.RouteSegmentId);
            
            AddColumn("dbo.Employee", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Order", "Route_RouteId", "dbo.Route");
            DropForeignKey("dbo.Route", "RouteSegment_RouteSegmentId", "dbo.RouteSegment");
            DropForeignKey("dbo.Order", "Parcel_ParcelId", "dbo.Parcel");
            DropForeignKey("dbo.Order", "Customer_PersonId", "dbo.Customer");
            DropForeignKey("dbo.Order", "CreatedBy_PersonId", "dbo.Employee");
            DropIndex("dbo.Route", new[] { "RouteSegment_RouteSegmentId" });
            DropIndex("dbo.Order", new[] { "Route_RouteId" });
            DropIndex("dbo.Order", new[] { "Parcel_ParcelId" });
            DropIndex("dbo.Order", new[] { "Customer_PersonId" });
            DropIndex("dbo.Order", new[] { "CreatedBy_PersonId" });
            DropColumn("dbo.Employee", "Password");
            DropTable("dbo.RouteSegment");
            DropTable("dbo.Route");
            DropTable("dbo.Parcel");
            DropTable("dbo.Order");
            DropTable("dbo.Customer");
        }
    }
}
