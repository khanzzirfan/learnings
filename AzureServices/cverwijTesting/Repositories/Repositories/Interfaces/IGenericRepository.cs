using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NowOnline.AppHarbor.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        void DeleteAndSubmit(T entity);
        void DeleteAndSubmit(int id);
        IEnumerable<T> GetAll();
        void UpdateAndSubmit(T entity);
        void InsertAndSubmit(T entity);
        T GetById(int id);
        IQueryable<T> DataSource();

        /// <summary>
        /// Generic get method to ensure filtering and ordering is done by the database.
        /// </summary>
        /// <param name="filter">Provide a lambda expression based on the TEntity type, which will return a Boolean value. For example "phase => phase.Id == 1"</param>
        /// <param name="orderBy">Provide a lambda expression with an IQueryable object as input and which returns an ordered version of that IQueryable object. For example "q=>q.OrderBy(i => i.Sequence)" </param>
        /// <param name="includeProperties">A list of properties wich will be eagerly loaded by the database. For example "responseOption=>responseOption.Item". Multiple parameters can be provided by using comma's.</param>
        IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            params Expression<Func<T, object>>[] includeProperties);
    }
}
