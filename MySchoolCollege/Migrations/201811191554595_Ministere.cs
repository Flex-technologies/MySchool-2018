namespace MySchoolCollege.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ministere : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ministeres",
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
                        ModifierPar_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreerPar_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ModifierPar_Id)
                .Index(t => t.CreerPar_Id)
                .Index(t => t.ModifierPar_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ministeres", "ModifierPar_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Ministeres", "CreerPar_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Ministeres", new[] { "ModifierPar_Id" });
            DropIndex("dbo.Ministeres", new[] { "CreerPar_Id" });
            DropTable("dbo.Ministeres");
        }
    }
}
