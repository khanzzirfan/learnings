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

        /// <summary>
        /// Call the repo manager to load the Home Page Data
        /// </summary>
        private void LoadList()
        {
            var homeRepo = RepositoryManager.HomeRepo();
            var homeList = homeRepo.GetItems();

            foreach (var homepage in homeList)
            {
                HomePage.Add(homepage);
            }
        }
    }
}
