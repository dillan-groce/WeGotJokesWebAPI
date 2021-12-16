namespace WeGotJokes.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedJoke : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnimalJoke",
                c => new
                    {
                        AnimalJokeId = c.Int(nullable: false, identity: true),
                        JokeCreator = c.Guid(nullable: false),
                        CreatedUTC = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUTC = c.DateTimeOffset(precision: 7),
                        Clean = c.Boolean(nullable: false),
                        Punchline = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AnimalJokeId);
            
            CreateTable(
                "dbo.Rating",
                c => new
                    {
                        RatingId = c.Int(nullable: false, identity: true),
                        StarCount = c.Double(nullable: false),
                        OwnerId = c.Int(nullable: false),
                        DadJokeId = c.Int(nullable: false),
                        AnimalJokeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RatingId)
                .ForeignKey("dbo.AnimalJoke", t => t.AnimalJokeId, cascadeDelete: true)
                .ForeignKey("dbo.DadJoke", t => t.DadJokeId, cascadeDelete: true)
                .Index(t => t.DadJokeId)
                .Index(t => t.AnimalJokeId);
            
            CreateTable(
                "dbo.DadJoke",
                c => new
                    {
                        DadJokeId = c.Int(nullable: false, identity: true),
                        JokeCreator = c.Guid(nullable: false),
                        CreatedUTC = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUTC = c.DateTimeOffset(precision: 7),
                        Clean = c.Boolean(nullable: false),
                        Punchline = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DadJokeId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Rating", "DadJokeId", "dbo.DadJoke");
            DropForeignKey("dbo.Rating", "AnimalJokeId", "dbo.AnimalJoke");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Rating", new[] { "AnimalJokeId" });
            DropIndex("dbo.Rating", new[] { "DadJokeId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.DadJoke");
            DropTable("dbo.Rating");
            DropTable("dbo.AnimalJoke");
        }
    }
}
