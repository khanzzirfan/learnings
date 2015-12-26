using EmpApp2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace EmpApp2.View
{
    public partial class Login : ContentPage
    {
        public LoginViewModel viewModel;
        public Login()
        {
            InitializeComponent();
            BindingContext=viewModel= new LoginViewModel(this);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            string platformName = Device.OS.ToString();
            Content.FindByName<Button>("loginButton" + platformName).Clicked += OnLoginClicked;
            Content.FindByName<Button>("helpButton" + platformName).Clicked += OnHelpClicked;
        }

        private void OnLoginClicked(object sender, EventArgs e)
        {
            string platformName = Device.OS.ToString();
            Content.FindByName<Button>("loginButton" + platformName).Clicked -= OnLoginClicked;
            Content.FindByName<Button>("helpButton" + platformName).Clicked -= OnHelpClicked;
            Navigation.PushAsync(new AdminPage());

            //if (viewModel.CanLogin)
            //{
            //    viewModel
            //    .LoginAsync(System.Threading.CancellationToken.None)
            //    .ContinueWith(_ => {
            //        App.LastUseTime = System.DateTime.UtcNow;
            //        Navigation.PopModalAsync();
            //    });

            //    Navigation.PopModalAsync();
            //}
            //else
            //{
            //    DisplayAlert("Error", viewModel.ValidationErrors, "OK", null);
            //}
        }

        private async void OnHelpClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Help", "Enter any username and password", "OK");
            //await page.DisplayAlert("Uh Oh :(", "Unable to gather stores.", "OK");
            //DisplayAlert("Help", "Enter any username and password", "OK", null);
        }
    }
}
