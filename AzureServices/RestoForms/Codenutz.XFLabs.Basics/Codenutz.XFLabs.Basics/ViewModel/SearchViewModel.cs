using Codenutz.XFLabs.Basics.DAL;
using Codenutz.XFLabs.Basics.DL;
using Codenutz.XFLabs.Basics.Manager;

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
    public class SearchViewModel : BaseViewModel
    {
        public ObservableCollection<RestaurantsDAO> SearchRestaurants { get; set; }
        public string titleString = "Search Restaurants";
        public SearchViewModel(Page page)
            : base(page)
        {
            Title = titleString;
            SearchRestaurants = new ObservableCollection<RestaurantsDAO>();

            //Load List;
            this.ExecuteGetStoresCommand();

        }

        public SearchViewModel(IDevice device):base(device)
        {
            Message = String.Format("Hello Xamarin Forms Labs MVVM Basics!! How is your {0} device", device.Manufacturer);
        }

        public SearchViewModel()
        { }
        private string _mainText = string.Empty;
        public string MainText
        {
            get { return _mainText; }
            set
            {
                _mainText = value ?? "";

            }
        }

        private string _searchText = string.Empty;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                // _searchText = value ?? "";
                if (_searchText != value)
                {
                    _searchText = value;
                    this.ExecuteSearchStoresCommand();
                }
            }
        }

        private Command getSearchList;
        public Command GetSearchList
        {
            get
            {
                return getSearchList ??
                    (getSearchList = new Command(async () => await ExecuteGetStoresCommand(), () => { return !IsBusy; }));
            }
        }

        private async Task ExecuteGetStoresCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            GetSearchList.ChangeCanExecute();
            var showAlert = false;
            try
            {
                SearchRestaurants.Clear();

                //var stores = await dataStore.GetStoresAsync();
                var repo = RepositoryManager.RestaurantsRepo();
                var restolist = repo.GetItems();
                foreach (var store in restolist)
                {
                    //if (string.IsNullOrWhiteSpace(store.Image))
                    //  store.Image = "http://refractored.com/images/wc_small.jpg";
                    SearchRestaurants.Add(store);
                }

                //Sort();
            }
            catch (Exception ex)
            {
                showAlert = true;
                //Xamarin.Insights.Report(ex);
            }
            finally
            {
                IsBusy = false;
                GetSearchList.ChangeCanExecute();
            }

            if (showAlert)
                await page.DisplayAlert("Uh Oh :(", "Unable to gather stores.", "OK");


        }



        #region Command and associated methods for SearchCommand
        private Command searchCommand;
        public Command SearchCommand
        {
            get
            {
                return searchCommand ??
                    (searchCommand = new Command(async () => await ExecuteSearchStoresCommand(), () => { return !IsBusy; }));
            }
        }

        private async Task ExecuteSearchStoresCommand()
        {
            if (IsBusy)
                return;

            // if (ForceSync)
            // Settings.LastSync = DateTime.Now.AddDays(-30);

            IsBusy = true;
            SearchCommand.ChangeCanExecute();
            var showAlert = false;
            try
            {
                SearchRestaurants.Clear();
                //await Task.Delay(2000);
                //var stores = await dataStore.GetStoresAsync();
                var repo = RepositoryManager.RestaurantsRepo();
                var restaurants = repo.GetItems();
                var searchlist = restaurants.Where(c => c.Title.ToLower().Contains(_searchText.ToLower())).AsEnumerable();

                foreach (var store in searchlist)
                {
                    //if (string.IsNullOrWhiteSpace(store.Image))
                    //  store.Image = "http://refractored.com/images/wc_small.jpg";
                    SearchRestaurants.Add(store);
                }

            }
            catch (Exception ex)
            {
                showAlert = true;
                //Xamarin.Insights.Report(ex);
            }
            finally
            {
                IsBusy = false;
                SearchCommand.ChangeCanExecute();
            }

            if (showAlert)
                await page.DisplayAlert("Uh Oh :(", "Unable to gather stores.", "OK");


        }



        #endregion

    }
}
