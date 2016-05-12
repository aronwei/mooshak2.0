namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Submissions", "line");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Submissions", "line", c => c.String());
        }
    }
}
