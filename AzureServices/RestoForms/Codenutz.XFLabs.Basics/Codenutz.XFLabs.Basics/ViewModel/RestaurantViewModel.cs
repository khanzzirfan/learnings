using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Codenutz.XFLabs.Basics.Model;
using XLabs.Platform.Device;

namespace Codenutz.XFLabs.Basics.ViewModel
{
    public class RestaurantViewModel : BaseViewModel
    {
        public const string RestoImage1 = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/40/Capuchin_Costa_Rica.jpg/200px-Capuchin_Costa_Rica.jpg";

        public ObservableCollection<Store.RestoDetail> RestoDetail { get; set; }
        public Store.RestoDetail RestoPage { get; set; }

        public RestaurantViewModel(Page page, string restoName)
            : base(page)
        {
            Title = restoName;
            RestoDetail = new ObservableCollection<Store.RestoDetail>();
            //Load List;
            //this.ExecuteGetRestoDetails();
            RestoPage = GetRestoPage().FirstOrDefault();
        }

        public RestaurantViewModel(IDevice device):base(device)
        {
            Message = String.Format("Hello Xamarin Forms Labs MVVM Basics!! How is your {0} device", device.Manufacturer);
        }

        public RestaurantViewModel()
        { }

        private async Task ExecuteGetRestoDetails()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            GetRestoCommand.ChangeCanExecute();
            var showAlert = false;
            try
            {
                RestoDetail.Clear();
               
               // RestoPage = GetRestoPage().FirstOrDefault();
                RestoDetail = new ObservableCollection<Store.RestoDetail>(GetRestoPage().ToList());
            }
            catch (Exception ex)
            {
                showAlert = true;
            }
            finally
            {
                IsBusy = false;
                GetRestoCommand.ChangeCanExecute();
            }
            if (showAlert)
                await page.DisplayAlert("Uh Oh :(", "Unable to gather stores.", "OK");
        }


        private Command getRestoCommand;
        public Command GetRestoCommand
        {
            get
            {
                return getRestoCommand ??
                    (getRestoCommand = new Command(async () => await ExecuteGetRestoDetails(), () => { return !IsBusy; }));
            }
        }


        #region HelperGetData
        private IEnumerable<Store.RestoDetail> GetRestoPage()
        {
            var restoDeatils = new List<Store.RestoDetail>()
                {
                    new Store.RestoDetail()
                    {
                        DisplayImage = RestoImage1,
                        Name = "Kono Pizzas",
                        Phone = "08000123",
                        Suburb= "Eden-Albert",
                    }

                };
            return restoDeatils.AsEnumerable();
        }

        #endregion
    }
}
