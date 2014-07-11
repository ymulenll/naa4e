namespace Merp.Web.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TimeAndMaterialJobOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobOrders", "HourlyFee", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.JobOrders", "Number1", c => c.String());
            AddColumn("dbo.JobOrders", "DateOfExpiration", c => c.DateTime());
            AddColumn("dbo.JobOrders", "IsCompleted1", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobOrders", "IsCompleted1");
            DropColumn("dbo.JobOrders", "DateOfExpiration");
            DropColumn("dbo.JobOrders", "Number1");
            DropColumn("dbo.JobOrders", "HourlyFee");
        }
    }
}
