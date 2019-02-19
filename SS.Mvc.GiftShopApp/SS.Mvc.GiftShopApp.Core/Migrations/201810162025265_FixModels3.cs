namespace SS.Mvc.GiftShopApp.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixModels3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SaleDetail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        subTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        ProductId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        SaleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .ForeignKey("dbo.Sale", t => t.SaleId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.ProductId)
                .Index(t => t.UserId)
                .Index(t => t.SaleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SaleDetail", "UserId", "dbo.User");
            DropForeignKey("dbo.SaleDetail", "SaleId", "dbo.Sale");
            DropForeignKey("dbo.SaleDetail", "ProductId", "dbo.Product");
            DropIndex("dbo.SaleDetail", new[] { "SaleId" });
            DropIndex("dbo.SaleDetail", new[] { "UserId" });
            DropIndex("dbo.SaleDetail", new[] { "ProductId" });
            DropTable("dbo.SaleDetail");
        }
    }
}
