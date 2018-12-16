namespace Bikely.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBikeCategoryclasses : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Bikes",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Description = c.String(nullable: false, maxLength: 255),
            //            CategoryId = c.Byte(nullable: false),
            //            priceDaily = c.Int(nullable: false),
            //            priceWeekly = c.Int(nullable: false),
            //            priceMonthly = c.Int(nullable: false),
            //            User_Id = c.String(maxLength: 128),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
            //    .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
            //    .Index(t => t.CategoryId)
            //    .Index(t => t.User_Id);
            
            //CreateTable(
            //    "dbo.Categories",
            //    c => new
            //        {
            //            Id = c.Byte(nullable: false),
            //            Name = c.String(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bikes", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Bikes", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Bikes", new[] { "User_Id" });
            DropIndex("dbo.Bikes", new[] { "CategoryId" });
            DropTable("dbo.Categories");
            DropTable("dbo.Bikes");
        }
    }
}
