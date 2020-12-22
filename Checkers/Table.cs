using System;
using System.Collections.Generic;
using System.Text;

namespace Checkers
{
    class Table
    {
        public static void TableC(string[,] Deck, int X, int Y, int x = 8)
        {
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.Black;
            for (int i = 1; i < x + 1; i++)
            {
                Deck[i, 0] = $" {i} ";
            }
            Console.Write(Deck[X, Y]);
            Console.ResetColor();
        }

        public static void TableR(string[,] Deck, int x = 8)
        {
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.Black;
            Deck[0, 0] = " ";
            Deck[0, 1] = "a";
            Deck[0, 2] = "b";
            Deck[0, 3] = "c";
            Deck[0, 4] = "d";
            Deck[0, 5] = "e";
            Deck[0, 6] = "f";
            Deck[0, 7] = "g";
            Deck[0, 8] = "h";

            for (int i = 0; i < x + 1; i++)
            {
                Console.Write($" {Deck[0, i]} ");
            }

            Console.ResetColor();
        }
    }
}
