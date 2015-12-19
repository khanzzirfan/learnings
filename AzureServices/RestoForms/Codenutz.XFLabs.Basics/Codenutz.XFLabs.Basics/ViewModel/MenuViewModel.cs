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
        public MenuViewModel(Page page, string menuName)
            : base(page)
        {
            Title = "My Restaurant";
            MenuCollection = new ObservableCollection<DisplayMenu>();

            //Load List;
            this.ExecuteGetMenuCommand();

            //OrderTakeAwayCommand = new Command(() =>
            //{
            //     Navigation.PushAsync(new Search());
            //});
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

                //var stores = await dataStore.GetStoresAsync();
                var menulist = new List<Menu>()
                {
                    new Menu ()
                {
                    Name ="Chicken Afgani",
                    Description ="Afghani Chicken is another specialty recipe of Asian cuisine.",

                    MenuCategory = "Chicken",
                    MenuType="Mains",
                    Price=15.00m,

                    ThumbUrl=c1_chicken_v1,
                },

                new Menu ()
                {
                    Name ="Chicken Kebab",
                    Description ="chicken kebab, better known as ‘tavuk şiş’ (tah-VOOK’ SHEESH’), is often served alongside grilled beef and lamb.",
                    MenuCategory = "Lamb",
                    MenuType="Mains",
                    Price=20.00m,
                    ThumbUrl=c1_chicken_v2,
                },
                new Menu ()
                {
                    Name ="Chicken Smoked Chicken Smoked",
                    Description ="Smoked Chicken",
                    MenuCategory = "Sea Food",
                    MenuType="Mains",
                    Price=15.00m,
                    ThumbUrl=c1_chicken_v3,
                },
                new Menu ()
                {
                    Name ="Butter Chicken",
                    Description ="Smoked Chicken",
                    MenuCategory = "Dessert",
                    MenuType="Mains",
                    Price=15.00m,
                    ThumbUrl=c1_chicken_v4,
                },

                new Menu ()
                {
                    Name ="Chicken Tikka",
                    Description ="Smoked Chicken",
                    MenuCategory = "Sides",
                    MenuType="Mains",
                    Price=15.00m,
                    ThumbUrl=c1_chicken_v5,
                },

                //Add Part 2 for long list testing

                 new Menu ()
                {
                    Name ="Chicken Afgani V2",
                    Description ="Afghani Chicken is another specialty recipe of Asian cuisine.",

                    MenuCategory = "Chicken",
                    MenuType="Mains",
                    Price=15.00m,

                    ThumbUrl=c1_chicken_v1,
                },

                new Menu ()
                {
                    Name ="Chicken Kebab V2",
                    Description ="chicken kebab, better known as ‘tavuk şiş’ (tah-VOOK’ SHEESH’), is often served alongside grilled beef and lamb.",
                    MenuCategory = "Chicken",
                    MenuType="Mains",
                    Price=20.00m,
                    ThumbUrl=c1_chicken_v2,
                },
                new Menu ()
                {
                    Name ="Chicken Smoked V2",
                    Description ="Smoked chicken is highly versatile in that it is cooked and ready to slice as cold meat or can be incorporated into a recipe such as our delicious “feed a crowd smoked chicken pie” and give a lovely robust smoky chicken flavour.",
                    MenuCategory = "Chicken",
                    MenuType="Mains",
                    Price=15.00m,
                    ThumbUrl=c1_chicken_v3,
                },
                new Menu ()
                {
                    Name ="Butter Chicken V2",
                    Description ="Butter Chicken is among the best known Indian foods all over the world. Its gravy can be made as hot or mild as you like so it suits most palates. Also commonly known as Murg Makhani, Butter Chicken tastes great with Kaali Daal (black lentils), Naans and a green salad.",
                    MenuCategory = "Chicken",
                    MenuType="Mains",
                    Price=15.00m,
                    ThumbUrl=c1_chicken_v4,
                },

                new Menu ()
                {
                    Name ="Chicken Tikka V2",
                    Description ="The word Tikka means bits, pieces or chunks. Chicken Tikka is an easy-to-cook dish in which chicken chunks are marinated in special spices and then grilled on skewers. This is one of India's most popular dishes. Chicken Tikka can also be made into Chicken Tikka Masala, a tasty gravy dish.",
                    MenuCategory = "Chicken",
                    MenuType="Mains",
                    Price=15.00m,
                    ThumbUrl=c1_chicken_v5,
                },


                };

                var dicMenuCollection = menulist
                    .GroupBy(c => c.MenuCategory)
                    .Select(c => new DisplayMenu()
                    {
                        MenuCategory = c.Key,
                        MenuList = c.Select(m => new Menu()
                        {
                            Name = m.Name,
                            Description = m.Description,
                            MenuCategory = m.MenuCategory,
                            MenuType = m.MenuType,
                            Price = m.Price,
                            ThumbUrl = m.ThumbUrl

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


        // ICommand implementations
        public ICommand ReserveTableCommand { protected set; get; }
        public ICommand OrderTakeAwayCommand { protected set; get; }


        private void GoTo()
        {
            var navigationPage = new NavigationPage((Page)ViewFactory.CreatePage<ReserveTableViewModel, ReserveTable>());
            NavigationService.NavigateTo<ReserveTable>("");
           

        }




    }
}
