using BlankApplying.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlankApplying.Pages;

using Xamarin.Forms;

namespace BlankApplying
{
    public class App : Application
    {
        public App()
        {
            MainPage = new NavigationPage(new RegistrationPage())
            {
                BarBackgroundColor = Color.Gray,
                BarTextColor = Color.White,
                Title = "BlankApplying app"
            };
            User user = new User();
           
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
