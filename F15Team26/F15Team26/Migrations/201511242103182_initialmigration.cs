namespace F15Team26.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Employees");
            DropColumn("dbo.Employees", "EmpID");
            
            DropPrimaryKey("dbo.Books");
            DropColumn("dbo.Books", "UniqueNumber");          
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrdersID = c.Int(nullable: false, identity: true),
                        UniqueNumber = c.String(),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrdersID);
            
            CreateTable(
                "dbo.Promotions",
                c => new
                    {
                        PromotionsID = c.String(nullable: false, maxLength: 128),
                        OrderID = c.String(),
                        CouponTypes = c.Int(),
                    })
                .PrimaryKey(t => t.PromotionsID);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SuppliersID = c.Int(nullable: false, identity: true),
                        SupplierName = c.String(nullable: false),
                        OrderAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SuppliersID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FName = c.String(),
                        MI = c.String(),
                        LName = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        States = c.String(),
                        Zipcode = c.String(),
                        Phone = c.String(),
                        CreditCard1 = c.String(),
                        CreditCard1Type = c.String(),
                        CreditCard2 = c.String(),
                        CreditCard2Type = c.String(),
                        CreditCard3 = c.String(),
                        CreditCard3Type = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            AddColumn("dbo.Customers", "Phone", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "Orders_OrdersID", c => c.Int());
            AddColumn("dbo.Employees", "EmployeesID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Employees", "EmpNumber", c => c.String());
            AddColumn("dbo.Employees", "Phone", c => c.String(nullable: false));
            AddColumn("dbo.Employees", "EmployeeTypes", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "Books_BooksID", c => c.Int());
            AddColumn("dbo.Books", "BooksID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Books", "Promotions_PromotionsID", c => c.String(maxLength: 128));
            AlterColumn("dbo.Customers", "CreditCard1", c => c.String());
            AddColumn("dbo.Books", "UniqueNumber", c => c.String());
            AddPrimaryKey("dbo.Books", "BooksID");
            AlterColumn("dbo.Books", "PublicationDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Books", "Reviews", c => c.String(nullable: false));
            AddPrimaryKey("dbo.Employees", "EmployeesID");
           
            CreateIndex("dbo.Books", "Promotions_PromotionsID");
            CreateIndex("dbo.Employees", "Books_BooksID");
            CreateIndex("dbo.Customers", "Orders_OrdersID");
            AddForeignKey("dbo.Employees", "Books_BooksID", "dbo.Books", "BooksID");
            AddForeignKey("dbo.Customers", "Orders_OrdersID", "dbo.Orders", "OrdersID");
            AddForeignKey("dbo.Books", "Promotions_PromotionsID", "dbo.Promotions", "PromotionsID");
            DropColumn("dbo.Customers", "PhoneNumber");
       
            DropColumn("dbo.Employees", "PhoneNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "PhoneNumber", c => c.String(nullable: false));
            AddColumn("dbo.Employees", "EmpID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Customers", "PhoneNumber", c => c.String(nullable: false));
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Books", "Promotions_PromotionsID", "dbo.Promotions");
            DropForeignKey("dbo.Customers", "Orders_OrdersID", "dbo.Orders");
            DropForeignKey("dbo.Employees", "Books_BooksID", "dbo.Books");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Customers", new[] { "Orders_OrdersID" });
            DropIndex("dbo.Employees", new[] { "Books_BooksID" });
            DropIndex("dbo.Books", new[] { "Promotions_PromotionsID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropPrimaryKey("dbo.Books");
            DropPrimaryKey("dbo.Employees");
            AlterColumn("dbo.Books", "Reviews", c => c.String());
            AlterColumn("dbo.Books", "PublicationDate", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "UniqueNumber", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Customers", "CreditCard1", c => c.String(nullable: false));
            DropColumn("dbo.Books", "Promotions_PromotionsID");
            DropColumn("dbo.Books", "BooksID");
            DropColumn("dbo.Employees", "Books_BooksID");
            DropColumn("dbo.Employees", "EmployeeTypes");
            DropColumn("dbo.Employees", "Phone");
            DropColumn("dbo.Employees", "EmpNumber");
            DropColumn("dbo.Employees", "EmployeesID");
            DropColumn("dbo.Customers", "Orders_OrdersID");
            DropColumn("dbo.Customers", "Phone");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Promotions");
            DropTable("dbo.Orders");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            AddPrimaryKey("dbo.Books", "UniqueNumber");
            AddPrimaryKey("dbo.Employees", "EmpID");
        }
    }
}
