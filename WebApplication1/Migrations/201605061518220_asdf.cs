namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Course_ID", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Course_ID1", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Course_ID");
            CreateIndex("dbo.AspNetUsers", "Course_ID1");
            AddForeignKey("dbo.AspNetUsers", "Course_ID", "dbo.Courses", "ID");
            AddForeignKey("dbo.AspNetUsers", "Course_ID1", "dbo.Courses", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Course_ID1", "dbo.Courses");
            DropForeignKey("dbo.AspNetUsers", "Course_ID", "dbo.Courses");
            DropIndex("dbo.AspNetUsers", new[] { "Course_ID1" });
            DropIndex("dbo.AspNetUsers", new[] { "Course_ID" });
            DropColumn("dbo.AspNetUsers", "Course_ID1");
            DropColumn("dbo.AspNetUsers", "Course_ID");
        }
    }
}
