namespace WeGotJokes.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JokeCreate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rating", "AnimalJokeId", "dbo.AnimalJoke");
            DropForeignKey("dbo.Rating", "DadJokeId", "dbo.DadJoke");
            DropIndex("dbo.Rating", new[] { "DadJokeId" });
            DropIndex("dbo.Rating", new[] { "AnimalJokeId" });
            AlterColumn("dbo.Rating", "DadJokeId", c => c.Int());
            AlterColumn("dbo.Rating", "AnimalJokeId", c => c.Int());
            CreateIndex("dbo.Rating", "DadJokeId");
            CreateIndex("dbo.Rating", "AnimalJokeId");
            AddForeignKey("dbo.Rating", "AnimalJokeId", "dbo.AnimalJoke", "AnimalJokeId");
            AddForeignKey("dbo.Rating", "DadJokeId", "dbo.DadJoke", "DadJokeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rating", "DadJokeId", "dbo.DadJoke");
            DropForeignKey("dbo.Rating", "AnimalJokeId", "dbo.AnimalJoke");
            DropIndex("dbo.Rating", new[] { "AnimalJokeId" });
            DropIndex("dbo.Rating", new[] { "DadJokeId" });
            AlterColumn("dbo.Rating", "AnimalJokeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Rating", "DadJokeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Rating", "AnimalJokeId");
            CreateIndex("dbo.Rating", "DadJokeId");
            AddForeignKey("dbo.Rating", "DadJokeId", "dbo.DadJoke", "DadJokeId", cascadeDelete: true);
            AddForeignKey("dbo.Rating", "AnimalJokeId", "dbo.AnimalJoke", "AnimalJokeId", cascadeDelete: true);
        }
    }
}
