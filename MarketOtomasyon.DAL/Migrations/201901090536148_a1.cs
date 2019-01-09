namespace MarketOtomasyon.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Barcode", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Products", "StockQuantity", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Packages", "Barcode", c => c.String(nullable: false, maxLength: 20));
            CreateIndex("dbo.Products", "Barcode", unique: true, name: "IX_ProductBarcode");
            CreateIndex("dbo.Packages", "Barcode", unique: true, name: "IX_PackageBarcode");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Packages", "IX_PackageBarcode");
            DropIndex("dbo.Products", "IX_ProductBarcode");
            AlterColumn("dbo.Packages", "Barcode", c => c.String());
            AlterColumn("dbo.Products", "StockQuantity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Products", "Barcode", c => c.String());
        }
    }
}
