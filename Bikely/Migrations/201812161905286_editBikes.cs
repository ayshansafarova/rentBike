namespace Bikely.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editBikes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bikes", "Image", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bikes", "Image");
        }
    }
}
