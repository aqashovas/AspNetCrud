namespace ProductCruds.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductPrice : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Count", c => c.Decimal(nullable: false, storeType: "money"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Count", c => c.Int(nullable: false));
        }
    }
}
