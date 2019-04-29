namespace MySchoolCollege.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MiseAjourDatabase25 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ClasseDeBases", "Etablissements_Etablissement_Id", "dbo.Etablissements");
            //DropIndex("dbo.ClasseDeBases", new[] { "Etablissement_Id" });
            DropColumn("dbo.ClasseDeBases", "Etablissement_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ClasseDeBases", "Etablissement_Id", c => c.Int());
            CreateIndex("dbo.ClasseDeBases", "Etablissement_Id");
            AddForeignKey("dbo.ClasseDeBases", "Etablissement_Id", "dbo.Etablissements", "Id");
        }
    }
}
