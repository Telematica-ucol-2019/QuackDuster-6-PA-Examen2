using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ElectronicBanking5244.Models5244
{
    public class Transactions5244
    {
        public int Id { get; set; }

        public int Amount { get; set; }

        public string Date { get; set; }

        public string Hour { get; set; }

        public string Type { get; set; }
    }
}
