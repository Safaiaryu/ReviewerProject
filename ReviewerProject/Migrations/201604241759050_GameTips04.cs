namespace ReviewerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GameTips04 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GameTips", "Material_ID", "dbo.Materials");
            DropIndex("dbo.GameTips", new[] { "Material_ID" });
            AddColumn("dbo.GameTips", "Job_ID", c => c.Int());
            AddColumn("dbo.GameTips", "Quest_ID", c => c.Int());
            CreateIndex("dbo.GameTips", "Job_ID");
            CreateIndex("dbo.GameTips", "Quest_ID");
            AddForeignKey("dbo.GameTips", "Job_ID", "dbo.Jobs", "ID");
            AddForeignKey("dbo.GameTips", "Quest_ID", "dbo.Quests", "ID");
            DropColumn("dbo.GameTips", "Material_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GameTips", "Material_ID", c => c.Int());
            DropForeignKey("dbo.GameTips", "Quest_ID", "dbo.Quests");
            DropForeignKey("dbo.GameTips", "Job_ID", "dbo.Jobs");
            DropIndex("dbo.GameTips", new[] { "Quest_ID" });
            DropIndex("dbo.GameTips", new[] { "Job_ID" });
            DropColumn("dbo.GameTips", "Quest_ID");
            DropColumn("dbo.GameTips", "Job_ID");
            CreateIndex("dbo.GameTips", "Material_ID");
            AddForeignKey("dbo.GameTips", "Material_ID", "dbo.Materials", "ID");
        }
    }
}
