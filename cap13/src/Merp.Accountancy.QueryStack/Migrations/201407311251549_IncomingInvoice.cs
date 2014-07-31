namespace Merp.Web.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IncomingInvoice : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Invoices", newName: "IncomingInvoices");
            CreateTable(
                "dbo.OutgoingInvoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OriginalId = c.Guid(nullable: false),
                        Number = c.String(),
                        Date = c.DateTime(nullable: false),
                        JobOrderId = c.Guid(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Taxes = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PurchaseOrderNumber = c.String(),
                        Description = c.String(),
                        Customer_OriginalId = c.Guid(nullable: false),
                        Customer_Name = c.String(),
                        Customer_StreetName = c.String(),
                        Customer_PostalCode = c.String(),
                        Customer_City = c.String(),
                        Customer_Country = c.String(),
                        Customer_VatIndex = c.String(),
                        Customer_NationalIdentificationNumber = c.String(),
                        Supplier_OriginalId = c.Guid(nullable: false),
                        Supplier_Name = c.String(),
                        Supplier_StreetName = c.String(),
                        Supplier_PostalCode = c.String(),
                        Supplier_City = c.String(),
                        Supplier_Country = c.String(),
                        Supplier_VatIndex = c.String(),
                        Supplier_NationalIdentificationNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.IncomingInvoices", "Supplier_OriginalId", c => c.Guid(nullable: false));
            AddColumn("dbo.IncomingInvoices", "Supplier_Name", c => c.String());
            AddColumn("dbo.IncomingInvoices", "Supplier_StreetName", c => c.String());
            AddColumn("dbo.IncomingInvoices", "Supplier_PostalCode", c => c.String());
            AddColumn("dbo.IncomingInvoices", "Supplier_City", c => c.String());
            AddColumn("dbo.IncomingInvoices", "Supplier_Country", c => c.String());
            AddColumn("dbo.IncomingInvoices", "Supplier_VatIndex", c => c.String());
            AddColumn("dbo.IncomingInvoices", "Supplier_NationalIdentificationNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.IncomingInvoices", "Supplier_NationalIdentificationNumber");
            DropColumn("dbo.IncomingInvoices", "Supplier_VatIndex");
            DropColumn("dbo.IncomingInvoices", "Supplier_Country");
            DropColumn("dbo.IncomingInvoices", "Supplier_City");
            DropColumn("dbo.IncomingInvoices", "Supplier_PostalCode");
            DropColumn("dbo.IncomingInvoices", "Supplier_StreetName");
            DropColumn("dbo.IncomingInvoices", "Supplier_Name");
            DropColumn("dbo.IncomingInvoices", "Supplier_OriginalId");
            DropTable("dbo.OutgoingInvoices");
            RenameTable(name: "dbo.IncomingInvoices", newName: "Invoices");
        }
    }
}
