using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Platform.Device;
namespace EmpApp2.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {
        //public ObservableCollection<Home> HomePage { get; set; }
        public HomeViewModel(Page page)
            : base(page)
        {
            IsBusy = true;
        }

        public HomeViewModel(IDevice device)
            : base(device)
        {
            Message = String.Format("Hello Xamarin Forms Labs MVVM Basics!! How is your {0} device", device.Manufacturer);
            Title = "EmployeeApp";
            Message = "HomeModel";
            IsBusy = true;

            Task.Run(()=> ShowAsBusy());
            

        }

        public async Task ShowAsBusy()
        {
            await Task.Delay(1000);
            IsBusy = false;
        }

        public HomeViewModel()
        {
            Title = "EmployeeApp";
            Message = "HomeModel";
            IsBusy = true;

            Task.Run(() => ShowAsBusy());
        }


    }
}
