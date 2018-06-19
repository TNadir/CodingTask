namespace CodingSolution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applicants",
                c => new
                    {
                        CandidateId = c.Int(nullable: false),
                        SectorId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.CandidateId, t.SectorId })
                .ForeignKey("dbo.Candidates", t => t.CandidateId, cascadeDelete: true)
                .ForeignKey("dbo.Sectors", t => t.SectorId, cascadeDelete: true)
                .Index(t => t.CandidateId)
                .Index(t => t.SectorId);
            
            CreateTable(
                "dbo.Candidates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        AgreementStatus = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sectors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        ParentId = c.Int(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sectors", t => t.ParentId)
                .Index(t => t.ParentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sectors", "ParentId", "dbo.Sectors");
            DropForeignKey("dbo.Applicants", "SectorId", "dbo.Sectors");
            DropForeignKey("dbo.Applicants", "CandidateId", "dbo.Candidates");
            DropIndex("dbo.Sectors", new[] { "ParentId" });
            DropIndex("dbo.Applicants", new[] { "SectorId" });
            DropIndex("dbo.Applicants", new[] { "CandidateId" });
            DropTable("dbo.Sectors");
            DropTable("dbo.Candidates");
            DropTable("dbo.Applicants");
        }
    }
}
