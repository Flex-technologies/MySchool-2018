namespace MySchoolCollege.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MiseAjourDb12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "CodePostal", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "CodePostal");
        }
    }
}
