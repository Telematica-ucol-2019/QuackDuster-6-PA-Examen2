using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicBanking5244.ViewModel5244;
using ElectronicBanking5244.Models5244;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ElectronicBanking5244.View5244
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditUserData5244 : ContentPage
    {
        public EditUserData5244(UserAccountsViewModel5244 vm)
        {
            InitializeComponent();
            vm.User = new Models5244.User5244();
            BindingContext = vm;
        }
    }
}