using System;
using System.Collections.Generic;
using System.Text;

namespace Checkers
{
    class Pieces
    {
        public static string PlayerPiece()
        {
            return " \x25B2 ";
        }

        public static string BotPiece()
        {
            return " \x25BC ";
        }

        public static string EmptyPiece()
        {
            return "   ";
        }
        public static string LeftMarker()
        {
            return " L ";
        }
        public static string RightMarker()
        {
            return " R "; ;
        }
        public static void ChosenPiece(string[,] Deck, int X, int Y)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(Deck[X, Y]);
            Console.ResetColor();
        }
        public static void ChosenWay(string[,] Deck, int a, int b)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(Deck[a, b]);
            Console.ResetColor();
        }
        public static void Left(ref string[,] Deck, int X, int Y,ref int b)
        {
            if (Analytics.LeftCheck(Deck, X, Y) == true)
            {
                if (Deck[X - 1, Y - 1] != Pieces.BotPiece())
                    Deck[X - 1, Y - 1] = Pieces.LeftMarker();
                if (Deck[X - 1, Y - 1] == Pieces.BotPiece() && Deck[X - 2, Y - 2] == Pieces.EmptyPiece())
                {
                    b++;
                }
            }
            else { Console.Write("\n!!\tACHTUNG\t!!\tThere is an obstacle on the way left\t!!"); }
        }
        public static void Right(ref string[,] Deck, int X, int Y, ref int b)
        {
            if (Analytics.RightCheck(Deck, X, Y) == true)
            {
                if (Deck[X - 1, Y + 1] != Pieces.BotPiece())
                    Deck[X - 1, Y + 1] = Pieces.RightMarker();
                if (Deck[X - 1, Y + 1] == Pieces.BotPiece() && Deck[X - 2, Y + 2] == Pieces.EmptyPiece())
                {
                    b+=2;
                }
            }
            else { Console.Write("\n!!\tACHTUNG\t!!\tThere is an obstacle on the way right\t!!"); }
        }

    }
    
}
