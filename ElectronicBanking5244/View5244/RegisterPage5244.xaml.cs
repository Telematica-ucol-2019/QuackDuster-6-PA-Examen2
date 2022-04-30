using ElectronicBanking5244.ViewModel5244;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ElectronicBanking5244.View5244
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage5244 : ContentPage
    {
        public RegisterPage5244()
        {
            InitializeComponent();
            BindingContext = new UserAccountsViewModel5244();
        }
    }
}