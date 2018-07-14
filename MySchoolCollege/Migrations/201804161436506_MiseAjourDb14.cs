namespace MySchoolCollege.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MiseAjourDb14 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Matricule", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Matricule");
        }
    }
}
