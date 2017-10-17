namespace GameMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSignatureName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Computadors", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Games", "nome", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.VideoGames", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VideoGames", "Name", c => c.String());
            AlterColumn("dbo.Games", "nome", c => c.String());
            AlterColumn("dbo.Computadors", "Name", c => c.String());
        }
    }
}
