namespace MarketOtomasyon.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Order", "totalPrice");
            DropColumn("dbo.Order", "totalKdvRate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order", "totalKdvRate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Order", "totalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
