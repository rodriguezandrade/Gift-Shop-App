namespace SS.Mvc.GiftShopApp.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Detail = c.String(),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cant = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Detail = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccessFailedCount = c.Int(nullable: false),
                        LockoutEndDate = c.DateTime(),
                        Email = c.String(nullable: false, maxLength: 150),
                        IsEmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 50),
                        SecurityStamp = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Role", t => t.RoleId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sale",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Amount = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.SaleDetail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        subTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductId = c.Int(nullable: false),
                        SaleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .ForeignKey("dbo.Sale", t => t.SaleId)
                .Index(t => t.ProductId)
                .Index(t => t.SaleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sale", "UserId", "dbo.User");
            DropForeignKey("dbo.SaleDetail", "SaleId", "dbo.Sale");
            DropForeignKey("dbo.SaleDetail", "ProductId", "dbo.Product");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.CartItem", "UserId", "dbo.User");
            DropForeignKey("dbo.CartItem", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Product", "Category_Id", "dbo.Category");
            DropIndex("dbo.SaleDetail", new[] { "SaleId" });
            DropIndex("dbo.SaleDetail", new[] { "ProductId" });
            DropIndex("dbo.Sale", new[] { "UserId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.Product", new[] { "Category_Id" });
            DropIndex("dbo.CartItem", new[] { "ProductId" });
            DropIndex("dbo.CartItem", new[] { "UserId" });
            DropTable("dbo.SaleDetail");
            DropTable("dbo.Sale");
            DropTable("dbo.Role");
            DropTable("dbo.UserRole");
            DropTable("dbo.User");
            DropTable("dbo.Category");
            DropTable("dbo.Product");
            DropTable("dbo.CartItem");
        }
    }
}
