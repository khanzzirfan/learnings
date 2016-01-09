using Codenutz.XFLabs.Basics.DAL;
using Codenutz.XFLabs.Basics.ViewModel;
using System;
using Xamarin.Forms;

namespace Codenutz.XFLabs.Basics.View
{
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
            BindingContext = new HomeViewModel(this);

            //ButtonFindStore.Clicked += async (sender, e) =>
            //{
            //    //if (Device.Idiom == TargetIdiom.Tablet || Device.Idiom == TargetIdiom.Desktop)
            //    //  await Navigation.PushAsync(new StoresTabletPage());
            //    //else
            //    await Navigation.PushAsync(new Search());
            //};

            //ButtonLeaveFeedback.Clicked += async (sender, e) =>
            //{
            //    await Navigation.PushAsync(new Search());
            //};
            
        }


        public void OnItemSelected(object sender, ItemTappedEventArgs args)
        {
            var searchOption = args.Item as HomeDAO;
            if (searchOption == null)
                return;

            Navigation.PushAsync(new Search());
            // Reset the selected item
            list.SelectedItem = null;
        }

        void OnTapGestureRecognizerTapped_Search(object sender, EventArgs args)
        {
            DisplayAlert("Search", "Search Button Clicked", "Ok");
        }
        
        void OnTapGestureRecognizerTapped_Favourite(object sender, EventArgs args)
        {
            DisplayAlert("Search", "Search Button Clicked", "Ok");
        }

        void OnTapGestureRecognizerTapped_Reservation(object sender, EventArgs args)
        {
            DisplayAlert("Search", "Search Button Clicked", "Ok");
        }

        void OnTapGestureRecognizerTapped_Account(object sender, EventArgs args)
        {
            DisplayAlert("Search", "Search Button Clicked", "Ok");
        }

        void OnTapGestureRecognizerTapped_Cart(object sender, EventArgs args)
        {
            DisplayAlert("Search", "Search Button Clicked", "Ok");
        }

        void OnTapGestureRecognizerTapped_Info(object sender, EventArgs args)
        {
            DisplayAlert("Search", "Search Button Clicked", "Ok");
        }

    }
}
