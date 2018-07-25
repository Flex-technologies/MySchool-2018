namespace MySchoolCollege.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MiseAjourDb24 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Controles", "NotationSur", c => c.Int(nullable: false));
            AddColumn("dbo.Controles", "CreerLe", c => c.DateTime(nullable: false));
            AddColumn("dbo.Controles", "ModifierLe", c => c.DateTime(nullable: false));
            AddColumn("dbo.Controles", "Classe_Id", c => c.Int());
            AddColumn("dbo.Controles", "Semestre_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Controles", "Classe_Id");
            CreateIndex("dbo.Controles", "Semestre_Id");
            AddForeignKey("dbo.Controles", "Classe_Id", "dbo.Classes", "Id");
            AddForeignKey("dbo.Controles", "Semestre_Id", "dbo.Semestres", "Id");
            DropColumn("dbo.Controles", "DateCreation");
            DropColumn("dbo.Controles", "DateModification");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Controles", "DateModification", c => c.DateTime(nullable: false));
            AddColumn("dbo.Controles", "DateCreation", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Controles", "Semestre_Id", "dbo.Semestres");
            DropForeignKey("dbo.Controles", "Classe_Id", "dbo.Classes");
            DropIndex("dbo.Controles", new[] { "Semestre_Id" });
            DropIndex("dbo.Controles", new[] { "Classe_Id" });
            DropColumn("dbo.Controles", "Semestre_Id");
            DropColumn("dbo.Controles", "Classe_Id");
            DropColumn("dbo.Controles", "ModifierLe");
            DropColumn("dbo.Controles", "CreerLe");
            DropColumn("dbo.Controles", "NotationSur");
        }
    }
}
