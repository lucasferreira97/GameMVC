namespace GameMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddItens : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.Computadors (Name) VALUES ('PC-Game1')");
            Sql("INSERT INTO dbo.Computadors (Name) VALUES ('PC-Net1')");
            Sql("INSERT INTO dbo.VideoGames (Name) VALUES ('PS4')");
            Sql("INSERT INTO dbo.VideoGames (Name) VALUES ('XBOX-One')");
        }
        
        public override void Down()
        {
        }
    }
}
