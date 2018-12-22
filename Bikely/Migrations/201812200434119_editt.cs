namespace Bikely.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rentals", "User_id", "dbo.AspNetUsers");
            DropIndex("dbo.Rentals", new[] { "User_id" });
            AlterColumn("dbo.Rentals", "User_id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Rentals", "User_id");
            AddForeignKey("dbo.Rentals", "User_id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "User_id", "dbo.AspNetUsers");
            DropIndex("dbo.Rentals", new[] { "User_id" });
            AlterColumn("dbo.Rentals", "User_id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Rentals", "User_id");
            AddForeignKey("dbo.Rentals", "User_id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
