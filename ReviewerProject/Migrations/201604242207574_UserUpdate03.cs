namespace ReviewerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserUpdate03 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Comments", name: "ApplicationUser_Id", newName: "User_Id");
            RenameColumn(table: "dbo.Threads", name: "ApplicationUser_Id", newName: "User_Id");
            RenameIndex(table: "dbo.Comments", name: "IX_ApplicationUser_Id", newName: "IX_User_Id");
            RenameIndex(table: "dbo.Threads", name: "IX_ApplicationUser_Id", newName: "IX_User_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Threads", name: "IX_User_Id", newName: "IX_ApplicationUser_Id");
            RenameIndex(table: "dbo.Comments", name: "IX_User_Id", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Threads", name: "User_Id", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.Comments", name: "User_Id", newName: "ApplicationUser_Id");
        }
    }
}
