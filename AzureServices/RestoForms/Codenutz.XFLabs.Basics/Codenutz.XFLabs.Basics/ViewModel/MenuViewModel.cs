using Codenutz.XFLabs.Basics.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows.Input;
using System.ComponentModel;
using XLabs.Forms.Mvvm;
using XLabs.Platform.Device;
using Codenutz.XFLabs.Basics.Manager;
using Codenutz.XFLabs.Basics.DAL;

namespace Codenutz.XFLabs.Basics.ViewModel
{
	public class MenuViewModel : BaseViewModel
    {
        #region ImageKConstants
        string d1_dessert_v1 = "https://lh3.googleusercontent.com/-Xh8aY2RRwd0/VeFCHSv2lzI/AAAAAAAAAOY/8SY3a6qk7WM/d1_icecream.png";
        string d1_dessert_v2 = "https://lh3.googleusercontent.com/-5ye--N_DEBA/VbvmwbauncI/AAAAAAAAAMg/jFaE4EWANus/gv_dessertv1.jpg";

        string c1_chicken_v1 = "https://lh3.googleusercontent.com/-fZXGfuTB2UU/VeFCHZIIukI/AAAAAAAAAOo/hgxPzq3_a3c/c1_chicken_afgani.png";
        string c1_chicken_v2 = "https://lh3.googleusercontent.com/-nyuWEiI0BQA/Vb0ilfsVLAI/AAAAAAAAANU/3ElmooO5tdo/gchickenkebab_highres.jpg";
        string c1_chicken_v3 = "https://lh3.googleusercontent.com/-ReuUjC4E6o0/VeFCHdGMYnI/AAAAAAAAAO4/BZB_1NVlEGk/c1_smoke_chicken.png";
        string c1_chicken_v4 = "https://lh3.googleusercontent.com/-cZdvAxn0EyA/VeFCHTm_nQI/AAAAAAAAAOM/UCVCzmAh8Fk/c1_butter_chicken.jpg";
        string c1_chicken_v5 = "https://lh3.googleusercontent.com/-n_v-LXlsC6E/VbvmwT8wk8I/AAAAAAAAAL8/rRlK651PHI8/gv_ctikkav1.jpg";

        string k1_kebab_v1 = "https://lh3.googleusercontent.com/-YPQi3-4I2aY/VeFCHe7dMrI/AAAAAAAAAOM/1wa21O3L2mk/k1_seek_kebab.png";
        string k1_kebab_v2 = "https://lh3.googleusercontent.com/-1qVD5HMsCIU/VbvmwbAgdgI/AAAAAAAAAJ0/f2YLHJGJMZg/gv_Tkebab.jpg";
        string k1_kebab_v3 = "https://lh3.googleusercontent.com/-KCdcg0yKW4s/VeFCHUDg2zI/AAAAAAAAAOM/KNDLaBFVDH4/mx_burito.png";

        string l1_lamb_v1 = "https://lh3.googleusercontent.com/-rqCpTJhJ5QU/VbvmwUus3kI/AAAAAAAAAMM/GvW4J3P5RrE/gv_lambgrid.jpg";
        string gv_vege = "https://lh3.googleusercontent.com/-xaCacbUrAYA/VbvmwR3NZrI/AAAAAAAAAJ0/SQmh3Q3O1y0/gv_vegev1.jpg";
        string gv_side_dish = "https://lh3.googleusercontent.com/-WREcIrGaBYw/VbvmwYA0Z8I/AAAAAAAAAM4/xDmlBcWbfK8/gv_sidedishesv1.jpg";

        string k1_blackberry_triffle = "https://lh3.googleusercontent.com/-oacb41rLdYk/Vjh5JclD8iI/AAAAAAAAAm8/23rJR29iAhM/blackberry_triffle.png";
        string k1_brocolli = "https://lh3.googleusercontent.com/-wPsWoqCDU64/Vjh5R1ZAZiI/AAAAAAAAAnQ/ey143HEViIA/brocolli.png";
        string k1_lamb_shank = "https://lh3.googleusercontent.com/-M4MJ7oJU3Ps/Vjh5YPg_fiI/AAAAAAAAAnk/ozof7dwhzd4/lamb_shank.png";
        string k1_prawn = "https://lh3.googleusercontent.com/-3qtDisGv9yg/Vjh5fshM07I/AAAAAAAAAn0/tDzAmWtmMQo/prawn.png";
        string k1_scotch_eggs = "https://lh3.googleusercontent.com/-ReWMuvGQyb0/Vjh5ocC_0CI/AAAAAAAAAoI/I5pJRUqPt90/scotch_eggs.png";
        string k1_spring_rolls = "https://lh3.googleusercontent.com/-oSphV_HtmJg/Vjh50XCiEOI/AAAAAAAAAoc/DCYOoJfmpBg/spring_rolls.png";
        string k1_italian_prawn = "https://lh3.googleusercontent.com/-4SA0Vqw0isU/VjiTsccK1eI/AAAAAAAAApQ/Udpzd-SJ_NU/italian_prawn.png";
        #endregion

        //public ObservableCollection<Menu> MenuCollection { get; set; }
        public ObservableCollection<DisplayMenu> MenuCollection { get; set; }
        public int StoreId { get; set; }
        public MenuViewModel(Page page, string restoName, int storeId)
            : base(page)
        {
            Title = restoName;
            StoreId = storeId;
            MenuCollection = new ObservableCollection<DisplayMenu>();

            //Load List;
            this.ExecuteGetMenuCommand();
        }

        public MenuViewModel(IDevice device) : base(device)
        {
            Message = String.Format("Hello Xamarin Forms Labs MVVM Basics!! How is your {0} device", device.Manufacturer);
        }

        public MenuViewModel()
        {

        }

        private Command getMenuList;
        public Command GetMenuList
        {
            get
            {
                return getMenuList ??
                    (getMenuList = new Command(async () => await ExecuteGetMenuCommand(), () => { return !IsBusy; }));
            }
        }

        private async Task ExecuteGetMenuCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            GetMenuList.ChangeCanExecute();
            var showAlert = false;
            try
            {
                MenuCollection.Clear();
                var menulist = GetMenuItems();
                
                var dicMenuCollection = menulist
                    .GroupBy(c => c.MenuCategory)
                    .Select(c => new DisplayMenu()
                    {
                        MenuCategory = c.Key,
                        MenuList = c.Select(m => new MenuDAO()
                        {
                            ID = m.ID,
                            MenuID = m.MenuID,
                            Name = m.Name,
                            Description = m.Description,
                            MenuCategory = m.MenuCategory,
                            MenuType = m.MenuType,
                            Price = m.Price,
                            ThumbUrl = m.ThumbUrl,
                            QuantityOrdered= m.QuantityOrdered,

                        }).ToList()

                    }).ToList();

                MenuCollection = new ObservableCollection<DisplayMenu>(dicMenuCollection);
                
                //foreach (var m in menulist)
                //{
                //    //if (string.IsNullOrWhiteSpace(store.Image))
                //    //  store.Image = "http://refractored.com/images/wc_small.jpg";
                //    //MenuCollection.Add(m);
                //}

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
                GetMenuList.ChangeCanExecute();
            }

            if (showAlert)
                await page.DisplayAlert("Uh Oh :(", "Unable to gather stores.", "OK");


        }



        private void GoTo()
        {
            var navigationPage = new NavigationPage((Page)ViewFactory.CreatePage<ReserveTableViewModel, ReserveTable>());
            NavigationService.NavigateTo<ReserveTable>("");
        }

        #region properties

        private Command<object> unfocusedCommand;
        public Command<object> UnfocusedCommand
        {
            get
            {
                return this.unfocusedCommand ?? (this.unfocusedCommand = new Command<object>(
                  (param) =>
                  {
                      var paramValue = param as MenuDAO;
                      this.Message = string.Format("Unfocused raised with param {0}", param);
                  },
                  (param) =>
                  {
                      var paramValue = param as MenuDAO;
                      MenuCollectionUpdate(paramValue);
                      // CanExecute delegate
                      return true;
                  }));
            }
        }
        #endregion

        public async void MenuCollectionUpdate(MenuDAO menu)
        {
            var showAlert = false;
            var menulist = new List<MenuDAO>();
            try
            {
                AddOrderItem(menu); //Add order to menu
                menulist = GetMenuItems(); // Get new menu list;

                var dicMenuCollection = menulist
                .GroupBy(c => c.MenuCategory)
                .Select(c => new DisplayMenu()
                {
                    MenuCategory = c.Key,
                    MenuList = c.Select(m => new MenuDAO()
                    {
                        ID = m.ID,
                        MenuID = m.MenuID,
                        Name = m.Name,
                        Description = m.Description,
                        MenuCategory = m.MenuCategory,
                        MenuType = m.MenuType,
                        Price = m.Price,
                        ThumbUrl = m.ThumbUrl

                    }).ToList()

                }).ToList();

                MenuCollection = new ObservableCollection<DisplayMenu>(dicMenuCollection);
                OnPropertyChanged("MenuCollection");
            }
            catch (Exception ex)
            {
                showAlert = true;
            }

            if (showAlert)
                await page.DisplayAlert("Uh Oh :(", "Unable to update menu order.", "OK");
            
        }

        /// <summary>
        /// Return MenuItems along with the existing quantity ordered;
        /// If there is no existing order, then quantity ordered column will be zero;
        /// </summary>
        /// <returns></returns>
        public List<MenuDAO> GetMenuItems()
        {
            var menuRepo = RepositoryManager.MenuRepo();
            var odrepo = RepositoryManager.OrderDetailRepo();
            var menulist = menuRepo.GetItems();
            for (int i = 0; i < menulist.Count(); i++)
            {
                var menuId = menulist[i].MenuID;
				/*Check to exclude already placed orders c.OrderID < 1 */
				var existingOrder = odrepo.SearchFor(c => c.MenuID == menuId && c.OrderId < 1 );
                
                if (existingOrder.Any())
                    menulist[i].QuantityOrdered = existingOrder.FirstOrDefault().Quantity;
            }

            return menulist;
        }

        public void AddOrderItem(MenuDAO menu)
        {
            var odrepo = RepositoryManager.OrderDetailRepo();
            var odList = odrepo.GetItems().ToList();
            var existingOrder = odrepo.SearchFor(c => c.MenuID == menu.MenuID);
            if (existingOrder.Any())
            {
                var oditem = odrepo.GetItem(existingOrder.FirstOrDefault().ID);
                oditem.Quantity = menu.QuantityOrdered;
                oditem.TotalAmount = menu.Price * menu.QuantityOrdered;
                oditem.TaxAmount = menu.Price * menu.QuantityOrdered * 0.10m;
                if (oditem.Quantity < 1)
                    odrepo.DeleteItem(oditem);
                else
                    odrepo.SaveItem(oditem);
            }
            else if (menu.QuantityOrdered > 0)
            {
                var item = new OrderDetailDAO()
                {
                    MenuID = menu.MenuID,
                    Price = menu.Price,
                    Quantity = menu.QuantityOrdered,
                    RestaurantId = 1,
                    TotalAmount = menu.Price * menu.QuantityOrdered,
                    TaxAmount = menu.Price * menu.QuantityOrdered * 0.10m,
                };
                odrepo.SaveItem(item);
            }

            var checklist = odrepo.GetItems().ToList();
        }




    }
}
