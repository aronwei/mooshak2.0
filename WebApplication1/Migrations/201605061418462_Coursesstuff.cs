namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Coursesstuff : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Course_ID", "dbo.Courses");
            DropForeignKey("dbo.AspNetUsers", "Course_ID1", "dbo.Courses");
            DropIndex("dbo.AspNetUsers", new[] { "Course_ID" });
            DropIndex("dbo.AspNetUsers", new[] { "Course_ID1" });
            DropColumn("dbo.AspNetUsers", "Course_ID");
            DropColumn("dbo.AspNetUsers", "Course_ID1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Course_ID1", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Course_ID", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Course_ID1");
            CreateIndex("dbo.AspNetUsers", "Course_ID");
            AddForeignKey("dbo.AspNetUsers", "Course_ID1", "dbo.Courses", "ID");
            AddForeignKey("dbo.AspNetUsers", "Course_ID", "dbo.Courses", "ID");
        }
    }
}
