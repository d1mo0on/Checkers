using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Checkers
{
    class Fill
    {
        public static string[,] DeckFillEmpt(string[,] Deck, int x = 8)
        {
            for (int i = 0; i < x + 1; i++)
            {
                for (int j = 0; j < x + 1; j++)
                {
                    Deck[i, j] = Pieces.EmptyPiece();
                }
            }
            return Deck;
        }
        public static void FillUnpairedStart(string[,] Deck, int m, int x = 8)
        {
            for (int i = 1; i < x + 1; i++)
            {

                if (i % 2 == 0)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    if (Deck[1 + m, i] == Pieces.PlayerPiece())
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.Write(Deck[1 + m, i]);
                    Console.ResetColor();
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(Deck[1 + m, i]);
                    Console.ResetColor();
                }
            }
        }
        public static void FillPairedStart(string[,] Deck, int m, int x = 8)
        {
            for (int i = 1; i < x + 1; i++)
            {
                if (i % 2 != 0)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    if (Deck[2 + m, i] == Pieces.PlayerPiece())
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.Write(Deck[2 + m, i]);
                    Console.ResetColor();
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(Deck[2 + m, i]);
                    Console.ResetColor();
                }
            }
            Console.ResetColor();
            Console.Write("\t\n");
        }
        public static string[,] DeckFillPieces(string[,] Deck, int x = 8)
        {
            //opponent deck`s half 
            for (int i = 2; i < x + 1; i += 2)
            {
                Deck[1, i] = Pieces.BotPiece();
            }
            for (int i = 1; i < x + 1; i += 2)
            {
                Deck[2, i] = Pieces.BotPiece();
            }
            for (int i = 2; i < x + 1; i += 2)
            {
                Deck[3, i] = Pieces.BotPiece();
            }
            //player deck`s half
            for (int i = 1; i < x + 1; i += 2)
            {
                Deck[6, i] = Pieces.PlayerPiece();
            }
            for (int i = 2; i < x + 1; i += 2)
            {
                Deck[7, i] = Pieces.PlayerPiece();
            }
            for (int i = 1; i < x + 1; i += 2)
            {
                Deck[8, i] = Pieces.PlayerPiece();
            }
            return Deck;
        }
        public static void FillUnpaired(string[,] Deck, int m, int i, int x = 8)
        {
            if (i % 2 == 0)
            {
                Console.BackgroundColor = ConsoleColor.White;
                if (Deck[1 + m, i] == Pieces.PlayerPiece())
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.Write(Deck[1 + m, i]);
                Console.ResetColor();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(Deck[1 + m, i]);
                Console.ResetColor();
            }
        }
        public static void FillPaired(string[,] Deck, int m, int i, int x = 8)
        {
            if (i % 2 != 0)
            {
                Console.BackgroundColor = ConsoleColor.White;
                if (Deck[2 + m, i] == Pieces.PlayerPiece())
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.Write(Deck[2 + m, i]);
                Console.ResetColor();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(Deck[2 + m, i]);
                Console.ResetColor();
            }
        }
        public static void Movement(ref string[,] Deck, int X, int Y, ref int Err, ref int err, ref int corr, ref int bot, int count = 0, int ERR = 0)
        {
            int b = 0;
            while (1 > 0)
            {
                try
                {
                    if (((Analytics.RightCheck(Deck, X, Y) == true) && (Analytics.LeftCheck(Deck, X, Y) == true)) || ((Analytics.RightCheck(Deck, X, Y) != true) && (Analytics.LeftCheck(Deck, X, Y) == true)) || ((Analytics.RightCheck(Deck, X, Y) == true) && (Analytics.LeftCheck(Deck, X, Y) != true)))
                    {
                        Pieces.Left(ref Deck, X, Y, ref b);
                        Pieces.Right(ref Deck, X, Y, ref b);
                        Thread.Sleep(16);
                        Color.CheckersDeckColorChooseWay(Deck, X, Y);
                        if (count > 0 && ERR > 0) { Console.Write("\n!!\tUnknown side to move, try again\t!!"); }
                        Console.Write("\nChoose the way to move:");
                        if (Analytics.LeftCheck(Deck, X, Y) == true && Analytics.RightCheck(Deck, X, Y) == true)
                        {
                            if (b == 3)
                            {
                                Console.Write("\nType 'Left' for beating on left" +
                                "\nType'Right' for beating on right" +
                                "\nYour choice:\t");
                            }
                            else
                            {
                                if (b == 2)
                                {
                                    Console.Write("\nType 'Left' for left" +
                                    "\nType'Right' for beating on right" +
                                    "\nYour choice:\t");
                                }
                                else
                                {
                                    if (b == 1)
                                    {
                                        Console.Write("\nType 'Left' for beating on left" +
                                        "\nType'Right' for right" +
                                        "\nYour choice:\t");
                                    }
                                    else
                                    {
                                        Console.Write("\nType 'Left' for left" +
                                        "\nType'Right' for right" +
                                        "\nYour choice:\t");
                                    }
                                }
                            }
                            string move = Console.ReadLine().ToLower();
                            move i;
                            Enum.TryParse(move, out i);
                            switch ((int)i)
                            {
                                case 1: { Beats.PlayerBeat(ref Deck, X, Y, (int)i, ref bot); corr++; } break;
                                case 2: { Beats.PlayerBeat(ref Deck, X, Y, (int)i, ref bot); corr++; } break;
                            }
                            if (count > 0)
                            {
                                continue;
                            }
                            if (corr > 0)
                            {
                                break;
                            }
                        }
                        else
                        {
                            if (Analytics.LeftCheck(Deck, X, Y) != true)
                            {
                                Pieces.Left(ref Deck, X, Y, ref b);
                                if (b == 2)
                                {
                                    Console.Write("\nType'Right' for beating on right" +
                                    "\nYour choice:\t");

                                }
                                else
                                {
                                    Console.Write("\nType'Right' for right" +
                                    "\nYour choice:\t");
                                }
                                string move = Console.ReadLine().ToLower();
                                move i;
                                Enum.TryParse(move, out i);
                                switch ((int)i)
                                {
                                    case 2: { Beats.PlayerBeat(ref Deck, X, Y, (int)i, ref bot); corr++; } break;
                                }
                                if (count > 0)
                                {
                                    continue;
                                }
                                if (corr > 0)
                                {
                                    break;
                                }
                            }
                            else
                            {
                                if (Analytics.RightCheck(Deck, X, Y) != true)
                                {
                                    Pieces.Right(ref Deck, X, Y, ref b);
                                    if (b == 1)
                                    {
                                        Console.Write("\nType'Left' for beating on left" +
                                        "\nYour choice:\t");

                                    }
                                    else
                                    {
                                        Console.Write("\nType'Left' for left" +
                                        "\nYour choice:\t");
                                    }
                                    string move = Console.ReadLine().ToLower();
                                    move i;
                                    Enum.TryParse(move, out i);
                                    switch ((int)i)
                                    {
                                        case 1: { Beats.PlayerBeat(ref Deck, X, Y, (int)i, ref bot); corr++; } break;
                                    }
                                    if (count > 0)
                                    {
                                        continue;
                                    }
                                    if (corr > 0)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Err++;
                        err++;
                        break;
                    }
                    if (corr > 0)
                    {
                        break;
                    }
                }
                catch
                {
                    Moves.MoveError(ref Deck, X, Y);
                    ERR++;
                    Console.Clear(); count++;
                }
            }
        }
    }
}
