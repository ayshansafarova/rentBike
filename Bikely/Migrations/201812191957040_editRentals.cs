namespace Bikely.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editRentals : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rentals", "isAccepted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rentals", "isAccepted");
        }
    }
}
