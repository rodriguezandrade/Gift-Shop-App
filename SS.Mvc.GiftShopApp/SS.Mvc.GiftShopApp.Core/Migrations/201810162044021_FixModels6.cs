namespace SS.Mvc.GiftShopApp.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixModels6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SaleDetail", "UserId", "dbo.User");
            DropIndex("dbo.SaleDetail", new[] { "UserId" });
            AddColumn("dbo.Sale", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Sale", "UserId");
            AddForeignKey("dbo.Sale", "UserId", "dbo.User", "Id");
            DropColumn("dbo.Sale", "Amount");
            DropColumn("dbo.Sale", "subTotal");
            DropColumn("dbo.SaleDetail", "Total");
            DropColumn("dbo.SaleDetail", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SaleDetail", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.SaleDetail", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Sale", "subTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Sale", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropForeignKey("dbo.Sale", "UserId", "dbo.User");
            DropIndex("dbo.Sale", new[] { "UserId" });
            DropColumn("dbo.Sale", "UserId");
            CreateIndex("dbo.SaleDetail", "UserId");
            AddForeignKey("dbo.SaleDetail", "UserId", "dbo.User", "Id");
        }
    }
}
