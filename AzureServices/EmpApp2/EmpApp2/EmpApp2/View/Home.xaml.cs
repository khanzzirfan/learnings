using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace EmpApp2.View
{
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
            BtnGo.Clicked += async (sender, e) =>
             {
                 await Navigation.PushAsync(new EmployeeMainPage("505 585 456"));
             };

            ButtonAdmin.Clicked += async (sender, e) => {
                await Navigation.PushAsync(new Login());
            };
        }
    }
}
