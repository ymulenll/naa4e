namespace Merp.Web.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JobOrders_DateOfCompletion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobOrders", "DateOfCompletion", c => c.DateTime());
            DropColumn("dbo.JobOrders", "DateOfEnd");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JobOrders", "DateOfEnd", c => c.DateTime());
            DropColumn("dbo.JobOrders", "DateOfCompletion");
        }
    }
}
