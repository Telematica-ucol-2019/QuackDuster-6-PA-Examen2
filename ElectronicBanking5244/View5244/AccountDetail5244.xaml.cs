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
    public partial class AccountDetail : ContentPage
    {
        public AccountDetail(Models5244.UserAccounts5244 account, UserAccountsViewModel5244 vm)
        {
            InitializeComponent();
            vm.Account = new Models5244.UserAccounts5244();
            vm.Account = account;
            this.BindingContext = vm;
        }
    }
}