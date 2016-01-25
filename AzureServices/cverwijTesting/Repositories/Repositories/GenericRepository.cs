using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace NowOnline.AppHarbor.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private IDataContext dataContext;

        public GenericRepository(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public virtual IEnumerable<T> Get(
           Expression<Func<T, bool>> filter = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = dataContext.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties)
            {
                query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual IEnumerable<T> GetAll()
        {
            return this.DataSource();
        }

        public virtual T GetById(int id)
        {
            return this.dataContext.Set<T>().Find(id);
        }

        public virtual void InsertAndSubmit(T entity)
        {
            this.dataContext.Set<T>().Add(entity);
            this.SaveChanges();
        }

        public virtual void UpdateAndSubmit(T entity)
        {
            this.SaveChanges();
        }

        public virtual void DeleteAndSubmit(T entity)
        {
            this.dataContext.Set<T>().Remove(entity);
            this.SaveChanges();
        }

        public virtual void DeleteAndSubmit(int id)
        {
            T entity = this.dataContext.Set<T>().Find(id);

            if (entity != null)
            {
                this.dataContext.Set<T>().Remove(entity);
                this.SaveChanges();
            }
        }

        /// <summary>
        /// Returns only records that have not yet been deleted before
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<T> DataSource()
        {
            var query = dataContext.Set<T>().AsQueryable<T>();
            var property = typeof(T).GetProperty("Deleted");

            if (property != null)
            {
                query = query.Where(GetExpression("Deleted", null));
            }

            return query;
        }

        public void ExecuteCommand(string sql, params object[] parameters)
        {
            this.dataContext.ExecuteCommand(sql, parameters);
        }

        #region Private Helpers
        /// <summary>
        /// Returns expression to use in expression trees, like where statements. For example query.Where(GetExpression("IsDeleted", typeof(boolean), false));
        /// </summary>
        /// <param name="propertyName">The name of the property. Either boolean or a nulleable typ</param>
        private Expression<Func<T, bool>> GetExpression(string propertyName, object value)
        {
            var param = Expression.Parameter(typeof(T));
            var actualValueExpression = Expression.Property(param, propertyName);

            var lambda = Expression.Lambda<Func<T, bool>>(
                Expression.Equal(actualValueExpression,
                    Expression.Constant(value)),
                param);

            return lambda;
        }

        protected virtual void SaveChanges()
        {
            this.dataContext.SaveChanges();
        }
        #endregion
    }
}
