using System;
using System.Collections.Generic;
using System.Text;

namespace Checkers
{
    class Properties
    {

        public string[,] DeckPieces = new string[9, 9];
        public int DeckSize = 9;
        public static void BotRnd(string[,] Deck, out int X, out int Y)
        {
            while (1 > 0)
            {
                Random x = new Random();
                X = x.Next(1, 8);
                Random y = new Random();
                Y = y.Next(1, 8);
                if (Deck[X, Y] == Pieces.BotPiece())
                {
                    break;
                }
            }
            
        }
        public static void Finish (int bot, int player)
        {
            if (player == 0 || bot == 0)
            {
                if (bot == 0)
                {
                    Console.Clear();
                    Text.Winner();
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                else
                {
                    if (player == 0)
                    {
                        Console.Clear();
                        Text.Loser();
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                }
            }
        }
        public static void count(string[,] Deck)
        {

        }

    }
    
}
