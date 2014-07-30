namespace Merp.Web.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JobOrders_PO : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobOrders", "PurchaseOrderNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobOrders", "PurchaseOrderNumber");
        }
    }
}
