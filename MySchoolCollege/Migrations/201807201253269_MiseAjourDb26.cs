namespace MySchoolCollege.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MiseAjourDb26 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Controles", "Matiere_Id", c => c.Int());
            CreateIndex("dbo.Controles", "Matiere_Id");
            AddForeignKey("dbo.Controles", "Matiere_Id", "dbo.ServiceMatieres", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Controles", "Matiere_Id", "dbo.ServiceMatieres");
            DropIndex("dbo.Controles", new[] { "Matiere_Id" });
            DropColumn("dbo.Controles", "Matiere_Id");
        }
    }
}
