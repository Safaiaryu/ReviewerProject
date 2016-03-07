namespace ReviewerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelUpdate01 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Threads", "CategoryType", c => c.Int(nullable: false));
            AlterColumn("dbo.Abilities", "Name", c => c.String(maxLength: 30));
            AlterColumn("dbo.Jobs", "JobName", c => c.String(maxLength: 20));
            AlterColumn("dbo.Jobs", "Description", c => c.String(maxLength: 250));
            AlterColumn("dbo.Equipments", "Name", c => c.String(maxLength: 30));
            AlterColumn("dbo.Materials", "MaterialName", c => c.String(maxLength: 30));
            AlterColumn("dbo.Materials", "Description", c => c.String(maxLength: 250));
            AlterColumn("dbo.Eidolons", "EidolonName", c => c.String(maxLength: 20));
            AlterColumn("dbo.Eidolons", "Description", c => c.String(maxLength: 100));
            AlterColumn("dbo.Eidolons", "MagiciteAbilty", c => c.String(maxLength: 100));
            AlterColumn("dbo.Monsters", "MonsterName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Monsters", "Description", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Monsters", "Description", c => c.String());
            AlterColumn("dbo.Monsters", "MonsterName", c => c.String());
            AlterColumn("dbo.Eidolons", "MagiciteAbilty", c => c.String());
            AlterColumn("dbo.Eidolons", "Description", c => c.String());
            AlterColumn("dbo.Eidolons", "EidolonName", c => c.String());
            AlterColumn("dbo.Materials", "Description", c => c.String());
            AlterColumn("dbo.Materials", "MaterialName", c => c.String());
            AlterColumn("dbo.Equipments", "Name", c => c.String());
            AlterColumn("dbo.Jobs", "Description", c => c.String());
            AlterColumn("dbo.Jobs", "JobName", c => c.String());
            AlterColumn("dbo.Abilities", "Name", c => c.String());
            DropColumn("dbo.Threads", "CategoryType");
        }
    }
}
