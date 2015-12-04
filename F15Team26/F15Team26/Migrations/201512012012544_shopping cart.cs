namespace F15Team26.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shoppingcart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        RecordID = c.Int(nullable: false, identity: true),
                        CartID = c.Int(nullable: false),
                        BooksID = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RecordID)
                .ForeignKey("dbo.Books", t => t.BooksID, cascadeDelete: true)
                .Index(t => t.BooksID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailId = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        BooksID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Order_OrdersID = c.Int(),
                    })
                .PrimaryKey(t => t.OrderDetailId)
                .ForeignKey("dbo.Books", t => t.BooksID, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_OrdersID)
                .Index(t => t.BooksID)
                .Index(t => t.Order_OrdersID);
            
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        ShoppingCartID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ShoppingCartID);
            
            AddColumn("dbo.Orders", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Orders", "TotalAmount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "TotalAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropForeignKey("dbo.OrderDetails", "Order_OrdersID", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "BooksID", "dbo.Books");
            DropForeignKey("dbo.Carts", "BooksID", "dbo.Books");
            DropIndex("dbo.OrderDetails", new[] { "Order_OrdersID" });
            DropIndex("dbo.OrderDetails", new[] { "BooksID" });
            DropIndex("dbo.Carts", new[] { "BooksID" });
            DropColumn("dbo.Orders", "Total");
            DropTable("dbo.ShoppingCarts");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Carts");
        }
    }
}
