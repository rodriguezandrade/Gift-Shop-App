namespace SS.Mvc.GiftShopApp.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModAddColumnCategoryIdToProduct : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Product", new[] { "Category_Id" });
            RenameColumn(table: "dbo.Product", name: "Category_Id", newName: "CategoryId");
            AlterColumn("dbo.Product", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Product", "CategoryId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Product", new[] { "CategoryId" });
            AlterColumn("dbo.Product", "CategoryId", c => c.Int());
            RenameColumn(table: "dbo.Product", name: "CategoryId", newName: "Category_Id");
            CreateIndex("dbo.Product", "Category_Id");
        }
    }
}
