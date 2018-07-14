namespace MySchoolCollege.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MiseAjourDb1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Autorisations",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        libelle = c.String(),
                        Entree = c.Int(nullable: false),
                        Sortie = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cycles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Niveaux",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                        Bareme = c.Double(nullable: false),
                        Cycle_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cycles", t => t.Cycle_Id)
                .Index(t => t.Cycle_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Niveaux", "Cycle_Id", "dbo.Cycles");
            DropIndex("dbo.Niveaux", new[] { "Cycle_Id" });
            DropTable("dbo.Niveaux");
            DropTable("dbo.Cycles");
            DropTable("dbo.Autorisations");
        }
    }
}
