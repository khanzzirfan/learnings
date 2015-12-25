using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;

namespace EmpApp2.Model
{
    public class EmployeeDetails
    {
        [PrimaryKey]
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string JobTitle { get; set; }
        public string ThumbUrl { get; set; }

        [Ignore]
        public Uri ImageUri
        {
            get { return new System.Uri(ThumbUrl); }
        }

        [Ignore]
        public virtual ICollection<EmployeeLog> EmployeeLogs { get; set; }

    }


}
