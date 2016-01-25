using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChristiaanVerwijs.MvcSiteWithEntityFramework.Repositories.Tests
{
    /// <summary>
    /// Implementation of a test repository that is not tied to any domain specific logic
    /// </summary>
    public class TestRepository : RepositoryBase<TestEntity>
    {
        public TestRepository(IDataContext dataContext)
            : base(dataContext)
        {
        }
    }
}
