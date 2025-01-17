namespace MasjidProjectV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserAttributes3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "DateOfBirth", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "DateOfBirth", c => c.String(nullable: false));
        }
    }
}
