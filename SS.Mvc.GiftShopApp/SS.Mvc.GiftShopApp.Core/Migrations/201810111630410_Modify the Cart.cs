namespace SS.Mvc.GiftShopApp.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifytheCart : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CartItem", "SubTotal", c => c.Int(nullable: false));
            AddColumn("dbo.Sale", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Sale", "IdCart");
            DropColumn("dbo.Sale", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sale", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Sale", "IdCart", c => c.Int(nullable: false));
            DropColumn("dbo.Sale", "Total");
            DropColumn("dbo.CartItem", "SubTotal");
        }
    }
}
