namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Assignments", "CourseID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Assignments", "CourseID", c => c.Int(nullable: false));
        }
    }
}
