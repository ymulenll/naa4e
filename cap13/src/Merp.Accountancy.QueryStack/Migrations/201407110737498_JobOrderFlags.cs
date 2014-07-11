namespace Merp.Web.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JobOrderFlags : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OriginalId = c.Guid(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        DateOfStart = c.DateTime(nullable: false),
                        DateOfEnd = c.DateTime(),
                        Name = c.String(),
                        IsFixedPrice = c.Boolean(nullable: false),
                        IsTimeAndMaterial = c.Boolean(nullable: false),
                        Price = c.Decimal(precision: 18, scale: 2),
                        Number = c.String(),
                        DueDate = c.DateTime(),
                        IsCompleted = c.Boolean(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);           
        }
        
        public override void Down()
        {
            DropTable("dbo.JobOrders");
        }
    }
}
