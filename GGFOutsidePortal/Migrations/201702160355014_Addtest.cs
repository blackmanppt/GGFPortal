namespace GGFOutsidePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addtest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "teststring", c => c.String());
            AddColumn("dbo.AspNetUsers", "teststring2", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "teststring2");
            DropColumn("dbo.AspNetUsers", "teststring");
        }
    }
}
