using Codenutz.XFLabs.Basics.Contracts;
using Codenutz.XFLabs.Basics.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Codenutz.XFLabs.Basics.DL;
using SQLite.Net;
using Xamarin.Forms;

namespace Codenutz.XFLabs.Basics.Manager
{
    public class AppRepository<T> : IRepository<T> where T :class, IBusinessEntity, new()
    {
        RestaurantDB db = null;
        public AppRepository()
        {
            db = new RestaurantDB();
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return db.SearchFor<T>(predicate);
        }

        public T GetItem(int id)
        {
            return db.GetItem<T>(id);
        }

        public List<T> GetItems()
        {
            return db.GetItems<T>().ToList();
        }

        public int SaveItem(T entity)
        {
            return db.SaveItem<T>(entity);
        }

        public void SaveItems(IEnumerable<T> items)
        {
            db.SaveItems(items);
        }

        public int DeleteItem(T entity)
        {
            return db.DeleteItem(entity);
        }

        public int DeleteItem(int id)
        {
            return db.DeleteItem<T>(id);
        }

        public List<T> FindById(int id)
        {
            return db.FindById<T>(id).ToList();
        }

    }
}
