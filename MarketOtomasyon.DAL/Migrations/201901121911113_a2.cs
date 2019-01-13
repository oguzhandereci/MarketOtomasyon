namespace MarketOtomasyon.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "kdvRate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.OrderDetails", "productPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Order", "totalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Order", "totalKdvRate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Order", "totalKdvRate");
            DropColumn("dbo.Order", "totalPrice");
            DropColumn("dbo.OrderDetails", "productPrice");
            DropColumn("dbo.OrderDetails", "kdvRate");
        }
    }
}
