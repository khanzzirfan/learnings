using System;
using System.Collections.Generic;

namespace EmpApp2.Model
{
    public class EmployeeDetails
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string JobTitle { get; set; }
        public string ThumbUrl { get; set; }

        public Uri ImageUri
        {
            get { return new System.Uri(ThumbUrl); }
        }

        public virtual ICollection<EmployeeLog> EmployeeLogs { get; set; }

    }


}
