namespace Merp.Registry.QueryStack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Person : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Parties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OriginalId = c.Guid(nullable: false),
                        DisplayName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Parties");
        }
    }
}
