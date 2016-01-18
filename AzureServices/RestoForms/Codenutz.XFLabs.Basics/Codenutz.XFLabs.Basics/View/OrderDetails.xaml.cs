using Codenutz.XFLabs.Basics.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Codenutz.XFLabs.Basics.View
{
    public partial class OrderDetails : ContentPage
    {
        public OrderDetailViewModel viewModel;
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public OrderDetails(string storeName, int storeId)
        {
            InitializeComponent();
            StoreId = storeId;
            StoreName = storeName;
            BindingContext = viewModel = new OrderDetailViewModel(this);
            BtnPlaceOrder.Clicked += async (sender, e) => {
                await Navigation.PushAsync(new OrderInformation(StoreName,StoreId));
            };

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (viewModel.OrderDetail.Count > 0 || viewModel.IsBusy)
                return;

            viewModel.GetOrderListCommand.Execute(null);
        }

        public void OnItemSelected(object sender, ItemTappedEventArgs args)
        {
            var emp = args.Item as Model.OrderDetails;
            if (emp == null)
                return;
            // Reset the selected item
            list.SelectedItem = null;
            //Navigation.PushAsync(new EmployeeMainPage(emp.Phone));

        }

    }
}
