namespace ProductCruds.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductsMoney : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Price", c => c.Decimal(nullable: false, storeType: "money"));
            AlterColumn("dbo.Products", "Count", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Count", c => c.Decimal(nullable: false, storeType: "money"));
            AlterColumn("dbo.Products", "Price", c => c.Int(nullable: false));
        }
    }
}
