using Codenutz.XFLabs.Basics.DAL;
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
    public partial class MenuItemDetailPage : ContentPage
    {
        MenuItemDetailVM viewModel;
        public MenuItemDetailPage(string storeName, MenuDAO menu)
        {
            InitializeComponent();
            BindingContext = viewModel = new MenuItemDetailVM(this, storeName, menu);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }


    }
}
