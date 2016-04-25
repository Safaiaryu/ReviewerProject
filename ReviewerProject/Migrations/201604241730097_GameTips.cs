namespace ReviewerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GameTips : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameTips",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 30),
                        Content = c.String(maxLength: 254),
                        ImageURL = c.String(),
                        Eidolon_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Eidolons", t => t.Eidolon_ID)
                .Index(t => t.Eidolon_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GameTips", "Eidolon_ID", "dbo.Eidolons");
            DropIndex("dbo.GameTips", new[] { "Eidolon_ID" });
            DropTable("dbo.GameTips");
        }
    }
}
