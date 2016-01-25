using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace ChristiaanVerwijs.MvcSiteWithEntityFramework.Repositories
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext()
            : base("database")
        {
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        //Poco Classes
        public IDbSet<Application> Applications { get; set; }
        public IDbSet<Team> Teams { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public void ExecuteCommand(string command, params object[] parameters)
        {
            base.Database.ExecuteSqlCommand(command, parameters);
        }
    }
}
