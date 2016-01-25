using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryIK.Tests.Helpers
{
    public class InMemoryDbSet<T> : IDbSet<T> where T : class
    {
        readonly HashSet<T> data;
        readonly IQueryable<T> query;

        public InMemoryDbSet()
        {
            data = new HashSet<T>();
            query = data.AsQueryable();
        }

        public T Add(T entity)
        {
            data.Add(entity);
            return entity;
        }

        public T Attach(T entity)
        {
            return this.Add(entity);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return data.GetEnumerator();
        }


        public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity:class,T
        {
            throw new NotImplementedException();
        }

        
        public Type ElementType
        {
            get {return query.ElementType;}
        }

        public Expression Expression
        {
            get {return query.Expression;}
        }

        public ObservableCollection<T> Local
        {
            get {return  new System.Collections.ObjectModel.ObservableCollection<T>(data);}
        }

        public IQueryProvider Provider
        {
            get {return query.Provider;}
        }
        
        public T Create()
        {
            return Activator.CreateInstance<T>();
        }

        public T Find(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public T Remove(T entity)
        {
            data.Remove(entity);
            return entity;
        }
        
    }
}
