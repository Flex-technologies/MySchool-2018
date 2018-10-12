namespace MySchoolCollege.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MiseAjourDb23 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Batiments",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                        Lieu_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Etablissements", t => t.Lieu_Id)
                .Index(t => t.Lieu_Id);
            
            CreateTable(
                "dbo.Carnets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Observations = c.String(),
                        VueLe = c.DateTime(nullable: false),
                        CreerLe = c.DateTime(nullable: false),
                        ModifierLe = c.DateTime(nullable: false),
                        AnneeScolaire_Id = c.Int(),
                        CreerPar_Id = c.String(maxLength: 128),
                        Etudiant_Id = c.String(maxLength: 128),
                        ModifierPar_Id = c.String(maxLength: 128),
                        SaisiePar_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AnneeScolaires", t => t.AnneeScolaire_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreerPar_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Etudiant_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ModifierPar_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.SaisiePar_Id)
                .Index(t => t.AnneeScolaire_Id)
                .Index(t => t.CreerPar_Id)
                .Index(t => t.Etudiant_Id)
                .Index(t => t.ModifierPar_Id)
                .Index(t => t.SaisiePar_Id);
            
            CreateTable(
                "dbo.Cours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCours = c.DateTime(nullable: false),
                        HeureDebut = c.DateTime(nullable: false),
                        HeureFin = c.DateTime(nullable: false),
                        Commentaires = c.String(),
                        CreerLe = c.DateTime(nullable: false),
                        ModifierLe = c.DateTime(nullable: false),
                        AnneeScolaire_Id = c.Int(),
                        Classe_Id = c.Int(),
                        CreerPar_Id = c.String(maxLength: 128),
                        Matiere_Id = c.Int(),
                        ModifierPar_Id = c.String(maxLength: 128),
                        Professeur_Id = c.String(maxLength: 128),
                        Salle_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AnneeScolaires", t => t.AnneeScolaire_Id)
                .ForeignKey("dbo.Classes", t => t.Classe_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreerPar_Id)
                .ForeignKey("dbo.ServiceMatieres", t => t.Matiere_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ModifierPar_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Professeur_Id)
                .ForeignKey("dbo.Salles", t => t.Salle_Id)
                .Index(t => t.AnneeScolaire_Id)
                .Index(t => t.Classe_Id)
                .Index(t => t.CreerPar_Id)
                .Index(t => t.Matiere_Id)
                .Index(t => t.ModifierPar_Id)
                .Index(t => t.Professeur_Id)
                .Index(t => t.Salle_Id);
            
            CreateTable(
                "dbo.Salles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                        Batiment_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Batiments", t => t.Batiment_Id)
                .Index(t => t.Batiment_Id);
            
            CreateTable(
                "dbo.PointageEtudiants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Present = c.Boolean(nullable: false),
                        Retard = c.Boolean(nullable: false),
                        MinuteRedarder = c.Int(nullable: false),
                        AbsenceJustifier = c.Boolean(nullable: false),
                        RetardJustifier = c.Boolean(nullable: false),
                        Commentaire = c.String(),
                        CreerLe = c.DateTime(nullable: false),
                        ModifierLe = c.DateTime(nullable: false),
                        Cours_Id = c.Int(),
                        CreerPar_Id = c.String(maxLength: 128),
                        Etudiant_Id = c.String(maxLength: 128),
                        ModifierPar_Id = c.String(maxLength: 128),
                        MotifAbsence_Id = c.String(maxLength: 128),
                        MotifRetard_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cours", t => t.Cours_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreerPar_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Etudiant_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ModifierPar_Id)
                .ForeignKey("dbo.MotifAbsences", t => t.MotifAbsence_Id)
                .ForeignKey("dbo.MotifRetards", t => t.MotifRetard_Id)
                .Index(t => t.Cours_Id)
                .Index(t => t.CreerPar_Id)
                .Index(t => t.Etudiant_Id)
                .Index(t => t.ModifierPar_Id)
                .Index(t => t.MotifAbsence_Id)
                .Index(t => t.MotifRetard_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PointageEtudiants", "MotifRetard_Id", "dbo.MotifRetards");
            DropForeignKey("dbo.PointageEtudiants", "MotifAbsence_Id", "dbo.MotifAbsences");
            DropForeignKey("dbo.PointageEtudiants", "ModifierPar_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.PointageEtudiants", "Etudiant_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.PointageEtudiants", "CreerPar_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.PointageEtudiants", "Cours_Id", "dbo.Cours");
            DropForeignKey("dbo.Cours", "Salle_Id", "dbo.Salles");
            DropForeignKey("dbo.Salles", "Batiment_Id", "dbo.Batiments");
            DropForeignKey("dbo.Cours", "Professeur_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Cours", "ModifierPar_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Cours", "Matiere_Id", "dbo.ServiceMatieres");
            DropForeignKey("dbo.Cours", "CreerPar_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Cours", "Classe_Id", "dbo.Classes");
            DropForeignKey("dbo.Cours", "AnneeScolaire_Id", "dbo.AnneeScolaires");
            DropForeignKey("dbo.Carnets", "SaisiePar_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Carnets", "ModifierPar_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Carnets", "Etudiant_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Carnets", "CreerPar_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Carnets", "AnneeScolaire_Id", "dbo.AnneeScolaires");
            DropForeignKey("dbo.Batiments", "Lieu_Id", "dbo.Etablissements");
            DropIndex("dbo.PointageEtudiants", new[] { "MotifRetard_Id" });
            DropIndex("dbo.PointageEtudiants", new[] { "MotifAbsence_Id" });
            DropIndex("dbo.PointageEtudiants", new[] { "ModifierPar_Id" });
            DropIndex("dbo.PointageEtudiants", new[] { "Etudiant_Id" });
            DropIndex("dbo.PointageEtudiants", new[] { "CreerPar_Id" });
            DropIndex("dbo.PointageEtudiants", new[] { "Cours_Id" });
            DropIndex("dbo.Salles", new[] { "Batiment_Id" });
            DropIndex("dbo.Cours", new[] { "Salle_Id" });
            DropIndex("dbo.Cours", new[] { "Professeur_Id" });
            DropIndex("dbo.Cours", new[] { "ModifierPar_Id" });
            DropIndex("dbo.Cours", new[] { "Matiere_Id" });
            DropIndex("dbo.Cours", new[] { "CreerPar_Id" });
            DropIndex("dbo.Cours", new[] { "Classe_Id" });
            DropIndex("dbo.Cours", new[] { "AnneeScolaire_Id" });
            DropIndex("dbo.Carnets", new[] { "SaisiePar_Id" });
            DropIndex("dbo.Carnets", new[] { "ModifierPar_Id" });
            DropIndex("dbo.Carnets", new[] { "Etudiant_Id" });
            DropIndex("dbo.Carnets", new[] { "CreerPar_Id" });
            DropIndex("dbo.Carnets", new[] { "AnneeScolaire_Id" });
            DropIndex("dbo.Batiments", new[] { "Lieu_Id" });
            DropTable("dbo.PointageEtudiants");
            DropTable("dbo.Salles");
            DropTable("dbo.Cours");
            DropTable("dbo.Carnets");
            DropTable("dbo.Batiments");
        }
    }
}
