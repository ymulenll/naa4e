namespace Merp.Web.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JobOrder_CustomerName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobOrders", "CustomerName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobOrders", "CustomerName");
        }
    }
}
