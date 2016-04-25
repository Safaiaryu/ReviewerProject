namespace ReviewerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserUpdate01 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "UserID", c => c.Int(nullable: false));
            AddColumn("dbo.Comments", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Threads", "UserID", c => c.Int(nullable: false));
            AddColumn("dbo.Threads", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Comments", "ApplicationUser_Id");
            CreateIndex("dbo.Threads", "ApplicationUser_Id");
            AddForeignKey("dbo.Comments", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Threads", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Threads", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Threads", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Comments", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Threads", "ApplicationUser_Id");
            DropColumn("dbo.Threads", "UserID");
            DropColumn("dbo.Comments", "ApplicationUser_Id");
            DropColumn("dbo.Comments", "UserID");
        }
    }
}
