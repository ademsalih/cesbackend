namespace TelstarLogistics.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeToIds : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Order", "CreatedBy_PersonId", "dbo.Employee");
            DropForeignKey("dbo.Order", "Customer_PersonId", "dbo.Customer");
            DropForeignKey("dbo.Order", "Parcel_ParcelId", "dbo.Parcel");
            DropIndex("dbo.Order", new[] { "CreatedBy_PersonId" });
            DropIndex("dbo.Order", new[] { "Customer_PersonId" });
            DropIndex("dbo.Order", new[] { "Parcel_ParcelId" });
            AddColumn("dbo.Order", "CreatedById", c => c.Int(nullable: false));
            AddColumn("dbo.Order", "CustomerId", c => c.Int(nullable: false));
            AddColumn("dbo.Order", "ParcelId", c => c.Int(nullable: false));
            DropColumn("dbo.Order", "CreatedBy_PersonId");
            DropColumn("dbo.Order", "Customer_PersonId");
            DropColumn("dbo.Order", "Parcel_ParcelId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order", "Parcel_ParcelId", c => c.Int());
            AddColumn("dbo.Order", "Customer_PersonId", c => c.Int());
            AddColumn("dbo.Order", "CreatedBy_PersonId", c => c.Int());
            DropColumn("dbo.Order", "ParcelId");
            DropColumn("dbo.Order", "CustomerId");
            DropColumn("dbo.Order", "CreatedById");
            CreateIndex("dbo.Order", "Parcel_ParcelId");
            CreateIndex("dbo.Order", "Customer_PersonId");
            CreateIndex("dbo.Order", "CreatedBy_PersonId");
            AddForeignKey("dbo.Order", "Parcel_ParcelId", "dbo.Parcel", "ParcelId");
            AddForeignKey("dbo.Order", "Customer_PersonId", "dbo.Customer", "PersonId");
            AddForeignKey("dbo.Order", "CreatedBy_PersonId", "dbo.Employee", "PersonId");
        }
    }
}
