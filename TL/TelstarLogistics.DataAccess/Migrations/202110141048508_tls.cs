namespace TelstarLogistics.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tls : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.PersonId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employee");
        }
    }
}
