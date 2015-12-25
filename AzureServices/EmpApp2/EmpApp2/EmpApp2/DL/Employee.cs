using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpApp2.DL
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string JobTitle { get; set; }
        public string Phone { get; set; }
        public string ThumbUrl { get; set; }
    }

    public class LogDetails
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public string LogType { get; set; }
        public string LogTime { get; set; }
    }


}
