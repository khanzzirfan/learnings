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
    public partial class ReserveTable : ContentPage
    {
        private ReserveTableViewModel viewModel;
        public ReserveTable(string restoName)
        {
            InitializeComponent();
            BindingContext = viewModel = new ReserveTableViewModel(this,restoName);
        }
    }
}
