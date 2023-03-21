namespace ZeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ZHContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AcceptedRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FoodRequestId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.FoodRequests", t => t.FoodRequestId, cascadeDelete: true)
                .Index(t => t.FoodRequestId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 100),
                        PhoneNumber = c.String(nullable: false, maxLength: 20),
                        NgoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NGOes", t => t.NgoId, cascadeDelete: true)
                .Index(t => t.NgoId);
            
            CreateTable(
                "dbo.NGOes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 100),
                        PhoneNumber = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FoodRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PreserveDate = c.DateTime(nullable: false),
                        ResturantId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Request_Date = c.DateTime(nullable: false),
                        Action_Date = c.DateTime(nullable: false),
                        Delivery_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Resturants", t => t.ResturantId, cascadeDelete: true)
                .Index(t => t.ResturantId);
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Quantity = c.String(nullable: false),
                        FoodReqId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FoodRequests", t => t.FoodReqId, cascadeDelete: true)
                .Index(t => t.FoodReqId);
            
            CreateTable(
                "dbo.Resturants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 100),
                        PhoneNumber = c.String(nullable: false, maxLength: 20),
                        Location = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AcceptedRequests", "FoodRequestId", "dbo.FoodRequests");
            DropForeignKey("dbo.FoodRequests", "ResturantId", "dbo.Resturants");
            DropForeignKey("dbo.Foods", "FoodReqId", "dbo.FoodRequests");
            DropForeignKey("dbo.AcceptedRequests", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "NgoId", "dbo.NGOes");
            DropIndex("dbo.Foods", new[] { "FoodReqId" });
            DropIndex("dbo.FoodRequests", new[] { "ResturantId" });
            DropIndex("dbo.Employees", new[] { "NgoId" });
            DropIndex("dbo.AcceptedRequests", new[] { "EmployeeId" });
            DropIndex("dbo.AcceptedRequests", new[] { "FoodRequestId" });
            DropTable("dbo.Resturants");
            DropTable("dbo.Foods");
            DropTable("dbo.FoodRequests");
            DropTable("dbo.NGOes");
            DropTable("dbo.Employees");
            DropTable("dbo.AcceptedRequests");
        }
    }
}
