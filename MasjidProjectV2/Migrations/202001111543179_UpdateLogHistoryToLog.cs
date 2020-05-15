namespace MasjidProjectV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateLogHistoryToLog : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LoginHistories", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.LoginHistories", new[] { "ApplicationUserId" });
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        Email = c.String(nullable: false),
                        Timestamp = c.DateTime(nullable: false),
                        LogAction = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId);
            
            DropTable("dbo.LoginHistories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.LoginHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoginTime = c.DateTime(nullable: false),
                        LogoutTime = c.DateTime(),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Logs", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Logs", new[] { "ApplicationUserId" });
            DropTable("dbo.Logs");
            CreateIndex("dbo.LoginHistories", "ApplicationUserId");
            AddForeignKey("dbo.LoginHistories", "ApplicationUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
