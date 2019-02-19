namespace SS.Mvc.GiftShopApp.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cart",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdProduct = c.Int(nullable: false),
                        Amounts = c.Int(nullable: false),
                        IdUser = c.Int(nullable: false),
                        Total = c.Int(nullable: false),
                        CompraId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Product_Id = c.Int(),
                        Sale_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.Product_Id)
                .ForeignKey("dbo.Sale", t => t.Sale_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.Sale_Id);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Detail = c.String(),
                        Cost = c.Int(nullable: false),
                        Cant = c.Int(nullable: false),
                        Category = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sale",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        IdCart = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.Cart", "Sale_Id", "dbo.Sale");
            DropForeignKey("dbo.Cart", "Product_Id", "dbo.Product");
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.Cart", new[] { "Sale_Id" });
            DropIndex("dbo.Cart", new[] { "Product_Id" });
            DropTable("dbo.User");
            DropTable("dbo.UserRole");
            DropTable("dbo.Role");
            DropTable("dbo.Sale");
            DropTable("dbo.Product");
            DropTable("dbo.Cart");
        }
    }
}
