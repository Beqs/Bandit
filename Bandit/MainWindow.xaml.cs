using System;
using System.Windows;
using System.Windows.Controls;

namespace Bandit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///

    public partial class MainWindow : Window
    {
        private static Random TestDice = new Random();
        private string[] Symbols = new string[100];
        private Person p1 = new Person();
        private Wallet w1 = new Wallet();
        private GameBoard g1 = new GameBoard();
        private CheckWin c1 = new CheckWin();
        private Random Dice = new Random();

        public MainWindow()
        {
            GameBoard.GenerateSymbols();
            InitializeComponent();
            SpinButton.IsEnabled = false;
            BetButton.IsEnabled = false;
            AddMoneyButton.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int aVar = TestDice.Next(0, 99);
            int bVar = TestDice.Next(0, 99);
            int cVar = TestDice.Next(0, 99);
            int dVar = TestDice.Next(0, 99);
            int eVar = TestDice.Next(0, 99);
            int fVar = TestDice.Next(0, 99);
            int gVar = TestDice.Next(0, 99);
            int hVar = TestDice.Next(0, 99);
            int iVar = TestDice.Next(0, 99);
            int[,] Board = new int[3, 3] { { aVar, bVar, cVar }, { dVar, eVar, fVar }, { gVar, hVar, iVar } };

            g1.AddToGameBoard(aVar, bVar, cVar, dVar, eVar, fVar, gVar, hVar, iVar);

            string tmp1 = GameBoard.ConvertToSymbol(aVar);          //Konverterar randomtal till symboler från min array och placerar ut de
            string tmp2 = GameBoard.ConvertToSymbol(bVar);
            string tmp3 = GameBoard.ConvertToSymbol(cVar);
            string tmp4 = GameBoard.ConvertToSymbol(dVar);
            string tmp5 = GameBoard.ConvertToSymbol(eVar);
            string tmp6 = GameBoard.ConvertToSymbol(fVar);
            string tmp7 = GameBoard.ConvertToSymbol(gVar);
            string tmp8 = GameBoard.ConvertToSymbol(hVar);
            string tmp9 = GameBoard.ConvertToSymbol(iVar);
            Label1.Content = tmp1;
            Label2.Content = tmp2;
            Label3.Content = tmp3;
            Label4.Content = tmp4;
            Label5.Content = tmp5;
            Label6.Content = tmp6;
            Label7.Content = tmp7;
            Label8.Content = tmp8;
            Label9.Content = tmp9;

            if (c1.Win(tmp1, tmp2, tmp3) == true)
            {
                w1.Total += c1.WinMulti(tmp1);
            }

            if (c1.Win(tmp4, tmp5, tmp6) == true)
            {
                w1.Total += c1.WinMulti(tmp4);
            }

            if (c1.Win(tmp7, tmp8, tmp9) == true)          //Wincheckers
            {
                w1.Total += c1.WinMulti(tmp7);
            }

            if (c1.Win(tmp1, tmp4, tmp7) == true)
            {
                w1.Total += c1.WinMulti(tmp1);
            }

            if (c1.Win(tmp2, tmp5, tmp8) == true)
            {
                w1.Total += c1.WinMulti(tmp2);
            }

            if (c1.Win(tmp3, tmp6, tmp9) == true)
            {
                w1.Total += c1.WinMulti(tmp3);
            }

            if (c1.Win(tmp1, tmp2, tmp3) == true)
            {
                w1.Total += c1.WinMulti(tmp1);
            }

            if (c1.Win(tmp1, tmp5, tmp9) == true)
            {
                w1.Total += c1.WinMulti(tmp1);
            }

            if (c1.Win(tmp3, tmp5, tmp7) == true)
            {
                w1.Total += c1.WinMulti(tmp3);
            }

            WalletLabel.Content = w1.Total;
            InputBet.IsReadOnly = false;
            AddMoney.IsReadOnly = false;
            SpinButton.IsEnabled = false;
            AddMoneyButton.IsEnabled = true;
            BetButton.IsEnabled = true;
        }

        private void AddMoney_TextChanged(object sender, TextChangedEventArgs e)
        {
            double n = 0;
            w1.AddToTotal = double.TryParse(AddMoney.Text, out n) ? n : 0;    //Sparar värdet som sen adderas till total
        }

        private void AddMoneyButton_Click(object sender, RoutedEventArgs e)
        {
            w1.Total = w1.AddMoney(w1.Total, w1.AddToTotal);    //Adderar det sparade värdet till total
            WalletLabel.Content = w1.Total;
            AddMoney.IsReadOnly = true;
            AddMoneyButton.IsEnabled = false;
            AddMoney.Text = null;
        }

        private void BetButton_Click(object sender, RoutedEventArgs e)
        {
            LabelBet.Content = c1.Bet;
            if (w1.Total - c1.Bet >= 0)                    //Hindrar spelaren från att gå under 0
            {
                w1.Total = w1.Total - c1.Bet;
                InputBet.IsReadOnly = true;
                SpinButton.IsEnabled = true;
                BetButton.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Add more money.");
                AddMoneyButton.IsEnabled = true;
                AddMoney.IsReadOnly = false;
            }
            InputBet.Text = null;
        }

        private void InputBet_TextChanged(object sender, TextChangedEventArgs e)
        {
            double n = 0;
            c1.Bet = double.TryParse(InputBet.Text, out n) ? n : 0;         //Bet input
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (p1.VerifyAge(p1.Age) == true)             //Sparar namn och ser till att ingen under 18 kan spela. Låser spelet för de yngre.
            {
                AddMoneyButton.IsEnabled = true;
                BetButton.IsEnabled = true;
                WelcomeLabel.Content = ("Welcome: ") + p1.Name;
            }
            else
            {
                MessageBox.Show("Invalid age, please close the application");
            }
            SubmitButton.IsEnabled = false;
            TextBoxName.IsReadOnly = true;
            TextBoxAge.IsReadOnly = true;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string name = Convert.ToString(TextBoxName.Text);
            p1.Name = name;
        }

        private void TextBoxAge_TextChanged(object sender, TextChangedEventArgs e)
        {
            int n = 0;
            p1.Age = int.TryParse(TextBoxAge.Text, out n) ? n : 0;
        }
    }
}