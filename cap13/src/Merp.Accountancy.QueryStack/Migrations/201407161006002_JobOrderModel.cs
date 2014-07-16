namespace Merp.Web.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JobOrderModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.JobOrders", "IsCompleted", c => c.Boolean(nullable: false));
            DropColumn("dbo.JobOrders", "Number1");
            DropColumn("dbo.JobOrders", "IsCompleted1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JobOrders", "IsCompleted1", c => c.Boolean());
            AddColumn("dbo.JobOrders", "Number1", c => c.String());
            AlterColumn("dbo.JobOrders", "IsCompleted", c => c.Boolean());
        }
    }
}
