using Codenutz.XFLabs.Basics.Model;
using Codenutz.XFLabs.Basics.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Codenutz.XFLabs.Basics.View
{
    public partial class StorePage : ContentPage
    {
        StoreViewModel viewModel;
        public StorePage(Store store)
        {
            InitializeComponent();
            BindingContext = viewModel = new StoreViewModel(store, this);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var position = new Position(viewModel.Store.Latitude, viewModel.Store.Longitude); // Latitude, Longitude
            var pin = new Pin
            {
                Type = PinType.Place,
                Position = position,
                Label = viewModel.Store.Name,
                Address = viewModel.Store.StreetAddress
            };
            //MyMap.Pins.Add(pin);

            //MyMap.MoveToRegion(
            //    MapSpan.FromCenterAndRadius(
            //        position, Distance.FromMiles(.2)));
        }
    }
}
