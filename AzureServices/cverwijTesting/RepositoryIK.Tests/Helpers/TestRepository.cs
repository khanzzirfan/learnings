using ChristiaanVerwijs.MvcSiteWithEntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryIK.Tests.Helpers
{
    public class TestRepository:RepositoryBase<TestEntity>
    {
        public TestRepository(IDataContext datacontext)
            : base(datacontext)
        { }
    }
}
