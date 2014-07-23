namespace Merp.Web.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JobOrders : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OriginalId = c.Guid(nullable: false),
                        CustomerId = c.Guid(nullable: false),
                        DateOfStart = c.DateTime(nullable: false),
                        DateOfEnd = c.DateTime(),
                        Name = c.String(),
                        IsCompleted = c.Boolean(nullable: false),
                        IsFixedPrice = c.Boolean(nullable: false),
                        IsTimeAndMaterial = c.Boolean(nullable: false),
                        Notes = c.String(),
                        Number = c.String(),
                        Price = c.Decimal(precision: 18, scale: 2),
                        DueDate = c.DateTime(),
                        Value = c.Decimal(precision: 18, scale: 2),
                        DateOfExpiration = c.DateTime(),
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
