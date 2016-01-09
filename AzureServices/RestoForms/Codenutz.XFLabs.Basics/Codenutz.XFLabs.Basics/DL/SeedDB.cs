using Codenutz.XFLabs.Basics.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codenutz.XFLabs.Basics.DL
{
    public class SeedDB
    {
        #region ConstantImageUrl
        string d1_dessert_v1 = "https://lh3.googleusercontent.com/-Xh8aY2RRwd0/VeFCHSv2lzI/AAAAAAAAAOY/8SY3a6qk7WM/d1_icecream.png";
        string d1_dessert_v2 = "https://lh3.googleusercontent.com/-5ye--N_DEBA/VbvmwbauncI/AAAAAAAAAMg/jFaE4EWANus/gv_dessertv1.jpg";

        string c1_chicken_v1 = "https://lh3.googleusercontent.com/-fZXGfuTB2UU/VeFCHZIIukI/AAAAAAAAAOo/hgxPzq3_a3c/c1_chicken_afgani.png";
        string c1_chicken_v2 = "https://lh3.googleusercontent.com/-nyuWEiI0BQA/Vb0ilfsVLAI/AAAAAAAAANU/3ElmooO5tdo/gchickenkebab_highres.jpg";
        string c1_chicken_v3 = "https://lh3.googleusercontent.com/-ReuUjC4E6o0/VeFCHdGMYnI/AAAAAAAAAO4/BZB_1NVlEGk/c1_smoke_chicken.png";
        string c1_chicken_v4 = "https://lh3.googleusercontent.com/-cZdvAxn0EyA/VeFCHTm_nQI/AAAAAAAAAOM/UCVCzmAh8Fk/c1_butter_chicken.jpg";
        string c1_chicken_v5 = "https://lh3.googleusercontent.com/-n_v-LXlsC6E/VbvmwT8wk8I/AAAAAAAAAL8/rRlK651PHI8/gv_ctikkav1.jpg";

        string k1_kebab_v1 = "https://lh3.googleusercontent.com/-YPQi3-4I2aY/VeFCHe7dMrI/AAAAAAAAAOM/1wa21O3L2mk/k1_seek_kebab.png";
        string k1_kebab_v2 = "https://lh3.googleusercontent.com/-1qVD5HMsCIU/VbvmwbAgdgI/AAAAAAAAAJ0/f2YLHJGJMZg/gv_Tkebab.jpg";
        

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

        string d_cafe = "https://lh3.googleusercontent.com/-vm6b72KATAk/VpBxkcoHwFI/AAAAAAAAAyc/ZE24_S9jepg/s72/d_coffee5.png";
        string d_restaurant = "https://lh3.googleusercontent.com/-uXX25lkjlRM/VpBj6U7gwtI/AAAAAAAAAxY/zQC34htSe6s/s72/pennepastatomato.png";
        string d_takeaway = "https://lh3.googleusercontent.com/-VNRSCEwRUxY/VpB9UwWFF5I/AAAAAAAAAzY/CRkA9ek9Adg/s72/dtakeaway.png";
        string d_reservation = "https://lh3.googleusercontent.com/-RkNxXlksW24/VpB_OYcokoI/AAAAAAAAAz0/--Q5sTWpxsQ/s72/dclock.png";
        string d_cityfav = "https://lh3.googleusercontent.com/-pS5AlKfUoWo/VpB_fBmErUI/AAAAAAAAAz8/jACkmww6bok/s72/dcity.jpg";

        string r_allegiopizza = "https://lh3.googleusercontent.com/-wPdOpoq1ww8/VpF2wgHfQNI/AAAAAAAAA4E/d4GT0SAs0tk/s72/r_pizzaresto3.png";
        string r_cassia = "https://lh3.googleusercontent.com/-cFaqHxud7Ds/VpFqgAsMGLI/AAAAAAAAA1M/IV0z4N-kIjw/s72/IndianResto2.jpg";
        string r_orbit = "https://lh3.googleusercontent.com/-pS5AlKfUoWo/VpB_fBmErUI/AAAAAAAAA0E/YXBvW8kwGgU/s72/dcity.jpg";
        string r_baduzi = "https://lh3.googleusercontent.com/-P4DPkX-SwlA/VpFqgHt0JDI/AAAAAAAAA1M/kBfQAzIdvNc/s72/Badzui.png";
        string r_cocasden = "https://lh3.googleusercontent.com/-_CntJZdkaY8/VpFsOM0tO4I/AAAAAAAAA2E/2d7KrfM6PX4/s72/cafeHanoi.jpg";

        #endregion

        public SeedDB()
        {

        }

        public List<RestaurantsDAO> RestaurantObjectList()
        {
            var list = new List<RestaurantsDAO>()
            {
                new RestaurantsDAO() { Title="Allegio Pizza", Address="7 Quay Street", City="Auckland", Image=r_allegiopizza },
                new RestaurantsDAO() { Title="Cooco's Den", Address="120 Langstrasse", City="Auckland", Image=r_cocasden },
                new RestaurantsDAO() { Title="Orbit 360", Address="72/78 Victoria St", City="Auckland", Image=r_orbit },
                new RestaurantsDAO() { Title="Baduzzi", Address="0-26 Fish Lane", City="Auckland", Image=r_baduzi },
                new RestaurantsDAO() { Title="Cassia", Address="5 Fort Ln", City="Auckland", Image=r_cassia }
            };

            return list;
        }

        public List<HomeDAO> HomeObjectsList()
        {
            var list = new List<HomeDAO>
            {
                new HomeDAO() { SearchBy ="Restaurants",  SearchByDescription = "by restaurant, city, menu", Image= d_restaurant },
                new HomeDAO(){ SearchBy ="Cafes", SearchByDescription = "by restaurant, city, menu", Image= d_cafe },
                new HomeDAO(){ SearchBy ="Takeout/delivery", SearchByDescription = "by restaurant, city, menu", Image= d_takeaway},
                new HomeDAO(){ SearchBy ="Bars", SearchByDescription = "by restaurant, city, menu", Image= k1_spring_rolls},
                new HomeDAO(){ SearchBy ="Reservations", SearchByDescription = "by restaurant, city, menu", Image= d_reservation},
                new HomeDAO(){ SearchBy ="Deals", SearchByDescription = "by restaurant, city, menu", Image= k1_prawn},
                new HomeDAO(){ SearchBy ="City favourite", SearchByDescription = "by restaurant, city, menu", Image= d_cityfav},

            };
            return list;
        }


        

    }
}
