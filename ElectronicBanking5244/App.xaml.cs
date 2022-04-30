using System;
using ElectronicBanking5244.View5244;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ElectronicBanking5244.ViewModel5244;

namespace ElectronicBanking5244
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new RegisterPage5244());
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
