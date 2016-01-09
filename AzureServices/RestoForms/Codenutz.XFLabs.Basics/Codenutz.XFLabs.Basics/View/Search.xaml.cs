using Codenutz.XFLabs.Basics.DAL;
using Codenutz.XFLabs.Basics.Model;
using Codenutz.XFLabs.Basics.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;

namespace Codenutz.XFLabs.Basics.View
{
    public partial class Search : ContentPage
    {
        private SearchViewModel viewModel;
        public Search()
        {
            InitializeComponent();
            BindingContext = viewModel = new SearchViewModel(this);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (viewModel.SearchRestaurants.Count > 0 || viewModel.IsBusy)
                return;

            //viewModel.GetSearchList.Execute(null);
            viewModel.SearchCommand.Execute(null);
        }

        public void OnItemSelected(object sender, ItemTappedEventArgs args)
        {
            var searchOption = args.Item as RestaurantsDAO;
            if (searchOption == null)
                return;
            try
            {
                Navigation.PushAsync(new TabbedMenu(searchOption.Title));
            }
            catch (Exception ex)
            {
                DisplayAlert("Help", "Error loading tabbed view", "OK");
            }
            
            list.SelectedItem = null;
        }

    }
}
