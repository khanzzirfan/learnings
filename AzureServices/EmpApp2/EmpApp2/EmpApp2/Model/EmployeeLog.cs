using System;

namespace EmpApp2.Model
{
    public class EmployeeLog
    {
        public int EmpID { get; set; }
        public LogType LogType { get; set; }
        public DateTime? LogTime { get; set; }

        public string LogMessage
        {
            get
            {
                var logstring = "";
                if (LogTime.HasValue)
                {
                    var currentDate = DateTime.Now.Date;
                    var timeSpan = (currentDate - LogTime.Value.Date).Days;
                    if (timeSpan < 1)
                        logstring = "today";
                    else if (timeSpan < 2)
                        logstring = "yesterday";
                    else
                        logstring = string.Format("{0:d}", LogTime);
                }
                
                return string.Format("Clocked [{0}] {1} at {2:t}",LogType.ToString(), logstring, LogTime.Value);
            }
        }
    }

    public enum LogType
    {
        In,
        Out
    }
}
