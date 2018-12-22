namespace Bikely.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRentals : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_id = c.String(nullable: false, maxLength: 128),
                        BikeId = c.Int(nullable: false),
                        Message = c.String(maxLength: 255),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bikes", t => t.BikeId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_id, cascadeDelete: true)
                .Index(t => t.User_id)
                .Index(t => t.BikeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "User_id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Rentals", "BikeId", "dbo.Bikes");
            DropIndex("dbo.Rentals", new[] { "BikeId" });
            DropIndex("dbo.Rentals", new[] { "User_id" });
            DropTable("dbo.Rentals");
        }
    }
}
