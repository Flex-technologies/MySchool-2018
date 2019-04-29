namespace MySchoolCollege.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MiseAjourDatabase27 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Etablissement_Id", c => c.Int());
            //AddColumn("dbo.AspNetUsers", "Etablissement_Id1", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Etablissement_Id");
            //CreateIndex("dbo.AspNetUsers", "Etablissement_Id1");
            AddForeignKey("dbo.AspNetUsers", "Etablissement_Id", "dbo.Etablissements", "Id");
            //AddForeignKey("dbo.AspNetUsers", "Etablissement_Id1", "dbo.Etablissements", "Id");
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.AspNetUsers", "Etablissement_Id1", "dbo.Etablissements");
            DropForeignKey("dbo.AspNetUsers", "Etablissement_Id", "dbo.Etablissements");
            //DropIndex("dbo.AspNetUsers", new[] { "Etablissement_Id1" });
            DropIndex("dbo.AspNetUsers", new[] { "Etablissement_Id" });
           // DropColumn("dbo.AspNetUsers", "Etablissement_Id1");
            DropColumn("dbo.AspNetUsers", "Etablissement_Id");
        }
    }
}
