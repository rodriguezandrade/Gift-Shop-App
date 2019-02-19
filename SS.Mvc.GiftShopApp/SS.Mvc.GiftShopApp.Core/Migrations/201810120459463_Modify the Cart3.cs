namespace SS.Mvc.GiftShopApp.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifytheCart3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CartItem", "Total");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CartItem", "Total", c => c.Int(nullable: false));
        }
    }
}
