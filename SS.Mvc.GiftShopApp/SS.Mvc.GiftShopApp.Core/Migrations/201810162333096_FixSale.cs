namespace SS.Mvc.GiftShopApp.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixSale : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sale", "Amount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sale", "Amount");
        }
    }
}
