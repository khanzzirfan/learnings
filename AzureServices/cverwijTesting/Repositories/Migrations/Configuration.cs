namespace ChristiaanVerwijs.MvcSiteWithEntityFramework.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        // For more information, see http://blog.safaribooksonline.com/2013/05/20/entity-framework-using-database-migration-to-seed-our-database/
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DataContext context)
        {
            context.Teams.AddOrUpdate(p => p.Name,
                new Team() { Name = "Team A" },
                new Team() { Name = "Team B" });
            context.SaveChanges();

            context.Applications.AddOrUpdate(p => p.Name,
                new Application() { Name = "Application A", TeamId = context.Teams.First(x => x.Name == "Team A").Id, Description = "This is application A" },
                new Application() { Name = "Application B", TeamId = context.Teams.First(x => x.Name == "Team B").Id, Description = "This is application B" },
                new Application() { Name = "Application C", TeamId = context.Teams.First(x => x.Name == "Team A").Id, Description = "This is application C" });
            context.SaveChanges();
        }
    }
}