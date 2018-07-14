namespace MySchoolCollege.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class myschooliniDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnneeScolaires",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AnneeAcademique = c.String(),
                        Description = c.String(),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                        CreerPar_Id = c.String(maxLength: 128),
                        Modifierpar_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreerPar_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Modifierpar_Id)
                .Index(t => t.CreerPar_Id)
                .Index(t => t.Modifierpar_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Prenom = c.String(),
                        Nom = c.String(),
                        DateNaissance = c.DateTime(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Controles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateControle = c.DateTime(nullable: false),
                        Note = c.Int(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                        AnneeScolaire_Id = c.Int(),
                        CreerPar_Id = c.String(maxLength: 128),
                        Etudiant_Id = c.String(maxLength: 128),
                        Matiere_Id = c.Int(),
                        Modifierpar_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AnneeScolaires", t => t.AnneeScolaire_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreerPar_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Etudiant_Id)
                .ForeignKey("dbo.Matieres", t => t.Matiere_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Modifierpar_Id)
                .Index(t => t.AnneeScolaire_Id)
                .Index(t => t.CreerPar_Id)
                .Index(t => t.Etudiant_Id)
                .Index(t => t.Matiere_Id)
                .Index(t => t.Modifierpar_Id);
            
            CreateTable(
                "dbo.Matieres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodeMatiere = c.String(),
                        Description = c.String(),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                        CreerPar_Id = c.String(maxLength: 128),
                        Modifierpar_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreerPar_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Modifierpar_Id)
                .Index(t => t.CreerPar_Id)
                .Index(t => t.Modifierpar_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Controles", "Modifierpar_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Controles", "Matiere_Id", "dbo.Matieres");
            DropForeignKey("dbo.Matieres", "Modifierpar_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Matieres", "CreerPar_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Controles", "Etudiant_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Controles", "CreerPar_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Controles", "AnneeScolaire_Id", "dbo.AnneeScolaires");
            DropForeignKey("dbo.AnneeScolaires", "Modifierpar_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AnneeScolaires", "CreerPar_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Matieres", new[] { "Modifierpar_Id" });
            DropIndex("dbo.Matieres", new[] { "CreerPar_Id" });
            DropIndex("dbo.Controles", new[] { "Modifierpar_Id" });
            DropIndex("dbo.Controles", new[] { "Matiere_Id" });
            DropIndex("dbo.Controles", new[] { "Etudiant_Id" });
            DropIndex("dbo.Controles", new[] { "CreerPar_Id" });
            DropIndex("dbo.Controles", new[] { "AnneeScolaire_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AnneeScolaires", new[] { "Modifierpar_Id" });
            DropIndex("dbo.AnneeScolaires", new[] { "CreerPar_Id" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Matieres");
            DropTable("dbo.Controles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AnneeScolaires");
        }
    }
}
