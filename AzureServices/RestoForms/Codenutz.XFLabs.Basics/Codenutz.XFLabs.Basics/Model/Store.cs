using System;
namespace Codenutz.XFLabs.Basics.Model
{
    public class Store
    {
        public Store()
        {
            Name = string.Empty;
            LocationHint = string.Empty;
            StreetAddress = string.Empty;
            City = string.Empty;
            State = string.Empty;
            Country = string.Empty;
            ZipCode = string.Empty;
            Image = string.Empty;
            Latitude = 0;
            Longitude = 0;
            MondayClose = string.Empty;
            MondayOpen = string.Empty;
            TuesdayClose = string.Empty;
            TuesdayOpen = string.Empty;
            WednesdayClose = string.Empty;
            WednesdayOpen = string.Empty;
            ThursdayClose = string.Empty;
            ThursdayOpen = string.Empty;
            FridayClose = string.Empty;
            FridayOpen = string.Empty;
            SaturdayClose = string.Empty;
            SaturdayOpen = string.Empty;
            SundayClose = string.Empty;
            SundayOpen = string.Empty;
            PhoneNumber = string.Empty;
            LocationCode = string.Empty;
        }


        public string Id { get; set; }
        public string Version { get; set; }
        public string Name { get; set; }
        public string LocationHint { get; set; }
        public Uri ImageUri { get; set; }

        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string Image { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public string MondayOpen { get; set; }
        public string MondayClose { get; set; }
        public string TuesdayOpen { get; set; }
        public string TuesdayClose { get; set; }
        public string WednesdayOpen { get; set; }
        public string WednesdayClose { get; set; }
        public string ThursdayOpen { get; set; }
        public string ThursdayClose { get; set; }
        public string FridayOpen { get; set; }
        public string FridayClose { get; set; }
        public string SaturdayOpen { get; set; }
        public string SaturdayClose { get; set; }
        public string SundayOpen { get; set; }
        public string SundayClose { get; set; }

        public string PhoneNumber { get; set; }
        public string LocationCode { get; set; }

        public class RestoDetail
        {
            public string DisplayImage { get; set; }
            public string Name { get; set; }
            public string Suburb { get; set; }
            public string Phone { get; set; }
        }


    }
}
