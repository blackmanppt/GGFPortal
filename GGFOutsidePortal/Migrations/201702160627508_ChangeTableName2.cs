namespace GGFOutsidePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTableName2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Role", newName: "GGFRole");
            RenameTable(name: "dbo.UserRole", newName: "GGFUserRole");
            RenameTable(name: "dbo.User", newName: "GGFUser");
            RenameTable(name: "dbo.UserClaim", newName: "GGFUserClaim");
            RenameTable(name: "dbo.UserLogin", newName: "GGFUserLogin");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.GGFUserLogin", newName: "UserLogin");
            RenameTable(name: "dbo.GGFUserClaim", newName: "UserClaim");
            RenameTable(name: "dbo.GGFUser", newName: "User");
            RenameTable(name: "dbo.GGFUserRole", newName: "UserRole");
            RenameTable(name: "dbo.GGFRole", newName: "Role");
        }
    }
}
