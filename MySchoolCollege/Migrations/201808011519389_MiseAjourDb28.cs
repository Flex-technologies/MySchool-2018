namespace MySchoolCollege.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MiseAjourDb28 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Etablissements", "Adresse", c => c.String());
            DropColumn("dbo.Etablissements", "Addresse");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Etablissements", "Addresse", c => c.String());
            DropColumn("dbo.Etablissements", "Adresse");
        }
    }
}
