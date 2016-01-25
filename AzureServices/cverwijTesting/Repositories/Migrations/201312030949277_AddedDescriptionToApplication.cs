namespace ChristiaanVerwijs.MvcSiteWithEntityFramework.Repositories
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDescriptionToApplication : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applications", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Applications", "Description");
        }
    }
}
