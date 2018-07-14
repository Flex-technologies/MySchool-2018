namespace MySchoolCollege.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MiseAjourDb4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MotifAbsences",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                        Recevable = c.Boolean(nullable: false),
                        ReglerAdministrativement = c.Boolean(nullable: false),
                        HorsEtablissement = c.Boolean(nullable: false),
                        Sante = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MotifRetards",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                        Recevable = c.Boolean(nullable: false),
                        ReglerAdministrativement = c.Boolean(nullable: false),
                        Bulletin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MotifRetards");
            DropTable("dbo.MotifAbsences");
        }
    }
}
