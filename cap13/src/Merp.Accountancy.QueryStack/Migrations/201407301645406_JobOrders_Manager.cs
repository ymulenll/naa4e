namespace Merp.Web.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JobOrders_Manager : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobOrders", "ManagerId", c => c.Guid(nullable: false));
            AddColumn("dbo.JobOrders", "ManagerName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobOrders", "ManagerName");
            DropColumn("dbo.JobOrders", "ManagerId");
        }
    }
}
