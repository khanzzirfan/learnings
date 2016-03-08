using Codenutz.XFLabs.Basics.Manager;
using Codenutz.XFLabs.Basics.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Platform.Device;

namespace Codenutz.XFLabs.Basics.ViewModel
{
    public class OrderDetailViewModel : BaseViewModel
    {
        public ObservableCollection<OrderDetails> OrderDetail { get; set; }
        const string title = "My Order";
        
        public OrderDetailViewModel(Page page)
            : base(page)
        {
            Title = title;
            OrderDetail = new ObservableCollection<OrderDetails>();
            
        }

        public OrderDetailViewModel(IDevice device):base(device)
        {
            Title = title;
            OrderDetail = new ObservableCollection<OrderDetails>();
            Message = String.Format("Hello Xamarin Forms Labs MVVM Basics!! How is your {0} device", device.Manufacturer);
        }

        public OrderDetailViewModel()
        {
            Title = title;
            OrderDetail = new ObservableCollection<OrderDetails>();
        }

        private Command getOrderListCommand;
        public Command GetOrderListCommand
        {
            get { return getOrderListCommand ?? (getOrderListCommand = new Command(async () => await ExecuteGetOrdersCommand(), () => { return IsBusy; }));
            }
        }

        private async Task ExecuteGetOrdersCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            GetOrderListCommand.ChangeCanExecute();
            var showAlert = false;
            try
            {
                OrderDetail.Clear();
                GetOrderDetailsList();
            }
            catch (Exception ex)
            {
                showAlert = true;
                //Xamarin.Insights.Report(ex);
            }
            finally
            {
                IsBusy = false;
                GetOrderListCommand.ChangeCanExecute();
            }

            if (showAlert)
                await page.DisplayAlert("Uh Oh :(", "Unable to gather stores.", "OK");

        }

        private void GetOrderDetailsList()
        {
            var odrepo = RepositoryManager.OrderDetailRepo();

			//Select only items in the cart; which are not invoiced
			var orderitems = odrepo.SearchFor(c => c.OrderId <= 0).ToList();

			var list = orderitems.Select(c => new OrderDetails()
            {
                ID = c.ID,
                MenuID = c.MenuID,
                MenuName = odrepo.GetMenuNameById(c.MenuID),
                Price = c.Price,
                Quantity = c.Quantity,
            }).ToList();

            TotalAmount = list.Sum(c => c.Price * c.Quantity);
            OnPropertyChanged("TotalAmount");

            foreach (var od in list)
            {
                OrderDetail.Add(od);
            }

        }


        #region properties
        decimal totalAmount= 0.0m;
        public decimal TotalAmount
        {
            get { return totalAmount; }
            set { SetProperty(ref totalAmount, value); }
        }
        #endregion


    }
}
