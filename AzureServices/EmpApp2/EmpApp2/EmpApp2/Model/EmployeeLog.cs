using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpApp2.Model
{
    public class EmployeeLog
    {
        public int EmpID { get; set; }
        public LogType LogType { get; set; }
        public DateTime? LogTime { get; set; }

        public string LogMessage
        {
            get { return string.Format("Clocked at {0:d}", LogTime); }
        }
    }

    public enum LogType
    {
        LogIn,
        LogOut
    }
}
