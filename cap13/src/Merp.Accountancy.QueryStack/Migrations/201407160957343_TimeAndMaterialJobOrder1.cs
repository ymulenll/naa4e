namespace Merp.Web.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TimeAndMaterialJobOrder1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobOrders", "Notes", c => c.String());
            AddColumn("dbo.JobOrders", "Value", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.JobOrders", "HourlyFee");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JobOrders", "HourlyFee", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.JobOrders", "Value");
            DropColumn("dbo.JobOrders", "Notes");
        }
    }
}
