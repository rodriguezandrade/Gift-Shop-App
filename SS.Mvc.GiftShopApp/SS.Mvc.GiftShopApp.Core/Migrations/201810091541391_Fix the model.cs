namespace SS.Mvc.GiftShopApp.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fixthemodel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Role", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Role", "Name", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
