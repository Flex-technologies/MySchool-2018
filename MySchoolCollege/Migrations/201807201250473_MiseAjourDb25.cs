namespace MySchoolCollege.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MiseAjourDb25 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Controles", "Matiere_Id", "dbo.Matieres");
            DropIndex("dbo.Controles", new[] { "Matiere_Id" });
            DropColumn("dbo.Controles", "Matiere_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Controles", "Matiere_Id", c => c.Int());
            CreateIndex("dbo.Controles", "Matiere_Id");
            AddForeignKey("dbo.Controles", "Matiere_Id", "dbo.Matieres", "Id");
        }
    }
}
