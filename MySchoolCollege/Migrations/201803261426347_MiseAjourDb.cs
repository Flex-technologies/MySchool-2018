namespace MySchoolCollege.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MiseAjourDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Etablissements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Addresse = c.String(),
                        Ville = c.String(),
                        Pays = c.String(),
                        TelephoneSecretariat = c.String(),
                        TelephoneScolarite = c.String(),
                        Fax = c.String(),
                        Email = c.String(),
                        SiteWeb = c.String(),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                        CreerPar_Id = c.String(maxLength: 128),
                        Modifierpar_Id = c.String(maxLength: 128),
                        Type_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreerPar_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Modifierpar_Id)
                .ForeignKey("dbo.TypeEtablissements", t => t.Type_Id)
                .Index(t => t.CreerPar_Id)
                .Index(t => t.Modifierpar_Id)
                .Index(t => t.Type_Id);
            
            CreateTable(
                "dbo.TypeEtablissements",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PeriodePersonnalisees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Periode = c.String(),
                        DateDebut = c.DateTime(nullable: false),
                        DateFin = c.DateTime(nullable: false),
                        AnneeScolaire_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AnneeScolaires", t => t.AnneeScolaire_Id)
                .Index(t => t.AnneeScolaire_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PeriodePersonnalisees", "AnneeScolaire_Id", "dbo.AnneeScolaires");
            DropForeignKey("dbo.Etablissements", "Type_Id", "dbo.TypeEtablissements");
            DropForeignKey("dbo.Etablissements", "Modifierpar_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Etablissements", "CreerPar_Id", "dbo.AspNetUsers");
            DropIndex("dbo.PeriodePersonnalisees", new[] { "AnneeScolaire_Id" });
            DropIndex("dbo.Etablissements", new[] { "Type_Id" });
            DropIndex("dbo.Etablissements", new[] { "Modifierpar_Id" });
            DropIndex("dbo.Etablissements", new[] { "CreerPar_Id" });
            DropTable("dbo.PeriodePersonnalisees");
            DropTable("dbo.TypeEtablissements");
            DropTable("dbo.Etablissements");
        }
    }
}
