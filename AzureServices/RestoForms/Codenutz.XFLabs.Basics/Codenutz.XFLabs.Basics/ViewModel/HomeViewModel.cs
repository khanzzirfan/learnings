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
    public class HomeViewModel:BaseViewModel
    {
        public ObservableCollection<Home> HomePage { get; set; }
        public HomeViewModel(Page page)
            : base(page)
        {
        }

        public HomeViewModel()
        {
            Title = "Reserve Table";
            HomePage = new ObservableCollection<Home>();
            this.LoadList();
            Message = "HomeModel";
        }

        private void LoadList()
        {
            var list = new List<Home>
            {
                new Home("Search For","by restaurant, city, menu","https://upload.wikimedia.org/wikipedia/commons/thumb/4/40/Capuchin_Costa_Rica.jpg/200px-Capuchin_Costa_Rica.jpg"),
                new Home("Saved Places","by restaurant, city, menu","https://upload.wikimedia.org/wikipedia/commons/thumb/4/40/Capuchin_Costa_Rica.jpg/200px-Capuchin_Costa_Rica.jpg"),
                new Home("City Favourite","by restaurant, city, menu","https://upload.wikimedia.org/wikipedia/commons/thumb/4/40/Capuchin_Costa_Rica.jpg/200px-Capuchin_Costa_Rica.jpg"),
            };
            foreach (var homepage in list)
            {
                //if (string.IsNullOrWhiteSpace(store.Image))
                //  store.Image = "http://refractored.com/images/wc_small.jpg";
                HomePage.Add(homepage);
            }
            
        }
    }
}
