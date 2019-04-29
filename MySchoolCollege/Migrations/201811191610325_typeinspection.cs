namespace MySchoolCollege.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class typeinspection : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TypeInspections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        CreerLe = c.DateTime(nullable: false),
                        ModifierLe = c.DateTime(nullable: false),
                        CreerPar_Id = c.String(maxLength: 128),
                        ModifierPar_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreerPar_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ModifierPar_Id)
                .Index(t => t.CreerPar_Id)
                .Index(t => t.ModifierPar_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TypeInspections", "ModifierPar_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.TypeInspections", "CreerPar_Id", "dbo.AspNetUsers");
            DropIndex("dbo.TypeInspections", new[] { "ModifierPar_Id" });
            DropIndex("dbo.TypeInspections", new[] { "CreerPar_Id" });
            DropTable("dbo.TypeInspections");
        }
    }
}
