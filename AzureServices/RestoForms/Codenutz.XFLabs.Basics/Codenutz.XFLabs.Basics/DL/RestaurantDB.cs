﻿using Codenutz.XFLabs.Basics.Contracts;
using Codenutz.XFLabs.Basics.DAL;
using Codenutz.XFLabs.Basics.Interface;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Codenutz.XFLabs.Basics.DL
{
    public class RestaurantDB
    {
        static object locker = new object();

        private SQLiteConnection _connection;

        //Dispose
        public void Dispose()
        {
            _connection.Dispose();
        }

        public RestaurantDB()
        {
            try
            {
                _connection = DependencyService.Get<ISQLite>().GetConnection();
                //Add All Tables;
                UpdateDataModel();
            }
            catch (Exception ex)
            {
                var checkresponse = ex.Message.ToString();
            }

        }

        public void UpdateDataModel()
        {
            var seedData = false;
            // create the tables
            if (CountTable<BuildVersion>() < 1)
            {
                seedData = true;
                _connection.CreateTable<BuildVersion>();
            }

            if (!_connection.Table<BuildVersion>().Any(c => c.IsCurrentVersion))
            {
                seedData = true;
                //Drop all tables because new version of build has been deployed;
                this.DeleteAllTables();
                //Create all tables again;
                _connection.CreateTable<HomeDAO>();
                _connection.CreateTable<RestaurantsDAO>();
                _connection.CreateTable<MenuDAO>();
                _connection.CreateTable<OrderDetailDAO>();
                _connection.CreateTable<OrderDAO>();
            }
            if (seedData)
            {
                SeedDatabase();
                UpdateBuildVersion();
            }
            
        }

        public void SeedDatabase()
        {
            SeedDB seedDB = new SeedDB();
            //Add Build Table
            var buildTab = seedDB.BuildVersion();
            this.SaveItem(buildTab);
           
            //Display List objects
            var homeDAOList = seedDB.HomeObjectsList();
            this.SaveItems(homeDAOList);

            //restaurants list;
            var restaurantlist = seedDB.RestaurantObjectList();
            this.SaveItems<RestaurantsDAO>(restaurantlist);

            //MenuDAO list;
            var menuList = seedDB.MenuObjectList();
            this.SaveItems<MenuDAO>(menuList);

        }

        public IEnumerable<T> GetItems<T>() where T : class, IBusinessEntity, new()
        {
            lock (locker)
            {
                return (from i in _connection.Table<T>() select i).ToList();
            }
        }

        public T GetItem<T>(int id) where T : class, IBusinessEntity, new()
        {
            lock (locker)
            {
                var item = _connection.Table<T>().FirstOrDefault(x => x.ID == id);
                return _connection.Table<T>().FirstOrDefault(x => x.ID == id);
            }
        }


        public int SaveItem<T>(T item) where T : IBusinessEntity
        {
            lock (locker)
            {
                if (item.ID != 0)
                {
                    _connection.Update(item);
                    return item.ID;
                }
                else
                {
                    return _connection.Insert(item);
                }
            }
        }

        /// <summary>
		/// Saves the items in bulk Transaction;.
		/// </summary>
		/// <param name="items">Items.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public void SaveItems<T>(IEnumerable<T> items) where T : IBusinessEntity
        {
            lock (locker)
            {
                _connection.BeginTransaction();

                foreach (T item in items)
                {
                    SaveItem<T>(item);
                }

                _connection.Commit();
            }
        }

        public int DeleteItem<T>(int id) where T : IBusinessEntity, new()
        {
            lock (locker)
            {
                return _connection.Delete<T>(new T() { ID = id });
            }
        }

        public int DeleteItem<T>(T item) where T : IBusinessEntity, new()
        {
            lock (locker)
            {
                return _connection.Delete(item);
            }
        }


        public IEnumerable<T> FindById<T>(int id) where T : class, IBusinessEntity, new()
        {
            lock (locker)
            {
                var list = _connection.Table<T>().Where(c => c.ID == id).AsEnumerable();
                return list;
            }
        }


        // helper for checking if database has been populated
        public int CountTable<T>() where T : class, IBusinessEntity, new()
        {
            var returnvalue = 0;
            lock (locker)
            {
                try
                {
                    returnvalue = _connection.Table<T>().Count();
                }
                catch (Exception ex)
                {
                    returnvalue = -1;
                }
            }
            return returnvalue;
        }

        public int DeleteAllTables()
        {
            try
            {
                var delQuery = @"DROP TABLE HomeDAO";
                _connection.Execute(delQuery);

                delQuery = @"DROP TABLE RestaurantsDAO";
                _connection.Execute(delQuery);

                delQuery = @"DROP TABLE MenuDAO";
                _connection.Execute(delQuery);

                delQuery = @"DROP TABLE OrderDetailDAO";
                _connection.Execute(delQuery);

                delQuery = @"DROP TABLE OrderDAO";
                _connection.Execute(delQuery);
            }
            catch (Exception ex)
            {

            }
            return 1;
        }

        public IQueryable<T> SearchFor<T>(Expression<Func<T, bool>> predicate) where T : class, IBusinessEntity, new()
        {
            return _connection.Table<T>().Where(predicate).AsQueryable();
        }


        //Get Menu Name;
        public string GetMenuNameById(int menuID)
        {
            return _connection.Table<MenuDAO>().FirstOrDefault(c => c.MenuID == menuID).Name;
        }

        public void UpdateBuildVersion()
        {
            var build = this.GetItem<BuildVersion>(1);
            var buildItems = this.GetItems<BuildVersion>();
            build.IsCurrentVersion = true;
            SaveItem<BuildVersion>(build);
        }
    }
}
