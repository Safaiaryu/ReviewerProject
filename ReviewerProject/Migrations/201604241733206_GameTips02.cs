namespace ReviewerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GameTips02 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameTips", "Job_ID", c => c.Int());
            AddColumn("dbo.GameTips", "Material_ID", c => c.Int());
            AddColumn("dbo.GameTips", "Equipment_ID", c => c.Int());
            AddColumn("dbo.GameTips", "Ability_ID", c => c.Int());
            AddColumn("dbo.GameTips", "Quest_ID", c => c.Int());
            AddColumn("dbo.GameTips", "Monster_ID", c => c.Int());
            CreateIndex("dbo.GameTips", "Job_ID");
            CreateIndex("dbo.GameTips", "Material_ID");
            CreateIndex("dbo.GameTips", "Equipment_ID");
            CreateIndex("dbo.GameTips", "Ability_ID");
            CreateIndex("dbo.GameTips", "Quest_ID");
            CreateIndex("dbo.GameTips", "Monster_ID");
            AddForeignKey("dbo.GameTips", "Job_ID", "dbo.Jobs", "ID");
            AddForeignKey("dbo.GameTips", "Material_ID", "dbo.Materials", "ID");
            AddForeignKey("dbo.GameTips", "Equipment_ID", "dbo.Equipments", "ID");
            AddForeignKey("dbo.GameTips", "Ability_ID", "dbo.Abilities", "ID");
            AddForeignKey("dbo.GameTips", "Quest_ID", "dbo.Quests", "ID");
            AddForeignKey("dbo.GameTips", "Monster_ID", "dbo.Monsters", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GameTips", "Monster_ID", "dbo.Monsters");
            DropForeignKey("dbo.GameTips", "Quest_ID", "dbo.Quests");
            DropForeignKey("dbo.GameTips", "Ability_ID", "dbo.Abilities");
            DropForeignKey("dbo.GameTips", "Equipment_ID", "dbo.Equipments");
            DropForeignKey("dbo.GameTips", "Material_ID", "dbo.Materials");
            DropForeignKey("dbo.GameTips", "Job_ID", "dbo.Jobs");
            DropIndex("dbo.GameTips", new[] { "Monster_ID" });
            DropIndex("dbo.GameTips", new[] { "Quest_ID" });
            DropIndex("dbo.GameTips", new[] { "Ability_ID" });
            DropIndex("dbo.GameTips", new[] { "Equipment_ID" });
            DropIndex("dbo.GameTips", new[] { "Material_ID" });
            DropIndex("dbo.GameTips", new[] { "Job_ID" });
            DropColumn("dbo.GameTips", "Monster_ID");
            DropColumn("dbo.GameTips", "Quest_ID");
            DropColumn("dbo.GameTips", "Ability_ID");
            DropColumn("dbo.GameTips", "Equipment_ID");
            DropColumn("dbo.GameTips", "Material_ID");
            DropColumn("dbo.GameTips", "Job_ID");
        }
    }
}
