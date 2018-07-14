namespace MySchoolCollege.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MiseAjourDb5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MotifSanctions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Motif = c.String(),
                        Dossier = c.Boolean(nullable: false),
                        TypeMotif_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TypeMotifs", t => t.TypeMotif_Id)
                .Index(t => t.TypeMotif_Id);
            
            CreateTable(
                "dbo.TypeMotifs",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Punitions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Genre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sanctions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Exclusion = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MotifSanctions", "TypeMotif_Id", "dbo.TypeMotifs");
            DropIndex("dbo.MotifSanctions", new[] { "TypeMotif_Id" });
            DropTable("dbo.Sanctions");
            DropTable("dbo.Punitions");
            DropTable("dbo.TypeMotifs");
            DropTable("dbo.MotifSanctions");
        }
    }
}
