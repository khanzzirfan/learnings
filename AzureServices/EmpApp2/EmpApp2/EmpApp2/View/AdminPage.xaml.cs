using EmpApp2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace EmpApp2.View
{
    public partial class AdminPage : ContentPage
    {
        AdminViewModel viewModel;
        public AdminPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new AdminViewModel(this);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (viewModel.AdminData.Count > 0 || viewModel.IsBusy)
                return;

            viewModel.GetAdminData.Execute(null);
        }

        public void OnItemSelected(object sender, ItemTappedEventArgs args)
        {
            var emp = args.Item as Model.AdminModel;
            if (emp == null)
                return;
            // Reset the selected item
            list.SelectedItem = null;
            Navigation.PushAsync(new EmployeeMainPage(emp.Phone));
            
        }
    }
}
