namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseAssignments",
                c => new
                    {
                        Course_ID = c.Int(nullable: false),
                        Assignment_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Course_ID, t.Assignment_ID })
                .ForeignKey("dbo.Courses", t => t.Course_ID, cascadeDelete: true)
                .ForeignKey("dbo.Assignments", t => t.Assignment_ID, cascadeDelete: true)
                .Index(t => t.Course_ID)
                .Index(t => t.Assignment_ID);
            
            DropColumn("dbo.Assignments", "CourseID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Assignments", "CourseID", c => c.Int(nullable: false));
            DropForeignKey("dbo.CourseAssignments", "Assignment_ID", "dbo.Assignments");
            DropForeignKey("dbo.CourseAssignments", "Course_ID", "dbo.Courses");
            DropIndex("dbo.CourseAssignments", new[] { "Assignment_ID" });
            DropIndex("dbo.CourseAssignments", new[] { "Course_ID" });
            DropTable("dbo.CourseAssignments");
        }
    }
}
