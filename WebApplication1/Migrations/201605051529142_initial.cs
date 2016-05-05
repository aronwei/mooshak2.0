namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assignments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AssignmentMilestones",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AssignmentID = c.Int(nullable: false),
                        Title = c.String(),
                        weight = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AssignmentMilestones");
            DropTable("dbo.Assignments");
        }
    }
}
