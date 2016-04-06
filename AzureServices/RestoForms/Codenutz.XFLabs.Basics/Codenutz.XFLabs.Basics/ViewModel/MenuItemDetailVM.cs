using System;

using Xamarin.Forms;
using Codenutz.XFLabs.Basics.Model;
using XLabs.Platform.Device;
using Codenutz.XFLabs.Basics.DAL;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using Codenutz.XFLabs.Basics.Manager;
using System.Linq;
using Plugin.Toasts;
using Codenutz.XFLabs.Basics.View;

namespace Codenutz.XFLabs.Basics.ViewModel
{
    public class MenuItemDetailVM : BaseViewModel
    {
        public MenuDAO Menu { get; set; }
        public string StoreName { get; set; }

        public MenuItemDetailVM(Page page, string restoName, MenuDAO menu)
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
        {
		}

		#region Commands
		Command placeOrderCommand;
		public Command PlaceOrderCommand
		{
			get
			{
				return placeOrderCommand ??
					(placeOrderCommand = new Command(async () => await ExecutePlaceOrderCommand(), () => { return !IsBusy; }));
			}
		}

		Command removeOrderCommand;
		public Command RemoveOrderCommand
		{
			get
			{
				//Menu.QuantityOrdered = 0; //A trick to delete the order;
				return removeOrderCommand ??
					(removeOrderCommand = new Command(async () => await ExecutePlaceOrderCommand(), () => { return !IsBusy; }));
			}
		}
		#endregion


		async Task ExecutePlaceOrderCommand()
		{
			if (IsBusy)
				return;

			Message = "Submitting feedback...";
			IsBusy = true;
			PlaceOrderCommand.ChangeCanExecute();
			var showAlert = false;

			try
			{
				ViewModelHelper.AddOrUpdateOrderItem(Menu);
			}
			catch (Exception ex)
			{
				showAlert = true;
				//Xamarin.Insights.Report(ex);
			}
			finally
			{
				IsBusy = false;
				PlaceOrderCommand.ChangeCanExecute();
			}

			if (showAlert)
				await page.DisplayAlert("Uh Oh :(", "Unable to place order, please try again.", "OK");
			else
			{
				var notificator = DependencyService.Get<IToastNotificator>();
				bool tapped = await notificator.Notify(ToastNotificationType.Success, "Successful", "Order Updated", TimeSpan.FromSeconds(2));
			}
			
		}
		
	}
}

