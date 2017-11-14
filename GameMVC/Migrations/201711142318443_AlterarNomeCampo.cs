namespace GameMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterarNomeCampo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "Name", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Games", "nome");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "nome", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Games", "Name");
        }
    }
}
