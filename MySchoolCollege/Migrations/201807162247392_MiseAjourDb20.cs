namespace MySchoolCollege.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MiseAjourDb20 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AvisOrientations",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Avis = c.String(),
                        Commentaires = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DemandeOrientations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EtablissementDemander = c.String(),
                        Commentaires = c.String(),
                        CreerLe = c.DateTime(nullable: false),
                        ModifierLe = c.DateTime(nullable: false),
                        CreerPar_Id = c.String(maxLength: 128),
                        ModifierPar_Id = c.String(maxLength: 128),
                        Option_Id = c.String(maxLength: 128),
                        Specialite_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreerPar_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ModifierPar_Id)
                .ForeignKey("dbo.OptionSpecialites", t => t.Option_Id)
                .ForeignKey("dbo.SpecialiteOrientations", t => t.Specialite_Id)
                .Index(t => t.CreerPar_Id)
                .Index(t => t.ModifierPar_Id)
                .Index(t => t.Option_Id)
                .Index(t => t.Specialite_Id);
            
            CreateTable(
                "dbo.Notations",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DemandeOrientations", "Specialite_Id", "dbo.SpecialiteOrientations");
            DropForeignKey("dbo.DemandeOrientations", "Option_Id", "dbo.OptionSpecialites");
            DropForeignKey("dbo.DemandeOrientations", "ModifierPar_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.DemandeOrientations", "CreerPar_Id", "dbo.AspNetUsers");
            DropIndex("dbo.DemandeOrientations", new[] { "Specialite_Id" });
            DropIndex("dbo.DemandeOrientations", new[] { "Option_Id" });
            DropIndex("dbo.DemandeOrientations", new[] { "ModifierPar_Id" });
            DropIndex("dbo.DemandeOrientations", new[] { "CreerPar_Id" });
            DropTable("dbo.Notations");
            DropTable("dbo.DemandeOrientations");
            DropTable("dbo.AvisOrientations");
        }
    }
}
