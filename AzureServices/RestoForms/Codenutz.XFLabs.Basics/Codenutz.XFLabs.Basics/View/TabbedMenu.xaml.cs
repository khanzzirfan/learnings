using Codenutz.XFLabs.Basics.Model;
using Codenutz.XFLabs.Basics.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs;

namespace Codenutz.XFLabs.Basics.View
{
    public partial class TabbedMenu : TabbedPage
    {
        private MenuViewModel viewModel;
        private string _RestoTitle { get; set; }
        public ToolbarItem AboutUs { get; set; }
        public ToolbarItem Cart { get; set; }
        public ToolbarItem Reservation { get; set; }

        public string RestoTitle
        {
            get { return _RestoTitle;}
            set { _RestoTitle = value; }
        }

        public TabbedMenu(string restoName)
        {
            this.Title = restoName;
            InitializeComponent();
            RestoTitle = restoName;
            string platformName = Device.OS.ToString();

            AboutUs = new ToolbarItem
            {
                Name = "About Us",
                Order = ToolbarItemOrder.Primary,
                Icon = "ic_action_info.png",
                Priority = 2,
                Command = new Command(() => this.LoadStorePage(restoName)),
            };

            Cart = new ToolbarItem
            {
                Name = "Cart",
                Order = ToolbarItemOrder.Primary,
                Priority = 1,
                Icon = "ic_action_cart.png",
                Command = new Command( () =>  Navigation.PushAsync(new OrderDetails()))
            };

            Reservation = new ToolbarItem
            {
                Name = "ReserveTable",
                Order = ToolbarItemOrder.Primary,
                Priority = 0,
                Icon = "ic_action_calendar_day.png",
                Command = new Command(() => this.ReserveTable(restoName))
            };

            this.ToolbarItems.Add(AboutUs);
            this.ToolbarItems.Add(Cart);
            this.ToolbarItems.Add(Reservation);

            var v = new MenuViewModel(this, "");
            var source = v.MenuCollection;
            this.ItemsSource = source;
            BindingContext = viewModel = new MenuViewModel(this, "");
           
        }

        public async void ReserveTable(string restoName)
        {
            await Navigation.PushAsync(new ReserveTable(restoName));
        }
        /// <summary>
        /// Call Reserve Table page with specific restaurant page name;
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void OnReserveTableClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ReserveTable(_RestoTitle));
        }

        public async void OnItemSelected(object sender, ItemTappedEventArgs args)
        {
            
            var menuItem = args.Item as Menu;
            if (menuItem == null)
                return;
            try
            {
                Navigation.PushAsync(new MenuItemDetailPage(RestoTitle,menuItem));
            }
            catch (Exception ex)
            {
                DisplayAlert("Help", "Error loading tabbed view", "OK");
            }

            //list.SelectedItem = null;
        }

        public async void RemoveClicked(object sender, EventArgs args)
        {
            var item = (Button)sender;
            var parameter = item.CommandParameter.ToString();

        }

        public async void AddClicked(object sender, EventArgs args)
        {
            var item = (Button)sender;
            var parameter = item.CommandParameter.ToString();
        }

        #region dataset
        private async Task<int> LoadStorePage(string storeName)
        {
            string d1_dessert_v1 = "https://lh3.googleusercontent.com/-Xh8aY2RRwd0/VeFCHSv2lzI/AAAAAAAAAOY/8SY3a6qk7WM/d1_icecream.png";

            var closeTime = "11pm";
            var openTime = "11am";
            var store = new Store()
            {
                Name = storeName,
                City = "Auckland",
                Country = "New Zealand",


                Latitude = -36.891932,
                LocationCode = "Av pres Rouque Saenz Pena 875",
                LocationHint = "Buenos Alres C1035AAD",
                Longitude = 174.736355,
                MondayClose = closeTime,
                TuesdayClose = closeTime,
                WednesdayClose = closeTime,
                ThursdayClose = closeTime,
                FridayClose = closeTime,
                SaturdayClose = closeTime,
                SundayClose = closeTime,

                MondayOpen = openTime,
                TuesdayOpen = openTime,
                WednesdayOpen = openTime,
                ThursdayOpen = openTime,
                FridayOpen = openTime,
                SaturdayOpen = openTime,
                SundayOpen = openTime,

                Version = "11",
                PhoneNumber = "0220778677",
                State = "Auckland",
                StreetAddress = "12 Sandringham",
                ZipCode = "1065",
                ImageUri = new Uri(d1_dessert_v1),
                Image = d1_dessert_v1

            };

            await Navigation.PushAsync(new StorePage(store));
            return 1;
        }
        #endregion

        public async void OnCheckBoxChanged(object sender, EventArgs<bool> eventArgs)
        {
            this.ToolbarItems.Remove(Cart);

            if (eventArgs.Value)
            {
                Cart = new ToolbarItem
                {
                    Name = "Cart",
                    Order = ToolbarItemOrder.Primary,
                    Priority = 1,
                    Icon = "cartfilled.png",
                    Command = new Command(() => this.LoadStorePage(RestoTitle))
                };
                this.ToolbarItems.Add(Cart);
            }
            else
            {
                Cart = new ToolbarItem
                {
                    Name = "Cart",
                    Order = ToolbarItemOrder.Primary,
                    Priority = 1,
                    Icon = "scart48.png",
                    Command = new Command(() => this.LoadStorePage(RestoTitle))
                };
                this.ToolbarItems.Add(Cart);
            }

            

        }
    }
}
