namespace SS.Mvc.GiftShopApp.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sale", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Sale", "UserId", "dbo.User");
            DropIndex("dbo.Sale", new[] { "ProductId" });
            DropIndex("dbo.Sale", new[] { "UserId" });
            DropColumn("dbo.Sale", "ProductId");
            DropColumn("dbo.Sale", "UserId");
            DropColumn("dbo.Sale", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sale", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Sale", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Sale", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.Sale", "UserId");
            CreateIndex("dbo.Sale", "ProductId");
            AddForeignKey("dbo.Sale", "UserId", "dbo.User", "Id");
            AddForeignKey("dbo.Sale", "ProductId", "dbo.Product", "Id");
        }
    }
}
