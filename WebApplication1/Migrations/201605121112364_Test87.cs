namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test87 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Submissions", "line", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Submissions", "line");
        }
    }
}
