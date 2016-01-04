using System;

using Xamarin.Forms;
using Codenutz.XFLabs.Basics.Model;
using XLabs.Platform.Device;
namespace Codenutz.XFLabs.Basics.ViewModel
{
    public class MenuItemDetailVM : BaseViewModel
    {
        public Menu Menu { get; set; }
        public string StoreName { get; set; }

        public MenuItemDetailVM(Page page, string restoName, Menu menu)
            : base(page)
        {
            Title = restoName;
            StoreName = restoName;
            this.Menu = menu;
        }

        public MenuItemDetailVM(IDevice device):base(device)
        {
            Message = String.Format("Hello Xamarin Forms Labs MVVM Basics!! How is your {0} device", device.Manufacturer);
        }

        public MenuItemDetailVM()
        { }



    }
}

