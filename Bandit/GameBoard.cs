using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bandit
{
    class GameBoard
    {

        // int[,] Board = new int[9, 2] { {0,0}, {0,1}, {0,2}, {1,0}, {1,1}, {1,2}, {2,0}, {2,1}, {2,2}};
        static string[] Symbols = new string[100];
        Random Dice = new Random();

        int[,] Board = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        public static void GenerateSymbols()
        {
            for (int a = 0; a < 29; a++)
            {
                Symbols[a] = "9";
            }

            for (int b = 30; b < 54; b++)
            {
                Symbols[b] = "10";
            }

            for (int c = 55; c < 74; c++)
            {
                Symbols[c] = "J";
            }
            for (int d = 75; d < 89; d++)
            {
                Symbols[d] = "Q";
            }
            for (int e = 90; e < 97; e++)
            {
                Symbols[e] = "K";
            }
            for (int f = 98; f < 99; f++)
            {
                Symbols[f] = "D";
            }
        }

        public void AddToGameBoard(int a, int b, int c, int d, int e, int f, int g, int h, int i)
        {
            do
            {
                a = Dice.Next(0, 99);
                b = Dice.Next(0, 99);
                c = Dice.Next(0, 99);
                d = Dice.Next(0, 99);
                e = Dice.Next(0, 99);
                f = Dice.Next(0, 99);
                g = Dice.Next(0, 99);
                h = Dice.Next(0, 99);
                i = Dice.Next(0, 99);

                Board[0, 0] = a;
                Board[0, 1] = b;
                Board[0, 2] = c;
                Board[1, 0] = d;
                Board[1, 1] = e;
                Board[1, 2] = f;
                Board[2, 0] = g;
                Board[2, 1] = h;
                Board[2, 2] = i;
            } while (a != b && b != c && c!=d && d != e && e != f && f != g && g != h && h != i);
        }

        public static string ConvertToSymbol(int a)
        {
            if (a > 98)
                return "D";
            else if (a > 90)
                return "K";
            else if (a > 75)
                return "Q";
            else if (a > 55)
                return "J";
            else if (a > 30)
                return "10";
            else
                return "9";

        }
    }
}
