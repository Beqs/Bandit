using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bandit
{
    class Wallet
    {
        static private double total = 0;
        static private double addToTotal = 0;
        public double AddMoney(double money, double total)
        {
            total = money + total;
            return total;
        }

        public double CheckMoney()
        {
            return total;
        }

        public double Total { get => total; set => total = value; }
        public double AddToTotal { get => addToTotal; set => addToTotal = value; }
    }
}
