namespace MySchoolCollege.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inspection : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inspections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Telephone = c.String(),
                        Adresse = c.String(),
                        Ville = c.String(),
                        Pays = c.String(),
                        CreerLe = c.DateTime(nullable: false),
                        ModifierLe = c.DateTime(nullable: false),
                        CreerPar_Id = c.String(maxLength: 128),
                        Ministere_Id = c.Int(),
                        ModifierPar_Id = c.String(maxLength: 128),
                        TypeInspection_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreerPar_Id)
                .ForeignKey("dbo.Ministeres", t => t.Ministere_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ModifierPar_Id)
                .ForeignKey("dbo.TypeInspections", t => t.TypeInspection_Id)
                .Index(t => t.CreerPar_Id)
                .Index(t => t.Ministere_Id)
                .Index(t => t.ModifierPar_Id)
                .Index(t => t.TypeInspection_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inspections", "TypeInspection_Id", "dbo.TypeInspections");
            DropForeignKey("dbo.Inspections", "ModifierPar_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Inspections", "Ministere_Id", "dbo.Ministeres");
            DropForeignKey("dbo.Inspections", "CreerPar_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Inspections", new[] { "TypeInspection_Id" });
            DropIndex("dbo.Inspections", new[] { "ModifierPar_Id" });
            DropIndex("dbo.Inspections", new[] { "Ministere_Id" });
            DropIndex("dbo.Inspections", new[] { "CreerPar_Id" });
            DropTable("dbo.Inspections");
        }
    }
}
