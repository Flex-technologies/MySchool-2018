namespace MySchoolCollege.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MiseAjourDb18 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ServiceMatieres", "ClasseDeBase_Id", "dbo.ClasseDeBases");
            DropIndex("dbo.ServiceMatieres", new[] { "ClasseDeBase_Id" });
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreeLe = c.DateTime(nullable: false),
                        ModifierLe = c.DateTime(nullable: false),
                        AnneeScolaire_Id = c.Int(),
                        ClasseDeBase_Id = c.Int(),
                        CreerPar_Id = c.String(maxLength: 128),
                        Modifierpar_Id = c.String(maxLength: 128),
                        ProfesseurPrincipal_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AnneeScolaires", t => t.AnneeScolaire_Id)
                .ForeignKey("dbo.ClasseDeBases", t => t.ClasseDeBase_Id)
                //.ForeignKey("dbo.AspNetUsers", t => t.CreerPar_Id)
                //.ForeignKey("dbo.AspNetUsers", t => t.Modifierpar_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ProfesseurPrincipal_Id)
                .Index(t => t.AnneeScolaire_Id)
                .Index(t => t.ClasseDeBase_Id)
                //.Index(t => t.CreerPar_Id)
                //.Index(t => t.Modifierpar_Id)
                .Index(t => t.ProfesseurPrincipal_Id);
            
            AddColumn("dbo.ClasseDeBases", "CreeLe", c => c.DateTime(nullable: false));
            AddColumn("dbo.ClasseDeBases", "ModifierLe", c => c.DateTime(nullable: false));
            AddColumn("dbo.Matieres", "CreeLe", c => c.DateTime(nullable: false));
            AddColumn("dbo.Matieres", "ModifierLe", c => c.DateTime(nullable: false));
            AddColumn("dbo.ServiceMatieres", "CreeLe", c => c.DateTime(nullable: false));
            AddColumn("dbo.ServiceMatieres", "ModifierLe", c => c.DateTime(nullable: false));
            //AddColumn("dbo.ServiceMatieres", "Classe_Id", c => c.Int());
            AlterColumn("dbo.ServiceMatieres", "VolumeHoraire", c => c.Int());
            //CreateIndex("dbo.ServiceMatieres", "Classe_Id");
           // AddForeignKey("dbo.ServiceMatieres", "Classe_Id", "dbo.Classes", "Id");
            DropColumn("dbo.ServiceMatieres", "DateCreation");
            DropColumn("dbo.ServiceMatieres", "DateModification");
            //DropColumn("dbo.ServiceMatieres", "ClasseDeBase_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ServiceMatieres", "ClasseDeBase_Id", c => c.Int());
            AddColumn("dbo.ServiceMatieres", "DateModification", c => c.DateTime(nullable: false));
            AddColumn("dbo.ServiceMatieres", "DateCreation", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.ServiceMatieres", "Classe_Id", "dbo.Classes");
            DropForeignKey("dbo.Classes", "ProfesseurPrincipal_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Classes", "Modifierpar_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Classes", "CreerPar_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Classes", "ClasseDeBase_Id", "dbo.ClasseDeBases");
            DropForeignKey("dbo.Classes", "AnneeScolaire_Id", "dbo.AnneeScolaires");
            DropIndex("dbo.Classes", new[] { "ProfesseurPrincipal_Id" });
            DropIndex("dbo.Classes", new[] { "Modifierpar_Id" });
            DropIndex("dbo.Classes", new[] { "CreerPar_Id" });
            DropIndex("dbo.Classes", new[] { "ClasseDeBase_Id" });
            DropIndex("dbo.Classes", new[] { "AnneeScolaire_Id" });
            DropIndex("dbo.ServiceMatieres", new[] { "Classe_Id" });
            AlterColumn("dbo.ServiceMatieres", "VolumeHoraire", c => c.Int(nullable: false));
            //DropColumn("dbo.ServiceMatieres", "Classe_Id");
            DropColumn("dbo.ServiceMatieres", "ModifierLe");
            DropColumn("dbo.ServiceMatieres", "CreeLe");
            DropColumn("dbo.Matieres", "ModifierLe");
            DropColumn("dbo.Matieres", "CreeLe");
            DropColumn("dbo.ClasseDeBases", "ModifierLe");
            DropColumn("dbo.ClasseDeBases", "CreeLe");
            DropTable("dbo.Classes");
            CreateIndex("dbo.ServiceMatieres", "ClasseDeBase_Id");
            AddForeignKey("dbo.ServiceMatieres", "ClasseDeBase_Id", "dbo.ClasseDeBases", "Id");
        }
    }
}
