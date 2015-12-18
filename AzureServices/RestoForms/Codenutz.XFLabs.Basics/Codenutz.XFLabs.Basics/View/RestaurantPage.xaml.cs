using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codenutz.XFLabs.Basics.Model;
using Codenutz.XFLabs.Basics.ViewModel;
using Xamarin.Forms;

namespace Codenutz.XFLabs.Basics.View
{
    public partial class RestaurantPage : ContentPage
    {
        RestaurantViewModel viewModel;
        public RestaurantPage(string restoName)
        {
            InitializeComponent();
            BindingContext = viewModel = new RestaurantViewModel(this, restoName);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (viewModel.RestoDetail.Count > 0 || viewModel.IsBusy)
                return;

            //viewModel.GetRestoCommand.Execute(null);
        }
    }
}
