using EmpApp2.View;
using EmpApp2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;

namespace EmpApp2
{
    public class App : Application
    {
        public App()
        {
            RegisterViews();
            MainPage = new NavigationPage((Page)ViewFactory.CreatePage<HomeViewModel, Home>());
        }

        private void RegisterViews()
        {
            ViewFactory.Register<MainView, MainViewModel>();
            ViewFactory.Register<Home, HomeViewModel>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
