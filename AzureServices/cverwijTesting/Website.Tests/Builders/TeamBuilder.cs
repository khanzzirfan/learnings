using ChristiaanVerwijs.MvcSiteWithEntityFramework.Repositories;
using System;

namespace ChristiaanVerwijs.MvcSiteWithEntityFramework.WebSite.Tests
{
    public class TeamBuilder
    {
        private int id;
        private string name;
        private DateTime? deleted = null;

        public TeamBuilder()
        {
            this.id = RandomNumber.Get(); 
        }

        public static implicit operator Team(TeamBuilder builder)
        {
            return builder.Build();
        }

        public Team Build()
        {
            return new Team
            {
                Id = id,
                Name = name,
                Deleted = deleted
            };
        }

        public TeamBuilder WithName(string name)
        {
            this.name = name;
            return this;
        }
    }
}
