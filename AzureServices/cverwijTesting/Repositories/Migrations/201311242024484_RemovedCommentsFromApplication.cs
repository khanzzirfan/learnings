namespace NowOnline.AppHarbor.Repositories
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedCommentsFromApplication : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Applications", "Comment");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Applications", "Comment", c => c.String());
        }
    }
}
