namespace ReviewerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abilities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Load = c.Int(nullable: false),
                        APCost = c.Int(nullable: false),
                        CoolDown = c.Double(nullable: false),
                        Power = c.Int(nullable: false),
                        Description = c.String(),
                        ProficitentClass_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Jobs", t => t.ProficitentClass_ID)
                .Index(t => t.ProficitentClass_ID);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        JobName = c.String(),
                        BaseHP = c.Int(nullable: false),
                        BaseAP = c.Int(nullable: false),
                        BaseLoad = c.Int(nullable: false),
                        Description = c.String(),
                        JobProficiencies = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.Int(nullable: false),
                        LoadBonus = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Job_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Jobs", t => t.Job_ID)
                .Index(t => t.Job_ID);
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MaterialName = c.String(),
                        Description = c.String(),
                        Type = c.Int(nullable: false),
                        Equipment_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Equipments", t => t.Equipment_ID)
                .Index(t => t.Equipment_ID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        ThreadID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Threads", t => t.ThreadID, cascadeDelete: true)
                .Index(t => t.ThreadID);
            
            CreateTable(
                "dbo.Eidolons",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EidolonName = c.String(),
                        Description = c.String(),
                        MagiciteAbilty = c.String(),
                        Magicite_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Materials", t => t.Magicite_ID)
                .Index(t => t.Magicite_ID);
            
            CreateTable(
                "dbo.Quests",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        StarLevel = c.Int(nullable: false),
                        Time = c.Int(nullable: false),
                        Eidolon_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Eidolons", t => t.Eidolon_ID)
                .Index(t => t.Eidolon_ID);
            
            CreateTable(
                "dbo.Monsters",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MonsterName = c.String(),
                        Description = c.String(),
                        CreateCost = c.Int(nullable: false),
                        Load = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        CanCapture = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Threads",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ThreadType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "ThreadID", "dbo.Threads");
            DropForeignKey("dbo.Quests", "Eidolon_ID", "dbo.Eidolons");
            DropForeignKey("dbo.Eidolons", "Magicite_ID", "dbo.Materials");
            DropForeignKey("dbo.Abilities", "ProficitentClass_ID", "dbo.Jobs");
            DropForeignKey("dbo.Equipments", "Job_ID", "dbo.Jobs");
            DropForeignKey("dbo.Materials", "Equipment_ID", "dbo.Equipments");
            DropIndex("dbo.Quests", new[] { "Eidolon_ID" });
            DropIndex("dbo.Eidolons", new[] { "Magicite_ID" });
            DropIndex("dbo.Comments", new[] { "ThreadID" });
            DropIndex("dbo.Materials", new[] { "Equipment_ID" });
            DropIndex("dbo.Equipments", new[] { "Job_ID" });
            DropIndex("dbo.Abilities", new[] { "ProficitentClass_ID" });
            DropTable("dbo.Threads");
            DropTable("dbo.Monsters");
            DropTable("dbo.Quests");
            DropTable("dbo.Eidolons");
            DropTable("dbo.Comments");
            DropTable("dbo.Materials");
            DropTable("dbo.Equipments");
            DropTable("dbo.Jobs");
            DropTable("dbo.Abilities");
        }
    }
}
