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

        public ObservableCollection<Phone> Telephone { get; set; }

        public ObservableCollection<Accounts> Accounts { get; set; }
    }

    public class Phone
    {
        public string Id { get; set; }

        public string Number { get; set; }
    }

    public class Accounts
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }

}
