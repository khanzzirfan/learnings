using Codenutz.XFLabs.Basics.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Codenutz.XFLabs.Basics.View
{
    public partial class OrderInformation : ContentPage
    {
        public string StoreName { get; set; }
        public int StoreId { get; set; }
        public OrderInfoViewModel viewModel { get; set; }
        public OrderInformation(string storeName, int storeId)
        {
            InitializeComponent();
            StoreName = storeName;
            StoreId = storeId;

            BindingContext = viewModel = new OrderInfoViewModel(this,StoreName,StoreId);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //if (viewModel.OrderDetail.Count > 0 || viewModel.IsBusy)
            //    return;

            viewModel.GetOrderTotal.Execute(null);
        }

    }
}
