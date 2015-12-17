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
            var searchOption = args.Item as SearchRestaurant;
            if (searchOption == null)
                return;

            Navigation.PushAsync(new TabbedMenu(searchOption.Title));
            // Reset the selected item
            list.SelectedItem = null;
        }

    }
}
