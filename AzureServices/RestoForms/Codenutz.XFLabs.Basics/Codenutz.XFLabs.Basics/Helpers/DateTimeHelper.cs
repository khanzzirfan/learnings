using Codenutz.XFLabs.Basics.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codenutz.XFLabs.Basics.Helpers
{
    public static class DateTimeHelper
    {

        public static DateTime RoundUp(DateTime dt, TimeSpan d)
        {
            return new DateTime(((dt.Ticks + d.Ticks - 1) / d.Ticks) * d.Ticks);
        }
        
        public static IEnumerable<string> GetHalfHourInterval(DateTime from)
        {
            DateTime dt_now = DateTime.Now;
            string strclosingTime = Convert.ToString(dt_now.ToString("yyyy MMMMM dd")) + " " + "21:00";
            DateTime closedTime = DateTime.ParseExact(strclosingTime, "yyyy MMMMM dd HH:mm", CultureInfo.InvariantCulture);

            DateTimeFormatInfo timeFormat = new DateTimeFormatInfo();
            timeFormat.ShortTimePattern = CultureInfo.CurrentCulture.DateTimeFormat.ShortTimePattern;
            timeFormat.AMDesignator = "AM";
            timeFormat.PMDesignator = "PM";

            for (var _time = from; _time <= closedTime; _time = _time.AddMinutes(30))
                yield return string.Format(timeFormat, "{0:t}", (_time));
        }

        //public static IEnumerable<Timer> GetTimerInterval(DateTime from)
        //{
        //    DateTime dt_now = DateTime.Now;
        //    DateTime FromDate;
        //    string strclosingTime = Convert.ToString(from.ToString("yyyy MMMMM dd")) + " " + "21:00";
        //    DateTime closedTime = DateTime.ParseExact(strclosingTime, "yyyy MMMMM dd HH:mm", CultureInfo.InvariantCulture);

        //    if (dt_now.Date == from.Date)
        //    {
        //        FromDate = dt_now.AddHours(1);
        //    }
        //    //else
        //    //{
        //    //    string openingTime = Convert.ToString(from.ToString("yyyy MMMMM dd")) + " " + context.Resources.GetString(Resource.String.opentime);
        //    //    DateTime openingDateTime = DateTime.ParseExact(openingTime, "yyyy MMMMM dd HH:mm", CultureInfo.InvariantCulture);
        //    //    FromDate = openingDateTime;
        //    //}
        //    DateTimeFormatInfo timeFormat = new DateTimeFormatInfo();
        //    timeFormat.ShortTimePattern = CultureInfo.CurrentCulture.DateTimeFormat.ShortTimePattern;
        //    timeFormat.AMDesignator = "AM";
        //    timeFormat.PMDesignator = "PM";


        //    //Round to nearest 30 minutes to current time.
        //    FromDate = DateTimeHelper.RoundUp(DateTime.Parse(FromDate.ToString("g")), TimeSpan.FromMinutes(30));

        //    for (var _time = FromDate; _time <= closedTime; _time = _time.AddMinutes(30))
        //        yield return new Timer() { Time = string.Format(timeFormat, "{0:t}", (_time)), Availability = "Yes" };

        //}

        public static IEnumerable<Timer> GetDates(DateTime from)
        {
            DateTime dt_now = DateTime.Now;
            DateTime _datesAvaliable = dt_now.AddDays(2);

            for (var _date = from; _date <= _datesAvaliable; _date = _date.AddDays(1))
                yield return new Timer() { Time = string.Format("{0:dd/MMM/yyyy}", _date), Availability = "Yes" };

        }

        public static double ConvertDaysToMilliseconds(double days)
        {
            return TimeSpan.FromDays(days).TotalMilliseconds;
        }

        public static long LConvertDaysToMilliseconds(long days)
        {
            return (long)(TimeSpan.FromDays(days).TotalMilliseconds);
        }

        public static long SetMaxDate(int days)
        {
            DateTime _dt_now = DateTime.Now;
            DateTime _start = new DateTime(1970, 1, 1);
            TimeSpan ts = (_dt_now - _start);

            //Add Days to SetMax Days;
            int noOfDays = ts.Days + days;
            return (long)(TimeSpan.FromDays(noOfDays).TotalMilliseconds);
        }

        public static long SetMinDate(int days)
        {
            DateTime _dt_now = DateTime.Now;
            DateTime _start = new DateTime(1970, 1, 1);
            TimeSpan ts = (_dt_now - _start);
            //Add Days to SetMax Days;
            int noOfDays = ts.Days - days;
            return (long)(TimeSpan.FromDays(noOfDays).TotalMilliseconds);
        }

        public static List<string> GetOrderDates(int no_of_days)
        {
            DateTime dt_now = DateTime.Now;
            DateTime _datesAvaliable = dt_now.AddDays(no_of_days);
            var dateList = new List<string>();
            for (var _date = dt_now; _date <= _datesAvaliable; _date = _date.AddDays(1))
            {
                dateList.Add(string.Format("{0:ddd, MMM d, yyyy}", _date));
            }
            return dateList;
        }

    }
}
