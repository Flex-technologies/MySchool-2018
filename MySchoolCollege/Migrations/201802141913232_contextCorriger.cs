namespace MySchoolCollege.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contextCorriger : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetRoles", "Description", c => c.String());
            AddColumn("dbo.AspNetRoles", "DateCreation", c => c.DateTime());
            AddColumn("dbo.AspNetRoles", "DateModification", c => c.DateTime());
            AddColumn("dbo.AspNetRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetRoles", "Discriminator");
            DropColumn("dbo.AspNetRoles", "DateModification");
            DropColumn("dbo.AspNetRoles", "DateCreation");
            DropColumn("dbo.AspNetRoles", "Description");
        }
    }
}
