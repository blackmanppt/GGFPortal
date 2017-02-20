namespace GGFOutsidePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testrole : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GGFUser", "dept", c => c.String());
            AddColumn("dbo.GGFUser", "UserStatus", c => c.String());
            DropColumn("dbo.GGFUser", "teststring");
            DropColumn("dbo.GGFUser", "teststring2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GGFUser", "teststring2", c => c.String());
            AddColumn("dbo.GGFUser", "teststring", c => c.String());
            DropColumn("dbo.GGFUser", "UserStatus");
            DropColumn("dbo.GGFUser", "dept");
        }
    }
}
