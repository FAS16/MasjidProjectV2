namespace MasjidProjectV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserAttributes4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false, maxLength: 55));
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false, maxLength: 55));
            AlterColumn("dbo.AspNetUsers", "City", c => c.String(nullable: false, maxLength: 55));
            AlterColumn("dbo.AspNetUsers", "ZipCode", c => c.String(nullable: false, maxLength: 4));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "ZipCode", c => c.String(maxLength: 4));
            AlterColumn("dbo.AspNetUsers", "City", c => c.String(maxLength: 55));
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String(maxLength: 55));
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String(maxLength: 55));
        }
    }
}
