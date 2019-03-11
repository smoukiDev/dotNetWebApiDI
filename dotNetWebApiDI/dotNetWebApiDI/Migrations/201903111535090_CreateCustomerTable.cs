namespace dotNetWebApiDI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCustomerTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CUSTOMERS",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FIRSTNAME = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CUSTOMERS");
        }
    }
}
