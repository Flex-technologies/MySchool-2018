namespace MySchoolCollege.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MiseAjourDb33 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Periodes", "CreerPar_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Periodes", "Modifierpar_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Periodes", new[] { "AnneeScolaire_Id" });
            DropIndex("dbo.Periodes", new[] { "CreerPar_Id" });
            DropIndex("dbo.Periodes", new[] { "Modifierpar_Id" });
            CreateTable(
                "dbo.Mentions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        AImprimer = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Periodes");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Mentions");
            CreateIndex("dbo.Periodes", "Modifierpar_Id");
            CreateIndex("dbo.Periodes", "CreerPar_Id");
            CreateIndex("dbo.Periodes", "AnneeScolaire_Id");
            AddForeignKey("dbo.Periodes", "Modifierpar_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Periodes", "CreerPar_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
