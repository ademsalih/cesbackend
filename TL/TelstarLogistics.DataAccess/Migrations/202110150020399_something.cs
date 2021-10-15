namespace TelstarLogistics.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class something : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Address", "PostCode", c => c.String());
            AlterColumn("dbo.Customer", "PostCode", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customer", "PostCode", c => c.Int(nullable: false));
            AlterColumn("dbo.Address", "PostCode", c => c.Int(nullable: false));
        }
    }
}
