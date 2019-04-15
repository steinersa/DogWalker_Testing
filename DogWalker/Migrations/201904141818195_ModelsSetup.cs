namespace DogWalker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelsSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Demeanors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AnimalFriendly = c.Boolean(nullable: false),
                        KidFriendly = c.Boolean(nullable: false),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Dogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        Breed = c.String(nullable: false),
                        Size = c.String(nullable: false),
                        SpayedNeutered = c.Boolean(nullable: false),
                        Rating = c.Int(),
                        OwnerId = c.Int(nullable: false),
                        HealthId = c.Int(nullable: false),
                        DemeanorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Demeanors", t => t.DemeanorId, cascadeDelete: true)
                .ForeignKey("dbo.Healths", t => t.HealthId, cascadeDelete: true)
                .ForeignKey("dbo.Owners", t => t.OwnerId, cascadeDelete: true)
                .Index(t => t.OwnerId)
                .Index(t => t.HealthId)
                .Index(t => t.DemeanorId);
            
            CreateTable(
                "dbo.Healths",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HeartCondition = c.Boolean(nullable: false),
                        SeizureCondition = c.Boolean(nullable: false),
                        Allergies = c.Boolean(nullable: false),
                        Blind = c.Boolean(nullable: false),
                        Deaf = c.Boolean(nullable: false),
                        PhysicalLimitations = c.Boolean(nullable: false),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Street = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Zip = c.String(nullable: false),
                        ApplicationId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationId)
                .Index(t => t.ApplicationId);
            
            CreateTable(
                "dbo.WalkDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Time = c.DateTime(nullable: false),
                        Distance = c.Double(nullable: false),
                        NumberOfDogs = c.Int(nullable: false),
                        WalkId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Walks", t => t.WalkId, cascadeDelete: true)
                .Index(t => t.WalkId);
            
            CreateTable(
                "dbo.Walks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WalkerApprovalStatus = c.String(),
                        OwnersApprovalStatus = c.String(),
                        WalkComplete = c.Boolean(nullable: false),
                        OwnerId = c.Int(nullable: false),
                        WalkerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Owners", t => t.OwnerId, cascadeDelete: true)
                .ForeignKey("dbo.Walkers", t => t.WalkerId, cascadeDelete: true)
                .Index(t => t.OwnerId)
                .Index(t => t.WalkerId);
            
            CreateTable(
                "dbo.Walkers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Street = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Zip = c.String(nullable: false),
                        Rating = c.Int(),
                        ApplicationId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationId)
                .Index(t => t.ApplicationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WalkDetails", "WalkId", "dbo.Walks");
            DropForeignKey("dbo.Walks", "WalkerId", "dbo.Walkers");
            DropForeignKey("dbo.Walkers", "ApplicationId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Walks", "OwnerId", "dbo.Owners");
            DropForeignKey("dbo.Dogs", "OwnerId", "dbo.Owners");
            DropForeignKey("dbo.Owners", "ApplicationId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Dogs", "HealthId", "dbo.Healths");
            DropForeignKey("dbo.Dogs", "DemeanorId", "dbo.Demeanors");
            DropIndex("dbo.Walkers", new[] { "ApplicationId" });
            DropIndex("dbo.Walks", new[] { "WalkerId" });
            DropIndex("dbo.Walks", new[] { "OwnerId" });
            DropIndex("dbo.WalkDetails", new[] { "WalkId" });
            DropIndex("dbo.Owners", new[] { "ApplicationId" });
            DropIndex("dbo.Dogs", new[] { "DemeanorId" });
            DropIndex("dbo.Dogs", new[] { "HealthId" });
            DropIndex("dbo.Dogs", new[] { "OwnerId" });
            DropTable("dbo.Walkers");
            DropTable("dbo.Walks");
            DropTable("dbo.WalkDetails");
            DropTable("dbo.Owners");
            DropTable("dbo.Healths");
            DropTable("dbo.Dogs");
            DropTable("dbo.Demeanors");
        }
    }
}
