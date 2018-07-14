namespace MySchoolCollege.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MiseAjourDb6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Etablissements", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Etablissements", "Discriminator");
        }
    }
}
