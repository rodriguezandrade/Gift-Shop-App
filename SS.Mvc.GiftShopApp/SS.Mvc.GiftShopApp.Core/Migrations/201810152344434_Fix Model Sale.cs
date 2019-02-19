namespace SS.Mvc.GiftShopApp.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixModelSale : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CartItem", "Sale_Id", "dbo.Sale");
            DropIndex("dbo.CartItem", new[] { "Sale_Id" });
            AddColumn("dbo.Sale", "ProductId", c => c.Int(nullable: false));
            AddColumn("dbo.Sale", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Sale", "subTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            CreateIndex("dbo.Sale", "ProductId");
            CreateIndex("dbo.Sale", "UserId");
            AddForeignKey("dbo.Sale", "ProductId", "dbo.Product", "Id");
            AddForeignKey("dbo.Sale", "UserId", "dbo.User", "Id");
            DropColumn("dbo.CartItem", "Sale_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CartItem", "Sale_Id", c => c.Int());
            DropForeignKey("dbo.Sale", "UserId", "dbo.User");
            DropForeignKey("dbo.Sale", "ProductId", "dbo.Product");
            DropIndex("dbo.Sale", new[] { "UserId" });
            DropIndex("dbo.Sale", new[] { "ProductId" });
            DropColumn("dbo.Sale", "subTotal");
            DropColumn("dbo.Sale", "Amount");
            DropColumn("dbo.Sale", "ProductId");
            CreateIndex("dbo.CartItem", "Sale_Id");
            AddForeignKey("dbo.CartItem", "Sale_Id", "dbo.Sale", "Id");
        }
    }
}
