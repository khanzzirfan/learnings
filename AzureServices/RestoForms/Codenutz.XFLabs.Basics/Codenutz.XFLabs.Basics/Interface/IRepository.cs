using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Codenutz.XFLabs.Basics.Interface
{
    public interface IRepository<T> where T : new()
    {
        List<T> GetItems();
        T GetItem(int id);
        int SaveItem(T entity);
        int DeleteItem(T entity);
        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
        List<T> FindById(int id);
    }


}
