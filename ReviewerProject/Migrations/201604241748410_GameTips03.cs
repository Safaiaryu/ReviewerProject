namespace ReviewerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GameTips03 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GameTips", "Job_ID", "dbo.Jobs");
            DropForeignKey("dbo.GameTips", "Equipment_ID", "dbo.Equipments");
            DropForeignKey("dbo.GameTips", "Ability_ID", "dbo.Abilities");
            DropForeignKey("dbo.GameTips", "Quest_ID", "dbo.Quests");
            DropIndex("dbo.GameTips", new[] { "Job_ID" });
            DropIndex("dbo.GameTips", new[] { "Equipment_ID" });
            DropIndex("dbo.GameTips", new[] { "Ability_ID" });
            DropIndex("dbo.GameTips", new[] { "Quest_ID" });
            DropColumn("dbo.GameTips", "Job_ID");
            DropColumn("dbo.GameTips", "Equipment_ID");
            DropColumn("dbo.GameTips", "Ability_ID");
            DropColumn("dbo.GameTips", "Quest_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GameTips", "Quest_ID", c => c.Int());
            AddColumn("dbo.GameTips", "Ability_ID", c => c.Int());
            AddColumn("dbo.GameTips", "Equipment_ID", c => c.Int());
            AddColumn("dbo.GameTips", "Job_ID", c => c.Int());
            CreateIndex("dbo.GameTips", "Quest_ID");
            CreateIndex("dbo.GameTips", "Ability_ID");
            CreateIndex("dbo.GameTips", "Equipment_ID");
            CreateIndex("dbo.GameTips", "Job_ID");
            AddForeignKey("dbo.GameTips", "Quest_ID", "dbo.Quests", "ID");
            AddForeignKey("dbo.GameTips", "Ability_ID", "dbo.Abilities", "ID");
            AddForeignKey("dbo.GameTips", "Equipment_ID", "dbo.Equipments", "ID");
            AddForeignKey("dbo.GameTips", "Job_ID", "dbo.Jobs", "ID");
        }
    }
}
