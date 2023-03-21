namespace ZeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Foods", "FoodReqId", "dbo.FoodRequests");
            DropIndex("dbo.Foods", new[] { "FoodReqId" });
            AddColumn("dbo.FoodRequests", "Description", c => c.String(nullable: false, maxLength: 200));
            DropTable("dbo.Foods");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Quantity = c.String(nullable: false),
                        FoodReqId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.FoodRequests", "Description");
            CreateIndex("dbo.Foods", "FoodReqId");
            AddForeignKey("dbo.Foods", "FoodReqId", "dbo.FoodRequests", "Id", cascadeDelete: true);
        }
    }
}
