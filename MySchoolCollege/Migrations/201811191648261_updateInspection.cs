namespace MySchoolCollege.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateInspection : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inspections", "InspectionParent_Id", c => c.Int());
            CreateIndex("dbo.Inspections", "InspectionParent_Id");
            AddForeignKey("dbo.Inspections", "InspectionParent_Id", "dbo.Inspections", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inspections", "InspectionParent_Id", "dbo.Inspections");
            DropIndex("dbo.Inspections", new[] { "InspectionParent_Id" });
            DropColumn("dbo.Inspections", "InspectionParent_Id");
        }
    }
}
