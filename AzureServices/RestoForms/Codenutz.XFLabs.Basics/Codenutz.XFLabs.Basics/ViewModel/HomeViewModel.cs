using Codenutz.XFLabs.Basics.DAL;
using Codenutz.XFLabs.Basics.DL;
using Codenutz.XFLabs.Basics.Manager;
using Codenutz.XFLabs.Basics.Model;
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
    public class HomeViewModel:BaseViewModel
    {

        public ObservableCollection<HomeDAO> HomePage { get; set; }
        public HomeViewModel(Page page)
            : base(page)
        {
            Title = "Reserve Table";
            HomePage = new ObservableCollection<HomeDAO>();
            this.LoadList();
            Message = "HomeModel";
            
        }

        public HomeViewModel(IDevice device):base(device)
        {
            Title = "Reserve Table";
            HomePage = new ObservableCollection<HomeDAO>();
            this.LoadList();
            Message = "HomeModel";
            

        }

        public HomeViewModel()
        {
            Title = "Reserve Table";
            HomePage = new ObservableCollection<HomeDAO>();
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

            var homeRepo = RepositoryManager.HomeRepo();
            var homeLIst = homeRepo.GetItems();

            foreach (var homepage in homeLIst)
            {
                //if (string.IsNullOrWhiteSpace(store.Image))
                //  store.Image = "http://refractored.com/images/wc_small.jpg";
                HomePage.Add(homepage);
            }
            
        }
    }
}
