namespace GameMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddItens : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.Computadors (Name) VALUES ('PC-GAME1')");
            Sql("INSERT INTO dbo.Computadors (Name) VALUES ('PC-NET1')");
            Sql("INSERT INTO dbo.VideoGames (Name) VALUES ('PS4')");
            Sql("INSERT INTO dbo.VideoGames (Name) VALUES ('XBOX-ONE')");
            Sql("INSERT INTO dbo.Games (Nome) VALUES ('Call of Duty World War II')");
            Sql("INSERT INTO dbo.Games (Nome) VALUES ('Forza Horizon 3')");
            Sql("INSERT INTO dbo.SignatureCustomers (Id, Bonus, EndsIn) VALUES (1, 30, 20)");
            Sql("INSERT INTO dbo.SignatureCustomers (Id, Bonus, EndsIn) VALUES (2, 50, 10)");
            Sql("INSERT INTO dbo.Customers (Name, isPremium, SignatureCustomerId) VALUES ('Trevor Belmont', 1, 1)");
            Sql("INSERT INTO dbo.Customers (Name, isPremium, SignatureCustomerId) VALUES ('James Bond', 0, 2)");


        }
        
        public override void Down()
        {
        }
    }
}
