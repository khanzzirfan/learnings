using System.Collections.Generic;
using System.Linq;
using SQLite.Net;
using Xamarin.Forms;
using EmpApp2.Model;

namespace EmpApp2.Service
{
    public class EmployeeDB
    {
        private SQLiteConnection _sqlconnection;

        public EmployeeDB()
        {
            //Getting conection and Creating table
            _sqlconnection = DependencyService.Get<ISQLite>().GetConnection();
            _sqlconnection.CreateTable<EmployeeDetails>();
            _sqlconnection.CreateTable<EmployeeLog>();
        }

        //Get all EmployeeDetails
        public IEnumerable<EmployeeDetails> GetEmployeeDetails()
        {
            return (from t in _sqlconnection.Table<EmployeeDetails>() select t).ToList();
        }

        //Get all EmployeeDetails
        public IEnumerable<EmployeeLog> GetEmployeeLog()
        {
            return (from t in _sqlconnection.Table<EmployeeLog>() select t).ToList();
        }

        //Get specific student
        public EmployeeDetails GetEmployee(int id)
        {
            return _sqlconnection.Table<EmployeeDetails>().FirstOrDefault(t => t.EmpID == id);
        }

        //Get specific student
        public EmployeeLog GetEmployeeLog(int id)
        {
            return _sqlconnection.Table<EmployeeLog>().FirstOrDefault(t => t.EmpID == id);
        }

        //Delete specific EmployeeDetails
        public void DeleteEmployee(int id)
        {
            DeleteEmployeeLog(id);
            _sqlconnection.Delete<EmployeeDetails>(id);
        }

        public void DeleteEmployeeLog(int id)
        {
            _sqlconnection.Delete<EmployeeLog>(id);
        }

        //Add new EmployeeDetails to DB
        public void AddStusent(EmployeeDetails emp)
        {
            _sqlconnection.Insert(emp);
        }

        //Add new EmployeeDetails to DB
        public void AddEmployeeLog(EmployeeLog emp)
        {
            _sqlconnection.Insert(emp);
        }



    }
}
