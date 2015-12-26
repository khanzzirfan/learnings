using System;
using System.Globalization;
using Xamarin.Forms;

namespace EmpApp2.Converters
{
    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var logMessage = value as string;
            if (logMessage.Contains("today"))
            {
                return Color.Green;
            }

            return Color.Red;
            //throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
