namespace NowOnline.AppHarbor.Repositories
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDeletedMarkers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applications", "Deleted", c => c.DateTime());
            AddColumn("dbo.Teams", "Deleted", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teams", "Deleted");
            DropColumn("dbo.Applications", "Deleted");
        }
    }
}
