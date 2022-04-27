using System;
using ElectronicBanking5244.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ElectronicBanking5244
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage( new Account5244());
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
