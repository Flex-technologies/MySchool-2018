namespace MySchoolCollege.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MisajourDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AnneeScolaires", "DateDebut", c => c.DateTime(nullable: false));
            AddColumn("dbo.AnneeScolaires", "DateFin", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AnneeScolaires", "DateFin");
            DropColumn("dbo.AnneeScolaires", "DateDebut");
        }
    }
}
