using ElectronicBanking5244.Models5244;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Text.RegularExpressions;

namespace ElectronicBanking5244.ViewModel5244
{
    public class UserAccountsViewModel5244 : BaseViewModel5244
    {
        public ObservableCollection<UserAccounts5244> AccountsList { get; set; }

        private Transactions5244 transaction;
        public Transactions5244 Transaction
        {
            get { return transaction; }
            set { transaction = value; OnPropertyChanged(); }
        }

        private UserAccounts5244 account;
        public UserAccounts5244 Account
        {
            get { return account; }
            set { account = value; OnPropertyChanged(); }
        }

        private User5244 user;
        public User5244 User
        {
            get { return user; }
            set { user = value; OnPropertyChanged(); }
        }

        #region Attributes
        private string name;
        private string lastname;
        private string motherslastname;
        private string telephone;
        private string balance;
        #endregion

        #region Properties
        public string inpName
        {
            get { return this.name; }
            set { SetValue(ref this.name, value); }
        }

        public string inpLastName
        {
            get { return this.lastname; }
            set { SetValue(ref this.lastname, value); }
        }

        public string inpMothersLastName
        {
            get { return this.motherslastname; }
            set { SetValue(ref this.motherslastname, value); }
        }

        public string inpTelephone
        {
            get { return this.telephone; }
            set { SetValue(ref this.telephone, value); }
        }

        public string inpBalance
        {
            get { return this.balance; }
            set { SetValue(ref this.balance, value); }
        }
        #endregion

        public ICommand cmdAccDetailBtn { get; set; }
        public ICommand cmdNewAccountBtn { get; set; }
        public ICommand cmdCreateNewAccount { get; set; }
        public ICommand cmdMakeDeposit { get; set; }
        public ICommand cmdMakeWithDrawal { get; set; }
        public ICommand cmdAddDeposit { get; set; }
        public ICommand cmdAddWithdrawal { get; set; }
        public ICommand cmdBtnDeleteAccount { get; set; }
        public ICommand cmdBtnRegisterUser { get; set; }
        public ICommand cmdInpName { get; set; }
        public ICommand cmdBtnEditUser { get; set; }


        public ICommand cmdInpNameValidate { get; set; }
        public ICommand cmdInpLastNameValidate { get; set; }
        public ICommand cmdInpMothersLastNameValidate  { get; set; }
        public ICommand cmdInpTelephone { get; set; }
        public ICommand cmdInpBalanceValidate { get; set; }




        public UserAccountsViewModel5244()
        {
            User5244 User = new User5244() 
            {
                Name = "Carlos",
                LastName = "Mendez",
                MothersLastName = "Martinez",
                Telephone = "312223211",
                Accounts = new ObservableCollection<UserAccounts5244>()
                {
                    new UserAccounts5244 {
                        Name = "Debito Visa",
                        Number= new Random().Next(100000000, 999999999),
                        Balance = 2000,
                        Transactions = new ObservableCollection<Transactions5244>(){ 
                            new Transactions5244 {Type="Deposit", Id=1, Amount=200, Date ="10/02/2022", Hour="11:00" },
                            new Transactions5244 {Type="Withdrawal", Id=2, Amount=10, Date ="06/02/2022", Hour="13:00" },
                            new Transactions5244 {Type="Deposit", Id=3, Amount=100, Date ="07/02/2022", Hour="12:00" },
                            new Transactions5244 {Type="Withdrawal", Id=4, Amount=40, Date ="12/02/2022", Hour="19:00" }
                        } },
                    new UserAccounts5244 {
                        Name = "Debito MasterCard",
                        Number= new Random().Next(100000000, 999999999),
                        Balance = 0,
                        Transactions = new ObservableCollection<Transactions5244>(){ new Transactions5244 { Type = "Deposit", Id =100, Amount=1000, Date ="10/02/2022", Hour="12:00" } } },
                    new UserAccounts5244 {
                        Name = "Debito AmericanExpress",
                        Number= new Random().Next(100000000, 999999999),
                        Balance = 2731,
                        Transactions = new ObservableCollection<Transactions5244>(){ new Transactions5244 { Type = "Withdrawal", Id =100, Amount=1000, Date ="10/02/2022", Hour="12:00" } } }

                }
            };
            AccountsList = User.Accounts;


            cmdAccDetailBtn = new Command<UserAccounts5244>(async (x) => await PCmdAccountDetail(x));
            cmdNewAccountBtn = new Command(async () => await PCmdNewAccount());
            cmdCreateNewAccount = new Command<UserAccounts5244>(async (x) => await PCmdAddNewAccount(x));
            cmdMakeDeposit = new Command(async () => await PCmdNewDeposit());
            cmdMakeWithDrawal = new Command(async () => await PCmdNewWithdrawal());
            cmdAddDeposit = new Command<Transactions5244>(async (x) => await PCmdMakeDeposit(x));
            cmdAddWithdrawal = new Command<Transactions5244>(async (x) => await PCmdMakeWithdrawal(x));
            cmdBtnDeleteAccount = new Command<UserAccounts5244>(async (x) => await PCmdDelAccountBtn(x));
            cmdBtnEditUser = new Command(async () => await PCmdUpdateUserPage());

            cmdInpNameValidate = new Command(async () => await PCmdRegNameValidate());
            cmdInpLastNameValidate = new Command(async () => await PCmdRegLastNameValidate());
            cmdInpMothersLastNameValidate = new Command(async () => await PCmdRegMothersLastNameValidate());
            cmdInpTelephone = new Command(async () => await PCmdRegTelephoneValidate());
            cmdBtnRegisterUser = new Command(async () => await PCmdRegBtnValidate());
            cmdInpBalanceValidate = new Command(async () => await PCmdCreateAccAmountValidation());

            //Test
            async Task PCmdRegNameValidate()
            {
                if(inpName.Length > 0)
                {
                    string lastCharacter = inpName[inpName.Length - 1].ToString();
                    if (!Regex.IsMatch(lastCharacter, @"^[a-zA-Z ]+$"))
                    {
                        inpName = inpName.Substring(0, inpName.Length - 1);
                    }
                }
            }

            async Task PCmdRegLastNameValidate()
            {
                if (inpLastName.Length > 0)
                {
                    string lastCharacter = inpLastName[inpLastName.Length - 1].ToString();
                    if (!Regex.IsMatch(lastCharacter, @"^[a-zA-Z ]+$"))
                    {
                        inpLastName = inpLastName.Substring(0, inpLastName.Length - 1);
                    }
                }
            }

            async Task PCmdRegMothersLastNameValidate()
            {
                if (inpMothersLastName.Length > 0)
                {
                    string lastCharacter = inpMothersLastName[inpMothersLastName.Length - 1].ToString();
                    if (!Regex.IsMatch(lastCharacter, @"^[a-zA-Z ]+$"))
                    {
                        inpMothersLastName = inpMothersLastName.Substring(0, inpMothersLastName.Length - 1);
                    }
                }
            }

            async Task PCmdRegTelephoneValidate()
            {
                Console.WriteLine(inpTelephone.Length);
                if (inpTelephone.Length > 0)
                {
                    if (inpTelephone.Length <= 10)
                    {
                        string lastCharacter = inpTelephone[inpTelephone.Length - 1].ToString();
                        if (!Regex.IsMatch(lastCharacter, @"^[0-9]+$"))
                        {
                            inpTelephone = inpTelephone.Substring(0, inpTelephone.Length - 1);
                        }
                    }
                    else
                    {
                        inpTelephone = inpTelephone.Substring(0, 10);
                    }
                }

            }

            async Task PCmdRegBtnValidate()
            {
                if (inpName?.Length > 0 && inpLastName?.Length > 0 && inpMothersLastName?.Length > 0 && inpTelephone?.Length > 0)
                {
                    if(inpTelephone.Length >= 8)
                    {
                        User5244 user = new User5244()
                        {
                            Name = inpName,
                            LastName = inpLastName,
                            MothersLastName = inpMothersLastName,
                            Telephone = inpTelephone,
                            Accounts = new ObservableCollection<UserAccounts5244>()
                        };
                        await Application.Current.MainPage.DisplayAlert("Done!", "You have been registered succesfully", "Ok");
                        Application.Current.MainPage = new NavigationPage(new View5244.UserPage5244(user, this));
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Invalid!", "The phone number must contain between 8-10 digits", "Ok");
                    }
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Missing information", "Please fill all the form", "Ok");
                }
            }

            async Task PCmdCreateAccAmountValidation()
            {
                if (!inpBalance.StartsWith("0"))
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new View5244.AccountNew5244(this));
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("You must add founds", "You can't make accounts without any balance", "Ok");
                }
            }

            //Good
            async Task PCmdUpdateUserPage()
            {
                await Application.Current.MainPage.Navigation.PushAsync(new View5244.EditUserData5244(this));
            }

            async Task PCmdAccountDetail(Models5244.UserAccounts5244 _Account)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new View5244.AccountDetail(_Account, this));
                
            }

            async Task PCmdNewAccount()
            {
                await Application.Current.MainPage.Navigation.PushAsync(new View5244.AccountNew5244(this));

            }

            async Task PCmdAddNewAccount(Models5244.UserAccounts5244 _Account)
            {
                _Account.Number = new Random().Next(10000000, 999999999);
                User.Accounts.Add(_Account);
                AccountsList = User.Accounts;

                await Application.Current.MainPage.Navigation.PopAsync();
            }

            async Task PCmdNewDeposit()
            {
                await Application.Current.MainPage.Navigation.PushAsync(new View5244.NewTransactions5244("Deposit", Account, this));
            }

            async Task PCmdNewWithdrawal()
            {
                await Application.Current.MainPage.Navigation.PushAsync(new View5244.NewTransactions5244("Withdrawal", Account, this));
            }

            async Task PCmdMakeDeposit(Models5244.Transactions5244 _transactions)
            {
                DateTime actualDate = DateTime.Now;
                _transactions.Date = actualDate.ToString("d");
                _transactions.Hour = actualDate.ToString("t");

                if(Account.Transactions == null)
                {
                    Account.Transactions = new ObservableCollection<Transactions5244>();
                }

                var pointer = -1;
                UserAccounts5244 mpm = User.Accounts.FirstOrDefault(x => x.Number == Account.Number);
                if(mpm != null)
                {
                    _transactions.Id = new Random().Next(10000, 99999);
                    Account.Transactions.Add(_transactions);
                    Account.Balance += _transactions.Amount;
                    pointer = User.Accounts.IndexOf(mpm);
                    User.Accounts[pointer] = Account;
                }
                OnPropertyChanged();

                await Application.Current.MainPage.Navigation.PopAsync();
                await Application.Current.MainPage.Navigation.PopAsync();
            }

            async Task PCmdMakeWithdrawal(Models5244.Transactions5244 _transactions)
            {
                DateTime actualDate = DateTime.Now;
                _transactions.Date = actualDate.ToString("d");
                _transactions.Hour = actualDate.ToString("t");

                if (Account.Transactions == null)
                {
                    Account.Transactions = new ObservableCollection<Transactions5244>();
                }

                var pointer = -1;
                UserAccounts5244 mpm = User.Accounts.FirstOrDefault(x => x.Number == Account.Number);
                if (mpm != null)
                {
                    _transactions.Id = new Random().Next(100, 999);
                    Account.Transactions.Add(_transactions);
                    if (Account.Balance > 0 && Account.Balance != 0)
                    {
                        if (_transactions.Amount <= Account.Balance)
                        {
                            Account.Balance -= _transactions.Amount;
                            pointer = User.Accounts.IndexOf(mpm);
                            User.Accounts[pointer] = Account;
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("You can't make that withdraw!", "Exceeds the balance of the account", "Ok");
                        }
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("You can't make that withdraw", "You are out of balance", "Ok");
                    }
                    
                }
                OnPropertyChanged();

                await Application.Current.MainPage.Navigation.PopAsync();
                await Application.Current.MainPage.Navigation.PopAsync();
            }

            async Task PCmdDelAccountBtn(Models5244.UserAccounts5244 _account)
            {
                if (_account.Balance == 0)
                {
                    User.Accounts.Remove(_account);
                    await Application.Current.MainPage.Navigation.PopAsync();
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Balance in the account", "You can't delete an account with balance, try to empty the account first", "Ok");
                }
            }





        }

        
    }

}
