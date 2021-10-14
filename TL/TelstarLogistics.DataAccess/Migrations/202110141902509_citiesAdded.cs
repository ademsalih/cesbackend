namespace TelstarLogistics.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class citiesAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        AddressLine = c.String(),
                        PostCode = c.Int(nullable: false),
                        City = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.AddressId);
            
            CreateTable(
                "dbo.City",
                c => new
                    {
                        PersonId = c.Int(nullable: false),
                        Name = c.String(),
                        DisplayName = c.String(),
                    })
                .PrimaryKey(t => t.PersonId);
            
            AddColumn("dbo.Customer", "PostCode", c => c.Int(nullable: false));
            AddColumn("dbo.Customer", "CardHolder", c => c.String());
            AddColumn("dbo.Customer", "CreditCard", c => c.Int(nullable: false));
            AddColumn("dbo.Customer", "Cvv", c => c.Int(nullable: false));
            AddColumn("dbo.Customer", "DateTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Customer", "Address_AddressId", c => c.Int());
            AddColumn("dbo.Order", "TrackingNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Order", "ShippingStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Order", "Delivered", c => c.Boolean(nullable: false));
            AddColumn("dbo.Employee", "MailAddress", c => c.String());
            AddColumn("dbo.RouteSegment", "CityFrom_PersonId", c => c.Int());
            AddColumn("dbo.RouteSegment", "CityTo_PersonId", c => c.Int());
            CreateIndex("dbo.Customer", "Address_AddressId");
            CreateIndex("dbo.RouteSegment", "CityFrom_PersonId");
            CreateIndex("dbo.RouteSegment", "CityTo_PersonId");
            AddForeignKey("dbo.Customer", "Address_AddressId", "dbo.Address", "AddressId");
            AddForeignKey("dbo.RouteSegment", "CityFrom_PersonId", "dbo.City", "PersonId");
            AddForeignKey("dbo.RouteSegment", "CityTo_PersonId", "dbo.City", "PersonId");
            DropColumn("dbo.Order", "CreationDate");
            DropColumn("dbo.Order", "DeliveryDate");
            DropColumn("dbo.RouteSegment", "CityTo");
            DropColumn("dbo.RouteSegment", "CityFrom");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RouteSegment", "CityFrom", c => c.String());
            AddColumn("dbo.RouteSegment", "CityTo", c => c.String());
            AddColumn("dbo.Order", "DeliveryDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Order", "CreationDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            DropForeignKey("dbo.RouteSegment", "CityTo_PersonId", "dbo.City");
            DropForeignKey("dbo.RouteSegment", "CityFrom_PersonId", "dbo.City");
            DropForeignKey("dbo.Customer", "Address_AddressId", "dbo.Address");
            DropIndex("dbo.RouteSegment", new[] { "CityTo_PersonId" });
            DropIndex("dbo.RouteSegment", new[] { "CityFrom_PersonId" });
            DropIndex("dbo.Customer", new[] { "Address_AddressId" });
            DropColumn("dbo.RouteSegment", "CityTo_PersonId");
            DropColumn("dbo.RouteSegment", "CityFrom_PersonId");
            DropColumn("dbo.Employee", "MailAddress");
            DropColumn("dbo.Order", "Delivered");
            DropColumn("dbo.Order", "ShippingStatus");
            DropColumn("dbo.Order", "TrackingNumber");
            DropColumn("dbo.Customer", "Address_AddressId");
            DropColumn("dbo.Customer", "DateTime");
            DropColumn("dbo.Customer", "Cvv");
            DropColumn("dbo.Customer", "CreditCard");
            DropColumn("dbo.Customer", "CardHolder");
            DropColumn("dbo.Customer", "PostCode");
            DropTable("dbo.City");
            DropTable("dbo.Address");
        }
    }
}
