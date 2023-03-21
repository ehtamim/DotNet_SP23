namespace ZeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FoodRequests", "PreserveDate", c => c.String());
            AlterColumn("dbo.FoodRequests", "Request_Date", c => c.String());
            AlterColumn("dbo.FoodRequests", "Action_Date", c => c.String());
            AlterColumn("dbo.FoodRequests", "Delivery_Date", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FoodRequests", "Delivery_Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FoodRequests", "Action_Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FoodRequests", "Request_Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FoodRequests", "PreserveDate", c => c.DateTime(nullable: false));
        }
    }
}
