namespace BocceBall.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FINALLYsolvedCONNSTRINGerror : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        HomeTeamID = c.Int(),
                        AwayTeamID = c.Int(),
                        HomeScore = c.Int(nullable: false),
                        AwayScore = c.Int(nullable: false),
                        DateHappened = c.DateTime(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Teams", t => t.AwayTeamID)
                .ForeignKey("dbo.Teams", t => t.HomeTeamID)
                .Index(t => t.HomeTeamID)
                .Index(t => t.AwayTeamID);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Mascot = c.String(),
                        Color = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        NickName = c.String(),
                        Number = c.Int(nullable: false),
                        ThrowingArm = c.String(),
                        TeamID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Teams", t => t.TeamID)
                .Index(t => t.TeamID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Players", "TeamID", "dbo.Teams");
            DropForeignKey("dbo.Games", "HomeTeamID", "dbo.Teams");
            DropForeignKey("dbo.Games", "AwayTeamID", "dbo.Teams");
            DropIndex("dbo.Players", new[] { "TeamID" });
            DropIndex("dbo.Games", new[] { "AwayTeamID" });
            DropIndex("dbo.Games", new[] { "HomeTeamID" });
            DropTable("dbo.Players");
            DropTable("dbo.Teams");
            DropTable("dbo.Games");
        }
    }
}
