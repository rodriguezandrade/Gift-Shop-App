namespace SS.Mvc.GiftShopApp.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modifythenameanddetail : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Category", "Name", c => c.String());
            AlterColumn("dbo.Category", "Detail", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Category", "Detail", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Category", "Name", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
