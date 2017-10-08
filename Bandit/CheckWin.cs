using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bandit
{
    class CheckWin
    {
        Wallet w1 = new Wallet();
        private double _wallet;
        private double _bet;
        private string _WinSymbol;
        public double Wallet { get => _wallet; set => _wallet = value; }
        public string WinSymbol { get => _WinSymbol; set => _WinSymbol = value; }
        public double Bet { get => _bet; set => _bet = value; }

        public double WinMulti(string win)
        {
            
            switch (win)
            {

                case "9":
                    {
                        w1.Total += Bet * 1.5;
                        return w1.Total;
                    }
                case "10":
                    {
                        w1.Total += Bet * 2;
                        return w1.Total;
                    }
                case "J":
                    {
                        w1.Total += Bet * 2.5;
                        return w1.Total;
                    }
                case "Q":
                    {
                        w1.Total += +Bet * 5;
                        return w1.Total;
                    }
                case "K":
                    {
                        w1.Total += Bet * 10;
                        return w1.Total;
                    }
                case "D":
                    {
                        w1.Total += Bet * 50;
                        return w1.Total;
                    }
            }
            return w1.Total;
        }

        public bool Win(string a, string b, string c)
        {
            if (a == b && b == c)
            {
                WinSymbol = a;
                return true;
            }

            else
                return false;
        }

        public bool CheckLoss(double total)
        {
            if (total > 0)
                return true;
            else
                return false;
        }
    }
}
