using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ChristiaanVerwijs.MvcSiteWithEntityFramework.Repositories.Tests
{
    public class FakeDataContext : IDataContext
    {
        private IDbSet<TestEntity> dbSet = new InMemoryDbSet<TestEntity>();
        private bool saveWasCalled;

        public IDbSet<T> Set<T>() where T : class
        {
            return (IDbSet<T>)dbSet;
        }

        public int SaveChanges()
        {
            saveWasCalled = true;
            return 0;
        }

        public void ExecuteCommand(string command, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public bool SaveWasCalled
        {
            get { return saveWasCalled; }
        }
    }
}
