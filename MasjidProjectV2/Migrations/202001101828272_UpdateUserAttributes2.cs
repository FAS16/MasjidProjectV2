namespace MasjidProjectV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserAttributes2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "ZipCode", c => c.String(maxLength: 4));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "ZipCode", c => c.String(maxLength: 55));
        }
    }
}
