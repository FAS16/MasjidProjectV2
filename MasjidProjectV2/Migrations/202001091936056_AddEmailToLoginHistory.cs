namespace MasjidProjectV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmailToLoginHistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LoginHistories", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LoginHistories", "Email");
        }
    }
}
