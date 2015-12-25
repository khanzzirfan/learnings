using EmpApp2.Enums;
using SQLite.Net.Attributes;
using System;

namespace EmpApp2.Model
{
    public class EmployeeLog
    {
        public EmployeeLog()
        {

        }
        
        public int Id { get; set; }
        public int EmpID { get; set; }
        public string LogType { get; set; }
        public DateTime? LogTime { get; set; }
        
        public string LogMessage
        {
            get
            {
                var logstring = "";
                var dateTime = Convert.ToDateTime(LogTime);
                
                    var currentDate = DateTime.Now.Date;
                    var timeSpan = (currentDate - dateTime.Date).Days;
                    if (timeSpan < 1)
                        logstring = "today";
                    else if (timeSpan < 2)
                        logstring = "yesterday";
                    else
                        logstring = string.Format("{0:d}", dateTime);
               
                
                return string.Format("Clocked [{0}] {1} at {2:t}",LogType.ToString(), logstring, dateTime);
            }
        }
    }
    
}
