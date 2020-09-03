using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new ContactsPage())
            //{
            //    BarBackgroundColor = Color.Chocolate,
            //    BarTextColor = Color.White
            //};

            MainPage = new NavigationPage(new SwitchPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
