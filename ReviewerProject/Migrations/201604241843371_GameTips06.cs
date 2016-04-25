namespace ReviewerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GameTips06 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GameTips", "Monster_ID", "dbo.Monsters");
            DropForeignKey("dbo.GameTips", "Job_ID", "dbo.Jobs");
            DropForeignKey("dbo.GameTips", "Eidolon_ID", "dbo.Eidolons");
            DropForeignKey("dbo.GameTips", "Quest_ID", "dbo.Quests");
            DropIndex("dbo.GameTips", new[] { "Quest_ID" });
            DropIndex("dbo.GameTips", new[] { "Eidolon_ID" });
            DropIndex("dbo.GameTips", new[] { "Job_ID" });
            DropIndex("dbo.GameTips", new[] { "Monster_ID" });
            RenameColumn(table: "dbo.GameTips", name: "Job_ID", newName: "JobID");
            RenameColumn(table: "dbo.GameTips", name: "Eidolon_ID", newName: "EidolonID");
            RenameColumn(table: "dbo.GameTips", name: "Quest_ID", newName: "QuestID");
            AlterColumn("dbo.GameTips", "QuestID", c => c.Int(nullable: false));
            AlterColumn("dbo.GameTips", "EidolonID", c => c.Int(nullable: false));
            AlterColumn("dbo.GameTips", "JobID", c => c.Int(nullable: false));
            CreateIndex("dbo.GameTips", "EidolonID");
            CreateIndex("dbo.GameTips", "JobID");
            CreateIndex("dbo.GameTips", "QuestID");
            AddForeignKey("dbo.GameTips", "JobID", "dbo.Jobs", "ID", cascadeDelete: true);
            AddForeignKey("dbo.GameTips", "EidolonID", "dbo.Eidolons", "ID", cascadeDelete: true);
            AddForeignKey("dbo.GameTips", "QuestID", "dbo.Quests", "ID", cascadeDelete: true);
            DropColumn("dbo.GameTips", "Monster_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GameTips", "Monster_ID", c => c.Int());
            DropForeignKey("dbo.GameTips", "QuestID", "dbo.Quests");
            DropForeignKey("dbo.GameTips", "EidolonID", "dbo.Eidolons");
            DropForeignKey("dbo.GameTips", "JobID", "dbo.Jobs");
            DropIndex("dbo.GameTips", new[] { "QuestID" });
            DropIndex("dbo.GameTips", new[] { "JobID" });
            DropIndex("dbo.GameTips", new[] { "EidolonID" });
            AlterColumn("dbo.GameTips", "JobID", c => c.Int());
            AlterColumn("dbo.GameTips", "EidolonID", c => c.Int());
            AlterColumn("dbo.GameTips", "QuestID", c => c.Int());
            RenameColumn(table: "dbo.GameTips", name: "QuestID", newName: "Quest_ID");
            RenameColumn(table: "dbo.GameTips", name: "EidolonID", newName: "Eidolon_ID");
            RenameColumn(table: "dbo.GameTips", name: "JobID", newName: "Job_ID");
            CreateIndex("dbo.GameTips", "Monster_ID");
            CreateIndex("dbo.GameTips", "Job_ID");
            CreateIndex("dbo.GameTips", "Eidolon_ID");
            CreateIndex("dbo.GameTips", "Quest_ID");
            AddForeignKey("dbo.GameTips", "Quest_ID", "dbo.Quests", "ID");
            AddForeignKey("dbo.GameTips", "Eidolon_ID", "dbo.Eidolons", "ID");
            AddForeignKey("dbo.GameTips", "Job_ID", "dbo.Jobs", "ID");
            AddForeignKey("dbo.GameTips", "Monster_ID", "dbo.Monsters", "ID");
        }
    }
}
