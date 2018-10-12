namespace MySchoolCollege.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MiseAjourDb29 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AnneeScolaires", "DateDebut");
            DropColumn("dbo.AnneeScolaires", "DateFin");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AnneeScolaires", "DateFin", c => c.DateTime(nullable: false));
            AddColumn("dbo.AnneeScolaires", "DateDebut", c => c.DateTime(nullable: false));
        }
    }
}
