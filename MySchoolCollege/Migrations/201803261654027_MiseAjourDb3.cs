namespace MySchoolCollege.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MiseAjourDb3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AvisCEs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Avis = c.String(),
                        Brevet = c.Boolean(nullable: false),
                        LivretStandard = c.Boolean(nullable: false),
                        LivretBacGeneral = c.Boolean(nullable: false),
                        LivretBacPro = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Filieres",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                        LivretScolaire = c.String(),
                        TypeEtablissement_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TypeEtablissements", t => t.TypeEtablissement_Id)
                .Index(t => t.TypeEtablissement_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Filieres", "TypeEtablissement_Id", "dbo.TypeEtablissements");
            DropIndex("dbo.Filieres", new[] { "TypeEtablissement_Id" });
            DropTable("dbo.Filieres");
            DropTable("dbo.AvisCEs");
        }
    }
}
