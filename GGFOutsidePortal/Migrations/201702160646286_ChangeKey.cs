namespace GGFOutsidePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeKey : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.GGFUserRole");
            AddPrimaryKey("dbo.GGFUserRole", new[] { "RoleId", "UserId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.GGFUserRole");
            AddPrimaryKey("dbo.GGFUserRole", new[] { "UserId", "RoleId" });
        }
    }
}
