namespace PetHotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Zip = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false, maxLength: 8),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        Totalprice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.InvoiceId)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        OrderItemID = c.Int(nullable: false, identity: true),
                        Spiece = c.String(),
                        Petname = c.String(nullable: false),
                        Arrival = c.DateTime(nullable: false),
                        Departure = c.DateTime(nullable: false),
                        PricePerDay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NumberOfDays = c.Int(nullable: false),
                        InvoiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderItemID)
                .ForeignKey("dbo.Invoices", t => t.InvoiceId, cascadeDelete: true)
                .Index(t => t.InvoiceId);
            
            CreateTable(
                "dbo.PriceLists",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Spice = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "CustomerID", "dbo.Customers");
            DropIndex("dbo.OrderItems", new[] { "InvoiceId" });
            DropIndex("dbo.Invoices", new[] { "CustomerID" });
            DropTable("dbo.PriceLists");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Invoices");
            DropTable("dbo.Customers");
        }
    }
}
