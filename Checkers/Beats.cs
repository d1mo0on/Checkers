using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Checkers
{
    class Beats
    {
        public static void PlayerBeat(ref string[,] Deck, int X, int Y, int i, ref int bot)
        {
            switch (i)
            {
                case 1:
                    {
                            Moves.MoveLeft(ref Deck, X, Y);
                    }break;
                case 2:
                    {
                            Moves.MoveRight(ref Deck, X, Y);
                    }break;
                default: { Moves.MoveError(ref Deck, X, Y); };break;
            }
        }
        public static void BotBeat(ref string[,] Deck, int X, int Y, int sw, ref int player)
        {
            switch(sw)
            {
                case 1:
                    {
                        if (X + 2 > 0 && Y - 2 > 0)
                        {
                            if (Deck[X + 1, Y - 1] == Pieces.PlayerPiece())
                            {

                                if (Deck[X + 2, Y - 2] == Pieces.EmptyPiece())
                                {
                                    Deck[X, Y] = Pieces.EmptyPiece();
                                    Deck[X + 1, Y - 1] = Pieces.EmptyPiece();
                                    Deck[X + 2, Y - 2] = Pieces.BotPiece();
                                    player--;
                                }
                            }
                            else
                            {
                                Bot.ML(ref Deck, X, Y);
                            }
                        }
                    }
                    break;
                case 2:
                    {
                        if (X + 2 > 0 && Y + 2 > 0)
                        {
                            if (Deck[X + 1, Y + 1] == Pieces.PlayerPiece())
                            {

                                if (Deck[X + 2, Y + 2] == Pieces.EmptyPiece())
                                {
                                    Deck[X, Y] = Pieces.EmptyPiece();
                                    Deck[X + 1, Y + 1] = Pieces.EmptyPiece();
                                    Deck[X + 2, Y + 2] = Pieces.BotPiece();
                                    player--;
                                }

                            }


                            else
                            {
                                Bot.MR(ref Deck, X, Y);
                            }
                        }
                    }
                    break;
                    
            }
        }
        public static void PlayersTurn(ref string[,] Deck, ref int bot, int br)
        {
            for (int X = 1; X < 9; X++)
            {
                if (br == 1)
                {
                    break;
                }
                else
                {
                    for (int Y = 1; Y < 9; Y++)
                    {

                        if (br == 1)
                        {
                            break;
                        }
                        else
                        {
                            if (X - 2 > 0 && X + 2 < 9 && Y - 2 > 0 && Y + 2 < 9)
                            {
                                if (Deck[X, Y] == Pieces.PlayerPiece())
                                {
                                    if (Deck[X - 1, Y - 1] == Pieces.BotPiece() && X - 2 > 0 && Y - 2 > 0 && Deck[X - 2, Y - 2] == Pieces.EmptyPiece())
                                    {
                                        Console.Clear(); br = 1;
                                        Deck[X, Y] = Pieces.EmptyPiece();
                                        Deck[X - 1, Y - 1] = Pieces.EmptyPiece();
                                        bot--;
                                        Deck[X - 2, Y - 2] = Pieces.PlayerPiece();
                                        Color.CheckersDeckColorStart(Deck);
                                        Console.Write("\nAutobeated" +
                                            "\n\t_\t_  _ _Press_any_key_to_continue_////");
                                        Console.ReadKey();

                                    }
                                    else
                                    {
                                        if (Deck[X - 1, Y + 1] == Pieces.BotPiece() && X - 2 > 0 && Y + 2 < 9 && Deck[X - 2, Y + 2] == Pieces.EmptyPiece())
                                        {
                                            Console.Clear(); br = 1;
                                            Deck[X, Y] = Pieces.EmptyPiece();
                                            Deck[X - 1, Y + 1] = Pieces.EmptyPiece();
                                            bot--;
                                            Deck[X - 2, Y + 2] = Pieces.PlayerPiece();
                                            Color.CheckersDeckColorStart(Deck);
                                            Console.Write("\nAutobeated" +
                                                "\n\t_\t_  _ _Press_any_key_to_continue_////");
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            if (Deck[X + 1, Y + 1] == Pieces.BotPiece() && X + 2 < 9 && Y + 2 < 9 && Deck[X + 2, Y + 2] == Pieces.EmptyPiece())
                                            {
                                                Console.Clear(); br = 1;
                                                Deck[X, Y] = Pieces.EmptyPiece();
                                                Deck[X + 1, Y + 1] = Pieces.EmptyPiece();
                                                bot--;
                                                Deck[X + 2, Y + 2] = Pieces.PlayerPiece();
                                                Color.CheckersDeckColorStart(Deck);
                                                Console.Write("\nAutobeated" +
                                                    "\n\t_\t_  _ _Press_any_key_to_continue_////");
                                                Console.ReadKey();
                                            }
                                            else
                                            {
                                                if (Deck[X + 1, Y - 1] == Pieces.BotPiece() && X + 2 < 9 && Y - 2 > 0 && Deck[X + 2, Y - 2] == Pieces.EmptyPiece())
                                                {
                                                    Console.Clear(); br = 1;
                                                    Deck[X, Y] = Pieces.EmptyPiece();
                                                    Deck[X + 1, Y + 1] = Pieces.EmptyPiece();
                                                    bot--;
                                                    Deck[X - 2, Y - 2] = Pieces.PlayerPiece();
                                                    Color.CheckersDeckColorStart(Deck);
                                                    Console.Write("\nAutobeated" +
                                                        "\n\t_\t_  _ _Press_any_key_to_continue_////");
                                                    Console.ReadKey();
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (br == 0)
            {
                Turns.PlayersTurn0(ref Deck, ref bot);
            }
        }

        public static void AutoBeatPlayer(ref string[,] Deck, int X, int Y, ref int bot, ref int br)
        {
            for (int i = 1; i < 5; i++)
            {
                switch (i)
                {
                    case 1:
                        {
                            if (X - 2 > 0 && Y - 2 > 0)
                            {
                                if (Deck[X - 1, Y - 1] == Pieces.BotPiece() && Deck[X - 2, Y - 2] == Pieces.EmptyPiece())
                                {
                                    Console.Clear(); br = 1;
                                    Deck[X, Y] = Pieces.EmptyPiece();
                                    Deck[X - 1, Y - 1] = Pieces.EmptyPiece();
                                    bot--;
                                    Deck[X - 2, Y - 2] = Pieces.PlayerPiece();
                                    Thread.Sleep(16);
                                    Color.CheckersDeckColorStart(Deck);
                                    if (X - 3 > 0 && Y - 3 > 0)
                                    {
                                        Beats.AutoBeatPlayer(ref Deck, X - 2, Y - 2, ref bot, ref br);
                                    }
                                }
                            }
                        }
                        break;
                    case 2:
                        {
                            if (X - 2 > 0 && Y + 2 < 9)
                            {
                                if (Deck[X - 1, Y + 1] == Pieces.BotPiece() && Deck[X - 2, Y + 2] == Pieces.EmptyPiece())
                                {
                                    Console.Clear(); br = 1;
                                    Deck[X, Y] = Pieces.EmptyPiece();
                                    Deck[X - 1, Y + 1] = Pieces.EmptyPiece();
                                    bot--;
                                    Deck[X - 2, Y + 2] = Pieces.PlayerPiece();
                                    Thread.Sleep(16);
                                    Color.CheckersDeckColorStart(Deck);
                                    if (X - 3 > 0 && Y + 3 < 9)
                                    {
                                        Beats.AutoBeatPlayer(ref Deck, X - 2, Y + 2, ref bot, ref br);
                                    }
                                }
                            }
                        }
                        break;
                    case 3:
                        {
                            if (X + 2 < 9 && Y + 2 < 9)
                            {
                                if (Deck[X + 1, Y + 1] == Pieces.BotPiece() && Deck[X + 2, Y + 2] == Pieces.EmptyPiece())
                                {
                                    Console.Clear(); br = 1;
                                    Deck[X, Y] = Pieces.EmptyPiece();
                                    Deck[X + 1, Y + 1] = Pieces.EmptyPiece();
                                    bot--;
                                    Deck[X + 2, Y + 2] = Pieces.PlayerPiece();
                                    Thread.Sleep(16);
                                    Color.CheckersDeckColorStart(Deck);
                                    if (X + 3 < 9 && Y + 3 < 9)
                                    {
                                        Beats.AutoBeatPlayer(ref Deck, X + 2, Y + 2, ref bot, ref br);
                                    }
                                }
                            }
                        }
                        break;
                    case 4:
                        {
                            if (X + 2 < 9 && Y - 2 > 0)
                            {
                                if (Deck[X + 1, Y - 1] == Pieces.BotPiece() && Deck[X + 2, Y - 2] == Pieces.EmptyPiece())
                                {
                                    Console.Clear(); br = 1;
                                    Deck[X, Y] = Pieces.EmptyPiece();
                                    Deck[X + 1, Y - 1] = Pieces.EmptyPiece();
                                    bot--;
                                    Deck[X + 2, Y - 2] = Pieces.PlayerPiece();
                                    Thread.Sleep(16);
                                    Color.CheckersDeckColorStart(Deck);
                                    if (X + 3 < 9 && Y - 3 > 0)
                                    {
                                        Beats.AutoBeatPlayer(ref Deck, X + 2, Y - 2, ref bot, ref br);
                                    }
                                }

                            }
                        }

                        break;
                }
            }
        }
        public static void AutoBeatBot(ref string[,] Deck,int X, int Y,ref int br)
        {
            br = 0;
            for (int i = 1; i < 5; i++)
            {
                if (br > 0)
                {
                    break;
                }
                else
                {
                    switch (i)
                    {
                        case 1:
                            {
                                if (X - 2 > 0 && Y - 2 > 0)
                                {
                                    if (Deck[X - 1, Y - 1] == Pieces.PlayerPiece() && Deck[X - 2, Y - 2] == Pieces.EmptyPiece())
                                    {
                                        Console.Clear(); br++;
                                        Deck[X, Y] = Pieces.EmptyPiece();
                                        Deck[X - 1, Y - 1] = Pieces.EmptyPiece();
                                        Deck[X - 2, Y - 2] = Pieces.BotPiece();
                                        Thread.Sleep(16);
                                        Color.CheckersDeckColorStart(Deck);
                                        if (X - 3 > 0 && Y - 3 > 0)
                                        {
                                            Beats.AutoBeatBot(ref Deck, X - 2, Y - 2, ref br);
                                        }
                                    }
                                    else continue;
                                }
                                else continue;
                            }
                            break;
                        case 2:
                            {
                                if (X - 2 > 0 && Y + 2 < 9)
                                {
                                    if (Deck[X - 1, Y + 1] == Pieces.PlayerPiece() && Deck[X - 2, Y + 2] == Pieces.EmptyPiece())
                                    {
                                        Console.Clear(); br++;
                                        Deck[X, Y] = Pieces.EmptyPiece();
                                        Deck[X - 1, Y + 1] = Pieces.EmptyPiece();
                                        Deck[X - 2, Y + 2] = Pieces.BotPiece();
                                        Thread.Sleep(16);
                                        Color.CheckersDeckColorStart(Deck);
                                        if (X - 3 > 0 && Y + 3 > 0)
                                        {
                                            Beats.AutoBeatBot(ref Deck, X - 2, Y + 2, ref br);
                                        }
                                    }
                                    else continue;
                                }
                                else continue;
                            }
                            break;
                        case 3:
                            {
                                if (X + 2 < 9 && Y + 2 < 9)
                                {
                                    if (Deck[X + 1, Y + 1] == Pieces.PlayerPiece() && Deck[X + 2, Y + 2] == Pieces.EmptyPiece())
                                    {
                                        Console.Clear(); br++;
                                        Deck[X, Y] = Pieces.EmptyPiece();
                                        Deck[X + 1, Y + 1] = Pieces.EmptyPiece();
                                        Deck[X + 2, Y + 2] = Pieces.BotPiece();
                                        Thread.Sleep(16);
                                        Color.CheckersDeckColorStart(Deck);
                                        if (X + 3 > 0 && Y + 3 > 0)
                                        {
                                            Beats.AutoBeatBot(ref Deck, X + 2, Y + 2, ref br);
                                        }
                                    }
                                    else continue;
                                }
                                else continue;
                            }
                            break;
                        case 4:
                            {
                                if (X + 2 < 9 && Y - 2 > 0)
                                {
                                    if (Deck[X + 1, Y - 1] == Pieces.PlayerPiece() && Deck[X + 2, Y - 2] == Pieces.EmptyPiece())
                                    {
                                        Console.Clear(); br++;
                                        Deck[X, Y] = Pieces.EmptyPiece();
                                        Deck[X + 1, Y - 1] = Pieces.EmptyPiece();
                                        Deck[X + 2, Y - 2] = Pieces.BotPiece();
                                        Thread.Sleep(16);
                                        Color.CheckersDeckColorStart(Deck);
                                        if (X + 3 > 0 && Y - 3 > 0)
                                        {
                                            Beats.AutoBeatBot(ref Deck, X + 2, Y - 2, ref br);
                                        }
                                    }
                                    else continue;
                                }
                                else continue;
                            }

                            break;
                    }
                }
            }
        }
    }
}
