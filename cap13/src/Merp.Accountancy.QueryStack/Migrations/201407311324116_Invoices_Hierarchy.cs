namespace Merp.Web.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Invoices_Hierarchy : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.IncomingInvoices", "Customer_OriginalId");
            DropColumn("dbo.IncomingInvoices", "Customer_Name");
            DropColumn("dbo.IncomingInvoices", "Customer_StreetName");
            DropColumn("dbo.IncomingInvoices", "Customer_PostalCode");
            DropColumn("dbo.IncomingInvoices", "Customer_City");
            DropColumn("dbo.IncomingInvoices", "Customer_Country");
            DropColumn("dbo.IncomingInvoices", "Customer_VatIndex");
            DropColumn("dbo.IncomingInvoices", "Customer_NationalIdentificationNumber");
            DropColumn("dbo.OutgoingInvoices", "Supplier_OriginalId");
            DropColumn("dbo.OutgoingInvoices", "Supplier_Name");
            DropColumn("dbo.OutgoingInvoices", "Supplier_StreetName");
            DropColumn("dbo.OutgoingInvoices", "Supplier_PostalCode");
            DropColumn("dbo.OutgoingInvoices", "Supplier_City");
            DropColumn("dbo.OutgoingInvoices", "Supplier_Country");
            DropColumn("dbo.OutgoingInvoices", "Supplier_VatIndex");
            DropColumn("dbo.OutgoingInvoices", "Supplier_NationalIdentificationNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OutgoingInvoices", "Supplier_NationalIdentificationNumber", c => c.String());
            AddColumn("dbo.OutgoingInvoices", "Supplier_VatIndex", c => c.String());
            AddColumn("dbo.OutgoingInvoices", "Supplier_Country", c => c.String());
            AddColumn("dbo.OutgoingInvoices", "Supplier_City", c => c.String());
            AddColumn("dbo.OutgoingInvoices", "Supplier_PostalCode", c => c.String());
            AddColumn("dbo.OutgoingInvoices", "Supplier_StreetName", c => c.String());
            AddColumn("dbo.OutgoingInvoices", "Supplier_Name", c => c.String());
            AddColumn("dbo.OutgoingInvoices", "Supplier_OriginalId", c => c.Guid(nullable: false));
            AddColumn("dbo.IncomingInvoices", "Customer_NationalIdentificationNumber", c => c.String());
            AddColumn("dbo.IncomingInvoices", "Customer_VatIndex", c => c.String());
            AddColumn("dbo.IncomingInvoices", "Customer_Country", c => c.String());
            AddColumn("dbo.IncomingInvoices", "Customer_City", c => c.String());
            AddColumn("dbo.IncomingInvoices", "Customer_PostalCode", c => c.String());
            AddColumn("dbo.IncomingInvoices", "Customer_StreetName", c => c.String());
            AddColumn("dbo.IncomingInvoices", "Customer_Name", c => c.String());
            AddColumn("dbo.IncomingInvoices", "Customer_OriginalId", c => c.Guid(nullable: false));
        }
    }
}
