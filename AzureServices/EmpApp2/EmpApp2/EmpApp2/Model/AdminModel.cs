using EmpApp2.Enums;
using SQLite.Net.Attributes;
using System;

namespace EmpApp2.Model
{
    public class AdminModel
    {
        public int  EmpId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string ThumbUrl { get; set; }
        public string LogType { get; set; }
        public DateTime? LastClockedIn { get; set; }

        public Uri ImageUri 
        {
            get { return new System.Uri(ThumbUrl); }
        }

        public string LogMessage
        {
            get
            {
                var logstring = "";
                if (LastClockedIn.HasValue)
                {
                    var currentDate = DateTime.Now.Date;
                    var timeSpan = (currentDate - LastClockedIn.Value.Date).Days;
                    if (timeSpan < 1)
                        logstring = "today";
                    else if (timeSpan < 2)
                        logstring = "yesterday";
                    else
                        logstring = string.Format("{0:d}", LastClockedIn);
                }

                return string.Format("Clocked [{0}] {1} at {2:t}", LogType.ToString(), logstring, LastClockedIn.Value);
            }
        }

        
    }
}
