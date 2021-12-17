namespace WeGotJokes.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateJokes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rating", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rating", "OwnerId", c => c.Int(nullable: false));
        }
    }
}
