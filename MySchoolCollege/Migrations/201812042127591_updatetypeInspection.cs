namespace MySchoolCollege.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetypeInspection : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TypeInspections", "CreerPar_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.TypeInspections", "ModifierPar_Id", "dbo.AspNetUsers");
            DropIndex("dbo.TypeInspections", new[] { "CreerPar_Id" });
            DropIndex("dbo.TypeInspections", new[] { "ModifierPar_Id" });
            DropColumn("dbo.TypeInspections", "CreerLe");
            DropColumn("dbo.TypeInspections", "ModifierLe");
            DropColumn("dbo.TypeInspections", "CreerPar_Id");
            DropColumn("dbo.TypeInspections", "ModifierPar_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TypeInspections", "ModifierPar_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.TypeInspections", "CreerPar_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.TypeInspections", "ModifierLe", c => c.DateTime(nullable: false));
            AddColumn("dbo.TypeInspections", "CreerLe", c => c.DateTime(nullable: false));
            CreateIndex("dbo.TypeInspections", "ModifierPar_Id");
            CreateIndex("dbo.TypeInspections", "CreerPar_Id");
            AddForeignKey("dbo.TypeInspections", "ModifierPar_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.TypeInspections", "CreerPar_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
