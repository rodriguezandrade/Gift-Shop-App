namespace SS.Mvc.GiftShopApp.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fixthemodelcart : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Cart", newName: "CartItem");
            DropIndex("dbo.CartItem", new[] { "Product_Id" });
            RenameColumn(table: "dbo.CartItem", name: "Product_Id", newName: "ProductId");
            AddColumn("dbo.CartItem", "Amount", c => c.Int(nullable: false));
            AddColumn("dbo.CartItem", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.CartItem", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.CartItem", "ProductId");
            CreateIndex("dbo.CartItem", "UserId");
            AddForeignKey("dbo.CartItem", "UserId", "dbo.User", "Id");
            DropColumn("dbo.CartItem", "IdProduct");
            DropColumn("dbo.CartItem", "Amounts");
            DropColumn("dbo.CartItem", "IdUser");
            DropColumn("dbo.CartItem", "CompraId");
            DropColumn("dbo.CartItem", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CartItem", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.CartItem", "CompraId", c => c.Int(nullable: false));
            AddColumn("dbo.CartItem", "IdUser", c => c.Int(nullable: false));
            AddColumn("dbo.CartItem", "Amounts", c => c.Int(nullable: false));
            AddColumn("dbo.CartItem", "IdProduct", c => c.Int(nullable: false));
            DropForeignKey("dbo.CartItem", "UserId", "dbo.User");
            DropIndex("dbo.CartItem", new[] { "UserId" });
            DropIndex("dbo.CartItem", new[] { "ProductId" });
            AlterColumn("dbo.CartItem", "ProductId", c => c.Int());
            DropColumn("dbo.CartItem", "UserId");
            DropColumn("dbo.CartItem", "Amount");
            RenameColumn(table: "dbo.CartItem", name: "ProductId", newName: "Product_Id");
            CreateIndex("dbo.CartItem", "Product_Id");
            RenameTable(name: "dbo.CartItem", newName: "Cart");
        }
    }
}
