namespace MySchoolCollege.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MiseAjourDatabase28 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.AspNetUsers", "Etablissement_Id", "dbo.Etablissements");
            //DropIndex("dbo.AspNetUsers", new[] { "Etablissement_Id1" });
            //DropColumn("dbo.AspNetUsers", "Etablissement_Id");
            //RenameColumn(table: "dbo.AspNetUsers", name: "Etablissement_Id1", newName: "Etablissement_Id");
            AddColumn("dbo.Classes", "Nom", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Classes", "Nom");
            //RenameColumn(table: "dbo.AspNetUsers", name: "Etablissement_Id", newName: "Etablissement_Id1");
            //AddColumn("dbo.AspNetUsers", "Etablissement_Id", c => c.Int());
            //CreateIndex("dbo.AspNetUsers", "Etablissement_Id1");
            //AddForeignKey("dbo.AspNetUsers", "Etablissement_Id", "dbo.Etablissements", "Id");
        }
    }
}
