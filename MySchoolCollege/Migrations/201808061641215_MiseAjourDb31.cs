namespace MySchoolCollege.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MiseAjourDb31 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Periodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateDebut = c.DateTime(nullable: false),
                        DateFin = c.DateTime(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                        AnneeScolaire_Id = c.Int(),
                        CreerPar_Id = c.String(maxLength: 128),
                        Modifierpar_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AnneeScolaires", t => t.AnneeScolaire_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreerPar_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Modifierpar_Id)
                .Index(t => t.AnneeScolaire_Id)
                .Index(t => t.CreerPar_Id)
                .Index(t => t.Modifierpar_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Periodes", "Modifierpar_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Periodes", "CreerPar_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Periodes", "AnneeScolaire_Id", "dbo.AnneeScolaires");
            DropIndex("dbo.Periodes", new[] { "Modifierpar_Id" });
            DropIndex("dbo.Periodes", new[] { "CreerPar_Id" });
            DropIndex("dbo.Periodes", new[] { "AnneeScolaire_Id" });
            DropTable("dbo.Periodes");
        }
    }
}
