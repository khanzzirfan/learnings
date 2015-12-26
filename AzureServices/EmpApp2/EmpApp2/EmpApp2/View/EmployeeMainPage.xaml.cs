using EmpApp2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace EmpApp2.View
{
    public partial class EmployeeMainPage : ContentPage
    {
        public EmployeeMainViewModel viewModel;
        
        public EmployeeMainPage(string phone)
        {
            InitializeComponent();
            BindingContext = viewModel = new EmployeeMainViewModel(this, phone);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (viewModel.EmpDetails!=null || viewModel.IsBusy)
                return;

            //viewModel.GetEmployeesCommand.Execute(null);
        }

        public async void OnItemSelected(object sender, ItemTappedEventArgs args)
        {
            list.SelectedItem = null;
        }

    }
}
