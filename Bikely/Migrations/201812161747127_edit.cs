namespace Bikely.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bikes", "isActive", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Bikes", "Description", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bikes", "Description", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Bikes", "isActive");
        }
    }
}
