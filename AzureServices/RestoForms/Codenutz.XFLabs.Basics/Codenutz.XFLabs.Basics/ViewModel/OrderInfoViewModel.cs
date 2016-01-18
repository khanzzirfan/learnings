using Codenutz.XFLabs.Basics.DAL;
using Codenutz.XFLabs.Basics.Manager;
using Codenutz.XFLabs.Basics.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Platform.Device;

namespace Codenutz.XFLabs.Basics.ViewModel
{
    public class OrderInfoViewModel : BaseViewModel
    {
        public int StoreId { get; set; }
        public OrderDAO OrderInformation { get; set; }

        public OrderInfoViewModel(Page page, string restoName, int storeId)
            : base(page)
        {
            Title = restoName;
            StoreId = storeId;
        }

        public OrderInfoViewModel(IDevice device) : base(device)
        {
            Message = String.Format("Hello Xamarin Forms Labs MVVM Basics!! How is your {0} device", device.Manufacturer);
        }


        public OrderInfoViewModel()
        {

        }

        private Command getOrderTotal;
        public Command GetOrderTotal
        {
            get
            {
                return getOrderTotal ??
                    (getOrderTotal = new Command(async () => await ExecuteOrderTotal(), () => { return !IsBusy; }));
            }
        }
        private async Task ExecuteOrderTotal()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            GetOrderTotal.ChangeCanExecute();
            var showAlert = false;

            try
            {
                var odrepo = RepositoryManager.OrderDetailRepo();
                var odItems = odrepo.GetItems();
                var total = odItems.Sum(c => c.Price * c.Quantity);
                OrderTotal = total;
                OnPropertyChanged("OrderTotal");
            }
            catch (Exception ex)
            {
                showAlert = true;
                //Xamarin.Insights.Report(ex);
            }
            finally
            {
                IsBusy = false;
                GetOrderTotal.ChangeCanExecute();
            }

            if (showAlert)
                await page.DisplayAlert("Uh Oh :(", "Unable to gather order information.", "OK");

        }

        Command placeOrderCommand;
        public Command PlaceOrderCommand
        {
            get
            {
                return placeOrderCommand ??
                    (placeOrderCommand = new Command(async () => await ExecutePlaceOrderCommand(), () => { return !IsBusy; }));
            }
        }

        async Task ExecutePlaceOrderCommand()
        {
            if (IsBusy)
                return;

            Message = "Submitting feedback...";
            IsBusy = true;
            PlaceOrderCommand.ChangeCanExecute();
            var showAlert = false;

            //Validate all the fields with some value
            if (!Validate())
            {
                IsBusy = false;
                PlaceOrderCommand.ChangeCanExecute();
                return;
            }
                
            try
            {
                PlaceOrder();                
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


            await page.Navigation.PopAsync();

        }


        public void PlaceOrder()
        {
            var orderRepo = RepositoryManager.OrderRepo();
            var orderdetailRepo = RepositoryManager.OrderDetailRepo();
            var odItems = orderdetailRepo.GetItems();
            var amount = odItems.Sum(c => c.Price * c.Quantity);

            var orderItem = new OrderDAO()
            {
                Comment = this.Comment,
                Name = this.Name,
                Date = this.Date,
                Phone = this.Phone,
                PickupTime = this.Time,
                IsOrderComplete = true,
                Amount = amount,
                StoreId = this.StoreId,
            };

            //Save Order Item
            orderRepo.SaveItem(orderItem);

            //Update Order Detail with latest order id;
            for (int i = 0; i < odItems.Count(); i++)
            {
                odItems[i].OrderId = orderItem.ID;
            }

            //save order details with new order id;
            orderdetailRepo.SaveItems(odItems);
        }

        public bool Validate()
        {
            if (string.IsNullOrWhiteSpace(Comment))
            {
                page.DisplayAlert("Enter Comments", "Please enter some feedback for our team.", "OK");
                return false;
            }

            if (string.IsNullOrEmpty(Phone))
            {
                page.DisplayAlert("Enter Phone Number", "Please enter phone number.", "OK");
                return false;
            }

            if (string.IsNullOrEmpty(Name))
            {
                page.DisplayAlert("Enter Name", "Please enter Order Name.", "OK");
                return false;
            }

            if (string.IsNullOrEmpty(Time))
            {
                page.DisplayAlert("Enter TIme", "Please enter order pickup time.", "OK");
                return false;
            }

            DateTime date = new DateTime();
            if (date==DateTime.MinValue)
            {
                page.DisplayAlert("Enter Date", "Please enter order pickup date.", "OK");
                return false;
            }

            return true;
        }

        #region properties
        string name = string.Empty;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }
        
        string phone = string.Empty;
        public string Phone
        {
            get { return phone; }
            set { SetProperty(ref phone, value); }
        }

        string comment = string.Empty;
        public string Comment
        {
            get { return comment; }
            set { SetProperty(ref comment, value); }
        }

        string time = string.Empty;
        public string Time
        {
            get { return time; }
            set { SetProperty(ref time, value); }
        }
        
        DateTime date = DateTime.Today;
        public DateTime Date
        {
            get { return date; }
            set
            {
                SetProperty(ref date, value);
            }
        }

        decimal ordertotal = 0.0m;
        public decimal OrderTotal
        {
            get { return ordertotal; }
            set { SetProperty(ref ordertotal, value); }
        }
        #endregion



    }
}
