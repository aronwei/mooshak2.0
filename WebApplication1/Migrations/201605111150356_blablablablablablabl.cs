namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class blablablablablablabl : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AssignmentMilestoneViewModels", "AssignmentViewModel_ID", "dbo.AssignmentViewModels");
            DropIndex("dbo.AssignmentMilestoneViewModels", new[] { "AssignmentViewModel_ID" });
            DropTable("dbo.AssignmentViewModels");
            DropTable("dbo.AssignmentMilestoneViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AssignmentMilestoneViewModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        weight = c.Int(nullable: false),
                        AssignmentViewModel_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AssignmentViewModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        CourseID = c.Int(nullable: false),
                        CourseName = c.String(),
                        Description = c.String(),
                        StartDate = c.String(),
                        StartTime = c.String(nullable: false),
                        EndTime = c.String(),
                        EndDate = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.AssignmentMilestoneViewModels", "AssignmentViewModel_ID");
            AddForeignKey("dbo.AssignmentMilestoneViewModels", "AssignmentViewModel_ID", "dbo.AssignmentViewModels", "ID");
        }
    }
}
