namespace ReviewerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserUpdate02 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Comments", "UserID");
            DropColumn("dbo.Threads", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Threads", "UserID", c => c.Int(nullable: false));
            AddColumn("dbo.Comments", "UserID", c => c.Int(nullable: false));
        }
    }
}
