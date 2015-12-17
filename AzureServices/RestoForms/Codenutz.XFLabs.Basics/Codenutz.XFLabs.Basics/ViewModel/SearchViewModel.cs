using Codenutz.XFLabs.Basics.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Codenutz.XFLabs.Basics.ViewModel
{
    public class SearchViewModel : BaseViewModel
    {
        public const string RestoImage1 = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/40/Capuchin_Costa_Rica.jpg/200px-Capuchin_Costa_Rica.jpg";
        public const string RestoImage2 = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/40/Capuchin_Costa_Rica.jpg/200px-Capuchin_Costa_Rica.jpg";
        public const string RestoImage3 = "http://www.google.co.nz/imgres?imgurl=http://www.valueinvestasia.com/wp-content/uploads/2015/01/Singapore-Restaurant-Week-2012-Visual.jpg&imgrefurl=http://www.valueinvestasia.com/2015/02/02/restaurants-cluster/&h=1551&w=2386&tbnid=tJVIspwDhBTlMM:&docid=oTEl6I7d-tLx1M&ei=nCRMVpXkGeXJmAXX9LHICA&tbm=isch&ved=0CEcQMygZMBlqFQoTCJWij821mckCFeUkpgodV3oMiQ";
        public const string RestoImage4 = "http://www.google.co.nz/imgres?imgurl=http://www.valueinvestasia.com/wp-content/uploads/2015/01/Singapore-Restaurant-Week-2012-Visual.jpg&imgrefurl=http://www.valueinvestasia.com/2015/02/02/restaurants-cluster/&h=1551&w=2386&tbnid=tJVIspwDhBTlMM:&docid=oTEl6I7d-tLx1M&ei=nCRMVpXkGeXJmAXX9LHICA&tbm=isch&ved=0CEcQMygZMBlqFQoTCJWij821mckCFeUkpgodV3oMiQ";
        public const string RestoImage5 = "http://www.google.co.nz/imgres?imgurl=http://www.valueinvestasia.com/wp-content/uploads/2015/01/Singapore-Restaurant-Week-2012-Visual.jpg&imgrefurl=http://www.valueinvestasia.com/2015/02/02/restaurants-cluster/&h=1551&w=2386&tbnid=tJVIspwDhBTlMM:&docid=oTEl6I7d-tLx1M&ei=nCRMVpXkGeXJmAXX9LHICA&tbm=isch&ved=0CEcQMygZMBlqFQoTCJWij821mckCFeUkpgodV3oMiQ";
        public const string RestoImage6 = "http://www.google.co.nz/imgres?imgurl=http://www.valueinvestasia.com/wp-content/uploads/2015/01/Singapore-Restaurant-Week-2012-Visual.jpg&imgrefurl=http://www.valueinvestasia.com/2015/02/02/restaurants-cluster/&h=1551&w=2386&tbnid=tJVIspwDhBTlMM:&docid=oTEl6I7d-tLx1M&ei=nCRMVpXkGeXJmAXX9LHICA&tbm=isch&ved=0CEcQMygZMBlqFQoTCJWij821mckCFeUkpgodV3oMiQ";


        public ObservableCollection<SearchRestaurant> SearchRestaurants { get; set; }
        public SearchViewModel(Page page)
            : base(page)
        {
            Title = "My Restaurant";
            SearchRestaurants = new ObservableCollection<SearchRestaurant>();

            //Load List;
            this.ExecuteGetStoresCommand();

        }
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
                var restolist = new List<SearchRestaurant>()
                {
                    new SearchRestaurant("Auckland Resto A", "Level 2 | (480) 792-9275", RestoImage1),
                    new SearchRestaurant("Waikato Resto B","Level 2 | (480) 792-9275", RestoImage1),
                    new SearchRestaurant("Hamilton Resto C", "Level 1 | (480) 786-8092", RestoImage1),
                    new SearchRestaurant("Melbourne Resto D", "Level 2 | (480) 812-0090", RestoImage1),
                    new SearchRestaurant("Sydney Resto F", "Level 1 | (480) 726-6944", RestoImage1),
                    new SearchRestaurant("Dunedin Resto G", "Level 2 | (480) 855-1709", RestoImage1),

                };
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
                var restaurants = new List<SearchRestaurant>()
                {
                    new SearchRestaurant("Auckland Resto A", "Level 2 | (480) 792-9275", RestoImage1),
                    new SearchRestaurant("Waikato Resto B","Level 2 | (480) 792-9275", RestoImage1),
                    new SearchRestaurant("Hamilton Resto C", "Level 1 | (480) 786-8092", RestoImage1),
                    new SearchRestaurant("Melbourne Resto D", "Level 2 | (480) 812-0090", RestoImage1),
                    new SearchRestaurant("Sydney Resto F", "Level 1 | (480) 726-6944", RestoImage1),
                    new SearchRestaurant("Dunedin Resto G", "Level 2 | (480) 855-1709", RestoImage1),

                };
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
