namespace TelstarLogistics.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class segmentId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "RouteSegmentId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Order", "RouteSegmentId");
        }
    }
}
