namespace MySchoolCollege.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MiseAjourDb21 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UniteEnseignements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Credit = c.Int(nullable: false),
                        AnneeScolaire_Id = c.Int(),
                        Classe_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AnneeScolaires", t => t.AnneeScolaire_Id)
                .ForeignKey("dbo.Classes", t => t.Classe_Id)
                .Index(t => t.AnneeScolaire_Id)
                .Index(t => t.Classe_Id);
            
            AddColumn("dbo.ServiceMatieres", "Credit", c => c.Int(nullable: false));
            AddColumn("dbo.ServiceMatieres", "UniteEnseignement_Id", c => c.Int());
            CreateIndex("dbo.ServiceMatieres", "UniteEnseignement_Id");
            AddForeignKey("dbo.ServiceMatieres", "UniteEnseignement_Id", "dbo.UniteEnseignements", "Id");
            DropColumn("dbo.Matieres", "DateCreation");
            DropColumn("dbo.Matieres", "DateModification");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Matieres", "DateModification", c => c.DateTime(nullable: false));
            AddColumn("dbo.Matieres", "DateCreation", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.ServiceMatieres", "UniteEnseignement_Id", "dbo.UniteEnseignements");
            DropForeignKey("dbo.UniteEnseignements", "Classe_Id", "dbo.Classes");
            DropForeignKey("dbo.UniteEnseignements", "AnneeScolaire_Id", "dbo.AnneeScolaires");
            DropIndex("dbo.UniteEnseignements", new[] { "Classe_Id" });
            DropIndex("dbo.UniteEnseignements", new[] { "AnneeScolaire_Id" });
            DropIndex("dbo.ServiceMatieres", new[] { "UniteEnseignement_Id" });
            DropColumn("dbo.ServiceMatieres", "UniteEnseignement_Id");
            DropColumn("dbo.ServiceMatieres", "Credit");
            DropTable("dbo.UniteEnseignements");
        }
    }
}
