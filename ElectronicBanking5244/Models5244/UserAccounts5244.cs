using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ElectronicBanking5244.Models5244
{
    public class UserAccounts5244
    {
        public string Name { get; set; }

        public int Number { get; set; }

        public int Balance { get; set; }

        public ObservableCollection<Transactions5244> Transactions { get; set; }
    }

}


