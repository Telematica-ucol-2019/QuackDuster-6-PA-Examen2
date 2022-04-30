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
    public partial class NewTransactions5244 : ContentPage
    {
        public NewTransactions5244(string TransactionType, Models5244.UserAccounts5244 account, UserAccountsViewModel5244 vm)
        {
            InitializeComponent();

            vm.Account = new Models5244.UserAccounts5244();
            vm.Account.Transactions = new System.Collections.ObjectModel.ObservableCollection<Models5244.Transactions5244>();
            vm.Transaction = new Models5244.Transactions5244();

            vm.Account = account;
            BindingContext = vm;

            if(TransactionType == "Deposit")
            {
                Console.WriteLine("Deposit");
                Name.Text = "Deposit Amount";
                WithdrawalBtn.IsVisible = false;
                vm.Transaction.Type = "Deposit";
            }

            if (TransactionType == "Withdrawal")
            {
                Console.WriteLine("Withdrawal");
                Name.Text = "Withdrawal Amount";
                DepositBtn.IsVisible = false;
                vm.Transaction.Type = "Withdrawal";
            }
        }
    }
}