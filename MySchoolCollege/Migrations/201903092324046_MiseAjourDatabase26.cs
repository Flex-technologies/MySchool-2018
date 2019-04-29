namespace MySchoolCollege.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MiseAjourDatabase26 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Classes", "CreerLe", c => c.DateTime(nullable: false));
            AddColumn("dbo.Classes", "Etablissement_Id", c => c.Int());
            CreateIndex("dbo.Classes", "Etablissement_Id");
            AddForeignKey("dbo.Classes", "Etablissement_Id", "dbo.Etablissements", "Id");
            DropColumn("dbo.Classes", "CreeLe");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Classes", "CreeLe", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Classes", "Etablissement_Id", "dbo.Etablissements");
            DropIndex("dbo.Classes", new[] { "Etablissement_Id" });
            DropColumn("dbo.Classes", "Etablissement_Id");
            DropColumn("dbo.Classes", "CreerLe");
        }
    }
}
