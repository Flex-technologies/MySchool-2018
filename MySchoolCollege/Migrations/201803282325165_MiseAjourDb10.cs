namespace MySchoolCollege.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MiseAjourDb10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fonctions",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Genre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "LieuDeNaissance", c => c.String());
            AddColumn("dbo.AspNetUsers", "Nationalite", c => c.String());
            AddColumn("dbo.AspNetUsers", "Addresse", c => c.String());
            AddColumn("dbo.AspNetUsers", "Ville", c => c.String());
            AddColumn("dbo.AspNetUsers", "Pays", c => c.String());
            AddColumn("dbo.AspNetUsers", "Fonction_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "Parent_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUsers", "Fonction_Id");
            CreateIndex("dbo.AspNetUsers", "Parent_Id");
            AddForeignKey("dbo.AspNetUsers", "Fonction_Id", "dbo.Fonctions", "Id");
            AddForeignKey("dbo.AspNetUsers", "Parent_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Parent_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Fonction_Id", "dbo.Fonctions");
            DropIndex("dbo.AspNetUsers", new[] { "Parent_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Fonction_Id" });
            DropColumn("dbo.AspNetUsers", "Parent_Id");
            DropColumn("dbo.AspNetUsers", "Fonction_Id");
            DropColumn("dbo.AspNetUsers", "Pays");
            DropColumn("dbo.AspNetUsers", "Ville");
            DropColumn("dbo.AspNetUsers", "Addresse");
            DropColumn("dbo.AspNetUsers", "Nationalite");
            DropColumn("dbo.AspNetUsers", "LieuDeNaissance");
            DropTable("dbo.Fonctions");
        }
    }
}
