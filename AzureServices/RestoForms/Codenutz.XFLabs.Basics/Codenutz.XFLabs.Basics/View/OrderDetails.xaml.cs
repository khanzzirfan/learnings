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
        OrderDetailViewModel viewModel;
        public OrderDetails()
        {
            InitializeComponent();
            BindingContext = viewModel = new OrderDetailViewModel(this);
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
