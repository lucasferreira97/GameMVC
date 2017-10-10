namespace GameMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewCustomers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "SignatureCustomerId", "dbo.SignatureCustomers");
            DropIndex("dbo.Customers", new[] { "SignatureCustomerId" });
            DropTable("dbo.SignatureCustomers");
            Sql("INSERT INTO dbo.Customers (Name, isPremium) VALUES ('Trevorn Belmont', 1)");
            Sql("INSERT INTO dbo.Customers (Name, isPremium) VALUES ('Bob L. Swagger', 0)");
            Sql("INSERT INTO dbo.Customers (Name, isPremium) VALUES ('Jhonson Rubak', 1)");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SignatureCustomers",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Bonus = c.Byte(nullable: false),
                        EndsIn = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Customers", "SignatureCustomerId");
            AddForeignKey("dbo.Customers", "SignatureCustomerId", "dbo.SignatureCustomers", "Id", cascadeDelete: true);
        }
    }
}
