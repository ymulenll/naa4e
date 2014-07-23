namespace Merp.Registry.QueryStack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Parties : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Parties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OriginalId = c.Guid(nullable: false),
                        DisplayName = c.String(maxLength: 200),
                        VatIndex = c.String(),
                        NationalIdentificationNumber = c.String(),
                        CompanyName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.DisplayName);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Parties", new[] { "DisplayName" });
            DropTable("dbo.Parties");
        }
    }
}
