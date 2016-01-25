using System;
using System.Linq;
using System.Collections.Generic;

namespace ChristiaanVerwijs.MvcSiteWithEntityFramework.Repositories
{
    public class TeamRepository : RepositoryBase<Team>, ITeamRepository
    {
        public TeamRepository(IDataContext dataContext)
            : base(dataContext)
        {
        }
    }
}
