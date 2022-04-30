using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicBanking5244.ViewModel5244;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ElectronicBanking5244.View5244
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountNew5244 : ContentPage
    {
        public AccountNew5244(UserAccountsViewModel5244 vm)
        {
            InitializeComponent();
            vm.Account = new Models5244.UserAccounts5244();
            vm.Account.Transactions = new System.Collections.ObjectModel.ObservableCollection<Models5244.Transactions5244>();
            BindingContext = vm;
            Title = "New account";
        }
    }
}