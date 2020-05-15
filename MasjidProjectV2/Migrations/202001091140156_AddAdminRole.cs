namespace MasjidProjectV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdminRole : DbMigration
    {
        public override void Up()
        {
            Guid g = Guid.NewGuid();
            Sql("INSERT INTO AspNetRoles (Id, Name) VALUES('"+g+"', 'Admin');");
            Sql("INSERT INTO AspNetUserRoles (UserId, RoleId) VALUES ('0f9a279a-d193-4b4f-9282-c0c26975cf21','" + g + "');");

            
        }

        public override void Down()
        {
        }
    }
}
