namespace MasjidProjectV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLoginHistory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoginHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoginTime = c.DateTime(nullable: false),
                        LogoutTime = c.DateTime(),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LoginHistories", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.LoginHistories", new[] { "ApplicationUserId" });
            DropTable("dbo.LoginHistories");
        }
    }
}
