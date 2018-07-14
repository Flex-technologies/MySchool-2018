namespace MySchoolCollege.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MiseAjourDb17 : DbMigration
    {
        public override void Up()
        {
           
            DropForeignKey("dbo.Classes", "ProfesseurPrincipal_Id", "dbo.AspNetUsers");
            RenameTable(name: "dbo.Classes", newName: "ClasseDeBases");
            DropIndex("dbo.ClasseDeBases", new[] { "ProfesseurPrincipal_Id" });
            DropColumn("dbo.ClasseDeBases", "ProfesseurPrincipal_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ClasseDeBases", "ProfesseurPrincipal_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.ClasseDeBases", "ProfesseurPrincipal_Id");
            RenameTable(name: "dbo.ClasseDeBases", newName: "Classes");
            AddForeignKey("dbo.Classes", "ProfesseurPrincipal_Id", "dbo.AspNetUsers", "Id");
            
        }
    }
}
