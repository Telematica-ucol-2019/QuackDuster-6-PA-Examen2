using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ElectronicBanking5244.Models5244
{
    public class User5244
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string MothersLastName { get; set; }

        public string Telephone { get; set; }

        public ObservableCollection<UserAccounts5244> Accounts { get; set; }

    }

}
