namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Solutions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssignmentSolutions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AssignmentSolutions");
        }
    }
}
