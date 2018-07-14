namespace MySchoolCollege.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MiseAjourDb9 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        CreerPar_Id = c.String(maxLength: 128),
                        Etablissement_Id = c.Int(),
                        Filiere_Id = c.String(maxLength: 128),
                        Modifierpar_Id = c.String(maxLength: 128),
                        Niveau_Id = c.String(maxLength: 128),
                        ProfesseurPrincipal_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreerPar_Id)
                .ForeignKey("dbo.Etablissements", t => t.Etablissement_Id)
                .ForeignKey("dbo.Filieres", t => t.Filiere_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Modifierpar_Id)
                .ForeignKey("dbo.Niveaux", t => t.Niveau_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ProfesseurPrincipal_Id)
                .Index(t => t.CreerPar_Id)
                .Index(t => t.Etablissement_Id)
                .Index(t => t.Filiere_Id)
                .Index(t => t.Modifierpar_Id)
                .Index(t => t.Niveau_Id)
                .Index(t => t.ProfesseurPrincipal_Id);
            
            CreateTable(
                "dbo.ServiceMatieres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Coeficient = c.Int(nullable: false),
                        VolumeHoraire = c.Int(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                        AnneeScolaire_Id = c.Int(),
                        Classe_Id = c.Int(),
                        CreerPar_Id = c.String(maxLength: 128),
                        Matiere_Id = c.Int(),
                        Modifierpar_Id = c.String(maxLength: 128),
                        Professeur_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AnneeScolaires", t => t.AnneeScolaire_Id)
                .ForeignKey("dbo.Classes", t => t.Classe_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreerPar_Id)
                .ForeignKey("dbo.Matieres", t => t.Matiere_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Modifierpar_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Professeur_Id)
                .Index(t => t.AnneeScolaire_Id)
                .Index(t => t.Classe_Id)
                .Index(t => t.CreerPar_Id)
                .Index(t => t.Matiere_Id)
                .Index(t => t.Modifierpar_Id)
                .Index(t => t.Professeur_Id);
            
            AddColumn("dbo.Matieres", "Lve", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceMatieres", "Professeur_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ServiceMatieres", "Modifierpar_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ServiceMatieres", "Matiere_Id", "dbo.Matieres");
            DropForeignKey("dbo.ServiceMatieres", "CreerPar_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ServiceMatieres", "Classe_Id", "dbo.Classes");
            DropForeignKey("dbo.ServiceMatieres", "AnneeScolaire_Id", "dbo.AnneeScolaires");
            DropForeignKey("dbo.Classes", "ProfesseurPrincipal_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Classes", "Niveau_Id", "dbo.Niveaux");
            DropForeignKey("dbo.Classes", "Modifierpar_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Classes", "Filiere_Id", "dbo.Filieres");
            DropForeignKey("dbo.Classes", "Etablissement_Id", "dbo.Etablissements");
            DropForeignKey("dbo.Classes", "CreerPar_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ServiceMatieres", new[] { "Professeur_Id" });
            DropIndex("dbo.ServiceMatieres", new[] { "Modifierpar_Id" });
            DropIndex("dbo.ServiceMatieres", new[] { "Matiere_Id" });
            DropIndex("dbo.ServiceMatieres", new[] { "CreerPar_Id" });
            DropIndex("dbo.ServiceMatieres", new[] { "Classe_Id" });
            DropIndex("dbo.ServiceMatieres", new[] { "AnneeScolaire_Id" });
            DropIndex("dbo.Classes", new[] { "ProfesseurPrincipal_Id" });
            DropIndex("dbo.Classes", new[] { "Niveau_Id" });
            DropIndex("dbo.Classes", new[] { "Modifierpar_Id" });
            DropIndex("dbo.Classes", new[] { "Filiere_Id" });
            DropIndex("dbo.Classes", new[] { "Etablissement_Id" });
            DropIndex("dbo.Classes", new[] { "CreerPar_Id" });
            DropColumn("dbo.Matieres", "Lve");
            DropTable("dbo.ServiceMatieres");
            DropTable("dbo.Classes");
        }
    }
}
