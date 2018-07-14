namespace MySchoolCollege.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contextCorrigerv2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Civillite", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Civillite");
        }
    }
}
