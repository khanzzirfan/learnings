using EmpApp2.Enums;
using EmpApp2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpApp2.Helpers;
using EmpApp2.DL;

namespace EmpApp2.Service
{
    public class SeedData
    {

        public List<Employee> LoadEmployeeData()
        {
            var emplist = new List<Employee>();
            var employeename = "Bill Gates";
            var empId = 1;
            var jobTitle = "Microsoft Head";
            var thumbUrl = "https://farm1.staticflickr.com/638/21489953693_81f8d5cdd8.jpg";

            var emp1 = LoadById(empId, employeename, jobTitle, thumbUrl, "505 585 456");
            emplist.Add(emp1);

            var emp2 = LoadById(2, "Tom Hanks", "Clerk", thumbUrl, "505 585 446");
            emplist.Add(emp2);

            var emp3 = LoadById(3, "Jinner Ainston", "CSR", thumbUrl, "505 585 416");
            emplist.Add(emp3);

            var emp4 = LoadById(4, "Stephen Spellberg", "IT Administrator", thumbUrl, "505 585 459");
            emplist.Add(emp4);

            var emp5 = LoadById(5, "Talor Swift", "IT Administrator", thumbUrl, "505 585 457");
            emplist.Add(emp5);

            var emp6 = LoadById(6, "Britney Spears", "Singer", thumbUrl, "505 585 438");
            emplist.Add(emp6);

            var emp7 = LoadById(7, "VasCo degama", "Xam Developer", thumbUrl, "505 585 447");
            emplist.Add(emp7);

            var emp8 = LoadById(8, "John Doe Rogers", "Developer", thumbUrl, "505 585 444");
            emplist.Add(emp8);


            var emp9 = LoadById(9, "Ashely Simpson", "Analyst", thumbUrl, "505 585 333");
            emplist.Add(emp9);

            return emplist;
        }

        private Employee LoadById(int id, string name, string jobTitle, string thumbUrl, string Phone)
        {
            var dCurrent = DateTime.Now;
            var empDetail = new Employee()
            {
                Id = id,
                Name = name,
                JobTitle = jobTitle,
                ThumbUrl = thumbUrl,
                Phone = Phone,
            };

            return empDetail;
        }


        public List<LogDetails> EmpLogDetails(int id)
        {
            var dCurrent = DateTime.Now;
            var startDay5 = DateTimeSQLite.Value(new DateTime(dCurrent.Year, dCurrent.Month, dCurrent.AddDays(-5).Day, 10, 00, 00));
            var startDay4 = DateTimeSQLite.Value(new DateTime(dCurrent.Year, dCurrent.Month, dCurrent.AddDays(-4).Day, 10, 00, 00));
            var startDay3 = DateTimeSQLite.Value(new DateTime(dCurrent.Year, dCurrent.Month, dCurrent.AddDays(-3).Day, 10, 00, 00));
            var startDay2 = DateTimeSQLite.Value(new DateTime(dCurrent.Year, dCurrent.Month, dCurrent.AddDays(-2).Day, 10, 00, 00));
            var startDay1 = DateTimeSQLite.Value(new DateTime(dCurrent.Year, dCurrent.Month, dCurrent.AddDays(-1).Day, 10, 00, 00));
            var startDay0 = DateTimeSQLite.Value(new DateTime(dCurrent.Year, dCurrent.Month, dCurrent.AddDays(-0).Day, 10, 00, 00));

            var endDay5 = DateTimeSQLite.Value(new DateTime(dCurrent.Year, dCurrent.Month, dCurrent.AddDays(-5).Day, 16, 00, 00));
            var endDay4 = DateTimeSQLite.Value(new DateTime(dCurrent.Year, dCurrent.Month, dCurrent.AddDays(-4).Day, 16, 00, 00));
            var endDay3 = DateTimeSQLite.Value(new DateTime(dCurrent.Year, dCurrent.Month, dCurrent.AddDays(-3).Day, 16, 00, 00));
            var endDay2 = DateTimeSQLite.Value(new DateTime(dCurrent.Year, dCurrent.Month, dCurrent.AddDays(-2).Day, 16, 00, 00));
            var endDay1 = DateTimeSQLite.Value(new DateTime(dCurrent.Year, dCurrent.Month, dCurrent.AddDays(-1).Day, 16, 00, 00));
            var endDay0 = DateTimeSQLite.Value(new DateTime(dCurrent.Year, dCurrent.Month, dCurrent.AddDays(0).Day, 16, 00, 00));

            var LogDetailsDetails = new List<LogDetails>();
            if (id == 3 || id == 4)
            {
                LogDetailsDetails = new List<LogDetails>()
                {
                    new LogDetails()
                    {
                        EmpId = id,
                        LogType= LogType.In.ToString(),
                        LogTime= startDay5,
                    },

                    new LogDetails()
                    {
                        EmpId = id,
                        LogType=  LogType.In.ToString(),
                        LogTime= startDay4,
                    },
                    new LogDetails()
                    {
                        EmpId = id,
                        LogType=  LogType.In.ToString(),
                        LogTime= startDay3,
                    },
                    new LogDetails()
                    {
                        EmpId = id ,
                        LogType=  LogType.In.ToString(),
                        LogTime= startDay2,
                    },

                    new LogDetails()
                    {
                        EmpId = id ,
                        LogType=  LogType.In.ToString(),
                        LogTime=startDay1,
                    },


                   new LogDetails()
                    {
                        EmpId = id,
                        LogType= LogType.Out.ToString(),
                        LogTime= endDay5,
                    },
                    new LogDetails()
                    {
                        EmpId = id,
                        LogType=  LogType.Out.ToString(),
                        LogTime= endDay4,
                    },
                    new LogDetails()
                    {
                        EmpId = id,
                        LogType=  LogType.Out.ToString(),
                        LogTime= endDay3,
                    },
                    new LogDetails()
                    {
                        EmpId =  id,
                        LogType=  LogType.Out.ToString(),
                        LogTime= endDay2,
                    },
                    new LogDetails()
                    {
                        EmpId =  id,
                        LogType=  LogType.Out.ToString(),
                        LogTime= endDay1,
                    },

                };
            }
            else
            {
                LogDetailsDetails = new List<LogDetails>()
                {
                    new LogDetails()
                    {
                        EmpId = id,
                        LogType= LogType.In.ToString(),
                        LogTime= startDay5,
                    },

                    new LogDetails()
                    {
                        EmpId = id,
                        LogType=  LogType.In.ToString(),
                        LogTime= startDay4,
                    },
                    new LogDetails()
                    {
                        EmpId = id,
                        LogType=  LogType.In.ToString(),
                        LogTime= startDay3,
                    },
                    new LogDetails()
                    {
                        EmpId = id ,
                        LogType=  LogType.In.ToString(),
                        LogTime= startDay2,
                    },

                    new LogDetails()
                    {
                        EmpId = id ,
                        LogType=  LogType.In.ToString(),
                        LogTime=startDay1,
                    },

                     new LogDetails()
                    {
                        EmpId = id,
                        LogType=  LogType.In.ToString(),
                        LogTime= startDay0,
                    },



                   new LogDetails()
                    {
                        EmpId = id,
                        LogType= LogType.Out.ToString(),
                        LogTime= endDay5,
                    },
                    new LogDetails()
                    {
                        EmpId = id,
                        LogType=  LogType.Out.ToString(),
                        LogTime= endDay4,
                    },
                    new LogDetails()
                    {
                        EmpId = id,
                        LogType=  LogType.Out.ToString(),
                        LogTime= endDay3,
                    },
                    new LogDetails()
                    {
                        EmpId =  id,
                        LogType=  LogType.Out.ToString(),
                        LogTime= endDay2,
                    },
                    new LogDetails()
                    {
                        EmpId =  id,
                        LogType=  LogType.Out.ToString(),
                        LogTime= endDay1,
                    },

                };
            }




            return LogDetailsDetails;
        }



    }
}
