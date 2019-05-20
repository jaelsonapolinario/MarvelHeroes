using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MarvelHeroes.View;

namespace MarvelHeroes
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage())
            {
                BarTextColor = Color.White,
                BarBackgroundColor = Color.FromHex("#e62429")
            };
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
