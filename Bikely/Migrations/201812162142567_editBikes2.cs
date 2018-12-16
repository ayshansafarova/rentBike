namespace Bikely.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editBikes2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Bikes", new[] { "User_Id" });
            CreateIndex("dbo.Bikes", "User_id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Bikes", new[] { "User_id" });
            CreateIndex("dbo.Bikes", "User_Id");
        }
    }
}
