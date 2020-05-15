namespace MasjidProjectV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserAttributes1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(maxLength: 55));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(maxLength: 55));
            AddColumn("dbo.AspNetUsers", "City", c => c.String(maxLength: 55));
            AddColumn("dbo.AspNetUsers", "ZipCode", c => c.String(maxLength: 55));
            AddColumn("dbo.AspNetUsers", "DateOfBirth", c => c.String(nullable: false));
            DropColumn("dbo.AspNetUsers", "IsEnabled");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "IsEnabled", c => c.Boolean(nullable: false));
            DropColumn("dbo.AspNetUsers", "DateOfBirth");
            DropColumn("dbo.AspNetUsers", "ZipCode");
            DropColumn("dbo.AspNetUsers", "City");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
