namespace NowOnline.AppHarbor.Repositories
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedCommentsColumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Applications", "Comments");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Applications", "Comments", c => c.String());
        }
    }
}
