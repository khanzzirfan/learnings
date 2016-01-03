using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Codenutz.XFLabs.Basics.Helpers
{
    public class IntegerToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int theInt = (int)value;
            return theInt.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string strValue = value as string;
            if (string.IsNullOrEmpty(strValue))
                return 0;

            int resultInt;
            if (int.TryParse(strValue, out resultInt))
            {
                return resultInt;
            }
            return 0;
        }
    }

}
