namespace MySchoolCollege.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MiseAjourDb22 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DossierEtudiants",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Etudiant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Inscriptions", t => t.Etudiant_Id)
                .Index(t => t.Etudiant_Id);
            
            CreateTable(
                "dbo.Inscriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreeLe = c.DateTime(nullable: false),
                        ModifierLe = c.DateTime(nullable: false),
                        AnneeScolaire_Id = c.Int(),
                        Classe_Id = c.Int(),
                        CreerPar_Id = c.String(maxLength: 128),
                        Etudiant_Id = c.String(maxLength: 128),
                        Modifierpar_Id = c.String(maxLength: 128),
                        Regime_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AnneeScolaires", t => t.AnneeScolaire_Id)
                .ForeignKey("dbo.Classes", t => t.Classe_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreerPar_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Etudiant_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Modifierpar_Id)
                .ForeignKey("dbo.Autorisations", t => t.Regime_Id)
                .Index(t => t.AnneeScolaire_Id)
                .Index(t => t.Classe_Id)
                .Index(t => t.CreerPar_Id)
                .Index(t => t.Etudiant_Id)
                .Index(t => t.Modifierpar_Id)
                .Index(t => t.Regime_Id);
            
            CreateTable(
                "dbo.DossierPunitions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Lieu = c.Int(nullable: false),
                        Victime = c.Int(nullable: false),
                        Temoin = c.Int(nullable: false),
                        Commentaires = c.String(),
                        Date = c.DateTime(nullable: false),
                        CreerLe = c.DateTime(nullable: false),
                        ModiferLe = c.DateTime(nullable: false),
                        CreerPar_Id = c.String(maxLength: 128),
                        Dossier_id = c.Int(),
                        ModifierPar_Id = c.String(maxLength: 128),
                        Motif_Id = c.Int(),
                        Punition_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreerPar_Id)
                .ForeignKey("dbo.DossierEtudiants", t => t.Dossier_id)
                .ForeignKey("dbo.AspNetUsers", t => t.ModifierPar_Id)
                .ForeignKey("dbo.MotifSanctions", t => t.Motif_Id)
                .ForeignKey("dbo.Punitions", t => t.Punition_Id)
                .Index(t => t.CreerPar_Id)
                .Index(t => t.Dossier_id)
                .Index(t => t.ModifierPar_Id)
                .Index(t => t.Motif_Id)
                .Index(t => t.Punition_Id);
            
            CreateTable(
                "dbo.DossierSanctions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Lieu = c.Int(nullable: false),
                        Victime = c.Int(nullable: false),
                        Temoin = c.Int(nullable: false),
                        Commentaires = c.String(),
                        Date = c.DateTime(nullable: false),
                        CreerLe = c.DateTime(nullable: false),
                        ModiferLe = c.DateTime(nullable: false),
                        CreerPar_Id = c.String(maxLength: 128),
                        Dossier_id = c.Int(),
                        ModifierPar_Id = c.String(maxLength: 128),
                        Motif_Id = c.Int(),
                        Sanction_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreerPar_Id)
                .ForeignKey("dbo.DossierEtudiants", t => t.Dossier_id)
                .ForeignKey("dbo.AspNetUsers", t => t.ModifierPar_Id)
                .ForeignKey("dbo.MotifSanctions", t => t.Motif_Id)
                .ForeignKey("dbo.Sanctions", t => t.Sanction_Id)
                .Index(t => t.CreerPar_Id)
                .Index(t => t.Dossier_id)
                .Index(t => t.ModifierPar_Id)
                .Index(t => t.Motif_Id)
                .Index(t => t.Sanction_Id);
            
            AddColumn("dbo.DemandeOrientations", "EtablissementDemander_Id", c => c.Int());
            CreateIndex("dbo.DemandeOrientations", "EtablissementDemander_Id");
            AddForeignKey("dbo.DemandeOrientations", "EtablissementDemander_Id", "dbo.Etablissements", "Id");
            DropColumn("dbo.DemandeOrientations", "EtablissementDemander");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DemandeOrientations", "EtablissementDemander", c => c.String());
            DropForeignKey("dbo.DossierSanctions", "Sanction_Id", "dbo.Sanctions");
            DropForeignKey("dbo.DossierSanctions", "Motif_Id", "dbo.MotifSanctions");
            DropForeignKey("dbo.DossierSanctions", "ModifierPar_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.DossierSanctions", "Dossier_id", "dbo.DossierEtudiants");
            DropForeignKey("dbo.DossierSanctions", "CreerPar_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.DossierPunitions", "Punition_Id", "dbo.Punitions");
            DropForeignKey("dbo.DossierPunitions", "Motif_Id", "dbo.MotifSanctions");
            DropForeignKey("dbo.DossierPunitions", "ModifierPar_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.DossierPunitions", "Dossier_id", "dbo.DossierEtudiants");
            DropForeignKey("dbo.DossierPunitions", "CreerPar_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.DossierEtudiants", "Etudiant_Id", "dbo.Inscriptions");
            DropForeignKey("dbo.Inscriptions", "Regime_Id", "dbo.Autorisations");
            DropForeignKey("dbo.Inscriptions", "Modifierpar_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Inscriptions", "Etudiant_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Inscriptions", "CreerPar_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Inscriptions", "Classe_Id", "dbo.Classes");
            DropForeignKey("dbo.Inscriptions", "AnneeScolaire_Id", "dbo.AnneeScolaires");
            DropForeignKey("dbo.DemandeOrientations", "EtablissementDemander_Id", "dbo.Etablissements");
            DropIndex("dbo.DossierSanctions", new[] { "Sanction_Id" });
            DropIndex("dbo.DossierSanctions", new[] { "Motif_Id" });
            DropIndex("dbo.DossierSanctions", new[] { "ModifierPar_Id" });
            DropIndex("dbo.DossierSanctions", new[] { "Dossier_id" });
            DropIndex("dbo.DossierSanctions", new[] { "CreerPar_Id" });
            DropIndex("dbo.DossierPunitions", new[] { "Punition_Id" });
            DropIndex("dbo.DossierPunitions", new[] { "Motif_Id" });
            DropIndex("dbo.DossierPunitions", new[] { "ModifierPar_Id" });
            DropIndex("dbo.DossierPunitions", new[] { "Dossier_id" });
            DropIndex("dbo.DossierPunitions", new[] { "CreerPar_Id" });
            DropIndex("dbo.Inscriptions", new[] { "Regime_Id" });
            DropIndex("dbo.Inscriptions", new[] { "Modifierpar_Id" });
            DropIndex("dbo.Inscriptions", new[] { "Etudiant_Id" });
            DropIndex("dbo.Inscriptions", new[] { "CreerPar_Id" });
            DropIndex("dbo.Inscriptions", new[] { "Classe_Id" });
            DropIndex("dbo.Inscriptions", new[] { "AnneeScolaire_Id" });
            DropIndex("dbo.DossierEtudiants", new[] { "Etudiant_Id" });
            DropIndex("dbo.DemandeOrientations", new[] { "EtablissementDemander_Id" });
            DropColumn("dbo.DemandeOrientations", "EtablissementDemander_Id");
            DropTable("dbo.DossierSanctions");
            DropTable("dbo.DossierPunitions");
            DropTable("dbo.Inscriptions");
            DropTable("dbo.DossierEtudiants");
        }
    }
}
