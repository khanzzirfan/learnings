using ChristiaanVerwijs.MvcSiteWithEntityFramework.Repositories;
using System;

namespace ChristiaanVerwijs.MvcSiteWithEntityFramework.WebSite.Tests
{
    public class ApplicationBuilder
    {
        private int id;
        private string name;
        private DateTime? deleted = null;
        private Team team;

        public ApplicationBuilder()
        {
            this.id = RandomNumber.Get();
            this.team = new Team();
        }

        public static implicit operator Application(ApplicationBuilder builder)
        {
            return builder.Build();
        }

        public Application Build()
        {
            return new Application
            {
                Id = id,
                Name = name,
                Deleted = deleted,
                TeamId = team.Id,
                Team = team
            };
        }

        public ApplicationBuilder WithName(string name)
        {
            this.name = name;
            return this;
        }

        public ApplicationBuilder WithDefaultTeam()
        {
            this.team = new TeamBuilder().WithName("Team").Build();
            return this;
        }

        public ApplicationBuilder WithTeam(Team team)
        {
            this.team = team;
            return this;
        }
    }
}
