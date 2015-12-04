namespace F15Team26.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class data : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Orders", "OrderDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "OrderDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Orders", "Date");
            DropColumn("dbo.Carts", "DateCreated");
        }
    }
}
