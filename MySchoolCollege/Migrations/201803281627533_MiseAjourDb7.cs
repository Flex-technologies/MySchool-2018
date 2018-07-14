namespace MySchoolCollege.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MiseAjourDb7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrientationEtablissementAccueils",
                c => new
                    {
                        Orientation_Id = c.Int(nullable: false),
                        EtablissementAccueil_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Orientation_Id, t.EtablissementAccueil_Id })
                .ForeignKey("dbo.Orientations", t => t.Orientation_Id, cascadeDelete: true)
                .ForeignKey("dbo.Etablissements", t => t.EtablissementAccueil_Id, cascadeDelete: true)
                .Index(t => t.Orientation_Id)
                .Index(t => t.EtablissementAccueil_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrientationEtablissementAccueils", "EtablissementAccueil_Id", "dbo.Etablissements");
            DropForeignKey("dbo.OrientationEtablissementAccueils", "Orientation_Id", "dbo.Orientations");
            DropIndex("dbo.OrientationEtablissementAccueils", new[] { "EtablissementAccueil_Id" });
            DropIndex("dbo.OrientationEtablissementAccueils", new[] { "Orientation_Id" });
            DropTable("dbo.OrientationEtablissementAccueils");
        }
    }
}
