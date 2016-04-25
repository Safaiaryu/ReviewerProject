namespace ReviewerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserUpdate04 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Comments", name: "User_Id", newName: "UserID");
            RenameColumn(table: "dbo.Threads", name: "User_Id", newName: "UserID");
            RenameIndex(table: "dbo.Comments", name: "IX_User_Id", newName: "IX_UserID");
            RenameIndex(table: "dbo.Threads", name: "IX_User_Id", newName: "IX_UserID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Threads", name: "IX_UserID", newName: "IX_User_Id");
            RenameIndex(table: "dbo.Comments", name: "IX_UserID", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Threads", name: "UserID", newName: "User_Id");
            RenameColumn(table: "dbo.Comments", name: "UserID", newName: "User_Id");
        }
    }
}
