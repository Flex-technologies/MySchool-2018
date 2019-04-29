namespace MySchoolCollege.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateEtablissement : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Etablissements", "Inspection_Id", c => c.Int());
            CreateIndex("dbo.Etablissements", "Inspection_Id");
            AddForeignKey("dbo.Etablissements", "Inspection_Id", "dbo.Inspections", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Etablissements", "Inspection_Id", "dbo.Inspections");
            DropIndex("dbo.Etablissements", new[] { "Inspection_Id" });
            DropColumn("dbo.Etablissements", "Inspection_Id");
        }
    }
}
