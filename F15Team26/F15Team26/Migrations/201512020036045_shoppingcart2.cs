namespace F15Team26.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shoppingcart2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "OrderDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Carts", "DateCreated");
            DropColumn("dbo.Orders", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Carts", "DateCreated", c => c.DateTime(nullable: false));
            DropColumn("dbo.Orders", "OrderDate");
        }
    }
}
