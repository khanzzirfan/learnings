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
        public string Intro { get { return "Monkey Header"; } }
        public string Summary { get { return " There were " + 10 + " monkeys"; } }

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
            var list = new List<OrderDetails>
            {
                new OrderDetails(){ID=1,MenuID=1,MenuName="Chicken Afgani",Price=10.0m,Quantity = 3},
                new OrderDetails(){ID=2,MenuID=2,MenuName="Chicken Tandoori",Price=12.0m,Quantity = 1},
                new OrderDetails(){ID=3,MenuID=3,MenuName="Chicken Kebab",Price=13.0m,Quantity = 1},
                new OrderDetails(){ID=4,MenuID=4,MenuName="Chicken Mughali",Price=14.0m,Quantity = 5},
                new OrderDetails(){ID=5,MenuID=5,MenuName="Chicken Kadai",Price=15.0m,Quantity = 7},

                new OrderDetails(){ID=1,MenuID=1,MenuName="Chicken Afgani",Price=10.0m,Quantity = 3},
                new OrderDetails(){ID=2,MenuID=2,MenuName="Chicken Tandoori",Price=12.0m,Quantity = 1},
                new OrderDetails(){ID=3,MenuID=3,MenuName="Chicken Kebab",Price=13.0m,Quantity = 1},
                new OrderDetails(){ID=4,MenuID=4,MenuName="Chicken Mughali",Price=14.0m,Quantity = 5},
                new OrderDetails(){ID=5,MenuID=5,MenuName="Chicken Kadai",Price=15.0m,Quantity = 7},

                new OrderDetails(){ID=1,MenuID=1,MenuName="Chicken Afgani",Price=10.0m,Quantity = 3},
                new OrderDetails(){ID=2,MenuID=2,MenuName="Chicken Tandoori",Price=12.0m,Quantity = 1},
                new OrderDetails(){ID=3,MenuID=3,MenuName="Chicken Kebab",Price=13.0m,Quantity = 1},
                new OrderDetails(){ID=4,MenuID=4,MenuName="Chicken Mughali",Price=14.0m,Quantity = 5},
                new OrderDetails(){ID=5,MenuID=5,MenuName="Chicken Kadai",Price=15.0m,Quantity = 7},
            };

            foreach (var od in list)
            {
                //if (string.IsNullOrWhiteSpace(store.Image))
                //  store.Image = "http://refractored.com/images/wc_small.jpg";
                OrderDetail.Add(od);
            }

        }


    }
}
