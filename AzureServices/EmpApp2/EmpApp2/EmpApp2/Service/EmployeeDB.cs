using System.Collections.Generic;
using System.Linq;
using SQLite.Net;
using Xamarin.Forms;
using EmpApp2.Model;
using System;
using EmpApp2.DL;
using EmpApp2.Helpers;

namespace EmpApp2.Service
{
    public class EmployeeDB
    {
        private SQLiteConnection _sqlconnection;
        static object locker = new object();

        public EmployeeDB()
        {
            UpdateDataModel();
        }

        private void UpdateDataModel()
        {
            //Getting conection and Creating table
            _sqlconnection = DependencyService.Get<ISQLite>().GetConnection();
            //if (CountTable<LogDetails>() != 0)
            //{
            //    DeleteAll();
            //}

            if (CountTable<LogDetails>() < 1)
            {
                _sqlconnection.CreateTable<LogDetails>();
                _sqlconnection.CreateTable<Employee>();
                AddInitialData();
            }
        }

        // helper for checking if database has been populated
        public int CountTable<T>() where T :class, new()
        {
            var returnvalue = 0;

            try
            {
                //var rows = _sqlconnection.Query<EmployeeDetails>("Select Count(*) from [Employee]");
                returnvalue = _sqlconnection.Table<T>().Count();
            }
            catch (Exception ex)
            {
                returnvalue = -1;
            }
            
            return returnvalue;
        }

        private void AddInitialData()
        {
            var seed = new SeedData();
            var datalist = seed.LoadEmployeeData();

            foreach (var data in datalist)
            {
                AddEmployee(data);
                var dlist = seed.EmpLogDetails(data.Id);
                
                foreach (var d in dlist)
                {
                    AddEmployeeLog(d);
                }
            }
             
        }

        //Get all EmployeeDetails
        public IEnumerable<Employee> GetEmployeeDetails()
        {
            lock (locker)
            {
                return (from t in _sqlconnection.Table<Employee>() select t).ToList();
            }
        }

        //Get all EmployeeDetails
        public IEnumerable<LogDetails> GetEmployeeLogList()
        {
            lock (locker)
            {
                return (from t in _sqlconnection.Table<LogDetails>() select t).ToList();
            }
        }

        //Get specific student
        public Employee GetEmployee(int id)
        {
            lock (locker)
            {
                return _sqlconnection.Table<Employee>().FirstOrDefault(t => t.Id == id);
            }
        }


        //Get specific student
        public LogDetails GetEmployeeLog(int id)
        {
            lock (locker)
            {
                return _sqlconnection.Table<LogDetails>().FirstOrDefault(t => t.EmpId == id);
            }
        }

        //Delete specific EmployeeDetails
        public void DeleteEmployee(int id)
        {
            lock (locker)
            {
                DeleteEmployeeLog(id);
                _sqlconnection.Delete<Employee>(id);
            }
        }

        public void DeleteEmployeeLog(int id)
        {
            lock (locker)
            {
                _sqlconnection.Delete<LogDetails>(id);
            }
        }
        
        //Add new EmployeeDetails to DB
        public void AddEmployee(Employee emp)
        {
            lock (locker)
            {
                _sqlconnection.Insert(emp);
            }
        }

        //Add new EmployeeDetails to DB
        public void AddEmployeeLog(LogDetails log)
        {
            lock (locker)
            {
                try
                {
                    _sqlconnection.Insert(log);
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                    throw;
                }
            }
        }

        public void DeleteAll()
        {
            try
            {
                var delLogDetails = _sqlconnection.ExecuteScalar<int>("DELETE FROM [LogDetails]");
                var delEmployee = _sqlconnection.ExecuteScalar<int>("DELETE FROM [Employee]");
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                //throw;
            }
        }
    }
}
