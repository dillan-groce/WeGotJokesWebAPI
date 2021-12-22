namespace WeGotJokes.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JokeDatabase1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DadJoke", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DadJoke", "MyProperty", c => c.Int(nullable: false));
        }
    }
}
