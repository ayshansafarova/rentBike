namespace Bikely.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBikeCategoryclasses1 : DbMigration
    {
        public override void Up()
        {
            //AlterColumn("dbo.Bikes", "priceWeekly", c => c.Int());
            //AlterColumn("dbo.Bikes", "priceMonthly", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bikes", "priceMonthly", c => c.Int(nullable: false));
            AlterColumn("dbo.Bikes", "priceWeekly", c => c.Int(nullable: false));
        }
    }
}
