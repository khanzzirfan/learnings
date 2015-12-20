using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Codenutz.XFLabs.Basics.Helpers
{
    [ContentProperty("Text")]
    public class TranslateExtension: IMarkupExtension
    {

        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return null;

            return Resx.AppResource.ResourceManager.GetString(Text, CultureInfo.CurrentCulture);
        }
    }
}
