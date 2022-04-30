﻿using ElectronicBanking5244.ViewModel5244;
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
    public partial class UserPage5244 : ContentPage
    {
        public UserPage5244(Models5244.User5244 user, UserAccountsViewModel5244 vm)
        {
            InitializeComponent();
            vm.User = new Models5244.User5244();
            vm.User = user;
            this.BindingContext = vm;
        }
    }
}