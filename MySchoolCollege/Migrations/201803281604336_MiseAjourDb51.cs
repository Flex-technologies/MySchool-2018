namespace MySchoolCollege.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MiseAjourDb51 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Natures",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OptionSpecialites",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        SpecialiteOrientation_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SpecialiteOrientations", t => t.SpecialiteOrientation_Id)
                .Index(t => t.SpecialiteOrientation_Id);
            
            CreateTable(
                "dbo.SpecialiteOrientations",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Orientation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orientations", t => t.Orientation_Id)
                .Index(t => t.Orientation_Id);
            
            CreateTable(
                "dbo.Orientations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Cycle_Id = c.String(maxLength: 128),
                        Nature_Id = c.String(maxLength: 128),
                        Niveau_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cycles", t => t.Cycle_Id)
                .ForeignKey("dbo.Natures", t => t.Nature_Id)
                .ForeignKey("dbo.Niveaux", t => t.Niveau_Id)
                .Index(t => t.Cycle_Id)
                .Index(t => t.Nature_Id)
                .Index(t => t.Niveau_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OptionSpecialites", "SpecialiteOrientation_Id", "dbo.SpecialiteOrientations");
            DropForeignKey("dbo.SpecialiteOrientations", "Orientation_Id", "dbo.Orientations");
            DropForeignKey("dbo.Orientations", "Niveau_Id", "dbo.Niveaux");
            DropForeignKey("dbo.Orientations", "Nature_Id", "dbo.Natures");
            DropForeignKey("dbo.Orientations", "Cycle_Id", "dbo.Cycles");
            DropIndex("dbo.Orientations", new[] { "Niveau_Id" });
            DropIndex("dbo.Orientations", new[] { "Nature_Id" });
            DropIndex("dbo.Orientations", new[] { "Cycle_Id" });
            DropIndex("dbo.SpecialiteOrientations", new[] { "Orientation_Id" });
            DropIndex("dbo.OptionSpecialites", new[] { "SpecialiteOrientation_Id" });
            DropTable("dbo.Orientations");
            DropTable("dbo.SpecialiteOrientations");
            DropTable("dbo.OptionSpecialites");
            DropTable("dbo.Natures");
        }
    }
}
