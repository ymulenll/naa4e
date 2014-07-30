namespace Merp.Web.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JobOrders_PO_Description : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobOrders", "Description", c => c.String());
            DropColumn("dbo.JobOrders", "Notes");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JobOrders", "Notes", c => c.String());
            DropColumn("dbo.JobOrders", "Description");
        }
    }
}
