using EmpApp2.DL;
using EmpApp2.Enums;
using EmpApp2.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpApp2.Service
{
    public class ClockService
    {
        public static void Clock(string phone, LogType logtype)
        {
            var EmpDb = new EmployeeDB();
            var d = DateTime.Now;
            var clockTime = DateTimeSQLite.Value(d);
            var emp = EmpDb.GetEmployeeDetails().FirstOrDefault(c => c.Phone == phone);

            var log = new LogDetails()
            {
                EmpId = emp.Id,
                LogType = logtype.ToString(),
                LogTime = clockTime,
            };

            EmpDb.AddEmployeeLog(log);
        }

    }
}
