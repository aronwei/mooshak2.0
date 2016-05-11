namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class text55 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Assignments", "CourseViewModel_ID", "dbo.CourseViewModels");
            DropForeignKey("dbo.AspNetUsers", "CourseViewModel_ID", "dbo.CourseViewModels");
            DropIndex("dbo.Assignments", new[] { "CourseViewModel_ID" });
            DropIndex("dbo.AspNetUsers", new[] { "CourseViewModel_ID" });
            DropColumn("dbo.Assignments", "CourseViewModel_ID");
            DropColumn("dbo.AspNetUsers", "CourseViewModel_ID");
            DropTable("dbo.CourseViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CourseViewModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.AspNetUsers", "CourseViewModel_ID", c => c.Int());
            AddColumn("dbo.Assignments", "CourseViewModel_ID", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "CourseViewModel_ID");
            CreateIndex("dbo.Assignments", "CourseViewModel_ID");
            AddForeignKey("dbo.AspNetUsers", "CourseViewModel_ID", "dbo.CourseViewModels", "ID");
            AddForeignKey("dbo.Assignments", "CourseViewModel_ID", "dbo.CourseViewModels", "ID");
        }
    }
}
