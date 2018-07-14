namespace MySchoolCollege.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MiseAjourDb11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Adresse", c => c.String());
            DropColumn("dbo.AspNetUsers", "Addresse");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Addresse", c => c.String());
            DropColumn("dbo.AspNetUsers", "Adresse");
        }
    }
}
