using System;
using System.Linq;
using System.Collections.Generic;

namespace ChristiaanVerwijs.MvcSiteWithEntityFramework.Repositories
{
    public class ApplicationRepository : RepositoryBase<Application>, IApplicationRepository
    {
        public ApplicationRepository(IDataContext dataContext)
            : base(dataContext)
        {
        }
    }
}
