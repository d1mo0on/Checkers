using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Checkers
{
    class Turns
    {
        public static void PlayersTurn0(ref string[,] Deck, ref int bot)
        {
            int err = 0;
            int Err = 0;
            int corr = 0;
            while (1 > 0)
            {
                try
                {
                    Console.Clear();

                    if (err > 0)
                    {
                        Thread.Sleep(16);
                        Color.CheckersDeckColorStart(Deck);
                        if (Err > 0)
                        {
                            Console.Write("\n!!\tThere is no way to go\t!!");
                        }
                        else
                        {
                            Text.Error();
                        }
                    }
                    else
                    {
                        Thread.Sleep(16);
                        Color.CheckersDeckColorStart(Deck);
                    }


                    Console.Write("\n Choose the piece to move:");
                    string move = Console.ReadLine();
                    char[] coords = move.ToLower().Replace(" ", "").ToCharArray();
                    if (coords.Length == 2)
                    {
                        coord i;
                        int X = int.Parse(coords[1].ToString());
                        Enum.TryParse(coords[0].ToString(), out i);
                        int Y = (int)i;
                        if (Deck[X, Y] == Pieces.PlayerPiece())
                        {

                            Moves.Move(ref Deck, X, Y, ref Err, ref err, ref corr, ref bot);
                        }
                        else
                        {
                            Console.Clear();
                            err++;
                        }
                    }
                    else
                    {
                        Console.Clear();
                        err++;
                    }

                }
                catch (Exception)
                {
                    Console.Clear();
                    err++;
                }
                if (corr > 0)
                {
                    break;
                }
            }
        }
        public static void PlayersTurn(ref string[,] Deck, ref int bot, int br, int round)
        {
            int bt = 0;
            if (round != 1)
            {
                for (int Y = 1; Y < 9; Y++)
                {
                    if (br == 1)
                    {
                        break;
                    }
                    else
                    {
                        for (int X = 1; X < 9; X++)
                        {
                            if (br == 1)
                            {
                                break;
                            }
                            else
                            {
                                if (Deck[X, Y] == Pieces.PlayerPiece())
                                {
                                    Text.Score(Deck, out int player1, out int bot1);                                  
                                    Beats.AutoBeatPlayer(ref Deck, X, Y, ref bot, ref br);
                                    Text.Score(Deck, out int player2, out int bot2);
                                    if (bot1 > bot2)
                                    {
                                        bt++;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (br == 0)
            {
                PlayersTurn0(ref Deck, ref bot);
            }
            Console.Clear();
            Color.CheckersDeckColorStart(Deck);
            if (bt > 0) Console.Write("\n\t\tAutobeated\n");
            Console.Write("\n\t_\t_  _ _Press_any_key_to_continue_////");
            Console.ReadKey();
        }

        public static void BotTurn0(ref string[,] Deck)
        {
            int X, Y;
            int i = 0;

            while (i < 1)
            {
                try
                {
                    Random x = new Random();
                    Random y = new Random();
                    Random Switch = new Random();
                    X = x.Next(1, 9);
                    Y = y.Next(1, 9);
                    if (Deck[X, Y] == Pieces.BotPiece())
                    {
                        if (Y == 8)
                        {
                            if (Deck[X + 1, Y - 1] == Pieces.EmptyPiece())
                            {
                                Bot.ML(ref Deck, X, Y);
                                i++;
                            }
                        }
                        else
                        {
                            if (X + 1 < 9 && Y + 1 < 9 && Y - 1 > 0)
                            {
                                if (Deck[X + 1, Y - 1] == Pieces.EmptyPiece() && Deck[X + 1, Y + 1] == Pieces.EmptyPiece())
                                {

                                    int sw = Switch.Next(1, 3);
                                    switch (sw)
                                    {
                                        case 1:
                                            { Bot.ML(ref Deck, X, Y); i++; }
                                            break;
                                        case 2:
                                            { Bot.MR(ref Deck, X, Y); i++; }
                                            break;
                                        default: continue;
                                    }

                                }
                                else
                                {
                                    if (X + 1 < 9 && Y + 1 < 9)
                                    {
                                        if (Deck[X + 1, Y + 1] == Pieces.EmptyPiece())
                                        {
                                            Bot.MR(ref Deck, X, Y); i++;
                                        }
                                        else
                                        {
                                            if (X + 1 < 9 && Y - 1 > 0)
                                            {
                                                if (Deck[X + 1, Y - 1] == Pieces.EmptyPiece())
                                                {
                                                    Bot.ML(ref Deck, X, Y); i++;
                                                }
                                            }
                                            else
                                            {
                                                continue;
                                            }
                                        }
                                    }
                                }
                            }

                            else
                            {
                                continue;
                            }
                        }
                    }
                }

                catch
                {
                    continue;
                }
            }
        }



        public static void BotTurn(ref string[,] Deck, ref int round, ref int p, int br, int player0, int bot0, int diff, List <int> Plan, ref int count, int iter)
        {
            int brk = 0;
            int next = 0;
            for (int Y = 1; Y < 9; Y++)
            {
                if (br > 0)
                {
                    break;
                }
                else
                {
                    for (int X = 1; X < 9; X++)
                    {
                        if (br > 0)
                        {
                            break;
                        }
                        else
                        {
                            if (Deck[X, Y] == Pieces.BotPiece())
                            {
                                Text.Score(Deck, out int player1, out int bot1);
                                Beats.AutoBeatBot(ref Deck, X, Y, ref br);
                                Text.Score(Deck, out int player2, out int bot2);
                                if (player1 > player2)
                                {
                                    brk = 2;
                                    round++;
                                }
                            }
                        }
                    }
                }
            }
            if (brk != 2)
            {

                int X, Y;
                int i = 0;

                while (i < 1)
                {
                    try
                    {
                        Random x = new Random();
                        Random y = new Random();
                        Random Switch = new Random();
                        X = x.Next(1, 9);
                        Y = y.Next(1, 9);
                        if (Deck[X, Y] == Pieces.BotPiece())
                        {
                            if (Y == 8)
                            {
                                if (Deck[X + 1, Y - 1] == Pieces.EmptyPiece())
                                {
                                    switch (diff)
                                    {
                                        case 1:
                                            {
                                                Bot.ML(ref Deck, X, Y); round++; i++;
                                            }
                                            break;
                                        case 2:
                                            {
                                                Difficulty.DiffMedium(ref Deck, X, Y, 1, ref round, ref i, ref next);
                                                if (next > 0)
                                                {
                                                    continue;
                                                }
                                            }
                                            break;
                                        case 3:
                                            {
                                                Difficulty.DiffPseudoHARD(ref Deck, X, Y, iter, ref Plan, ref count, ref round, ref i);
                                            }
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                if (X + 1 < 9 && Y + 1 < 9 && Y - 1 > 0)
                                {
                                    if (Deck[X + 1, Y - 1] == Pieces.EmptyPiece() && Deck[X + 1, Y + 1] == Pieces.EmptyPiece())
                                    {

                                        int sw = Switch.Next(1, 3);
                                        switch (diff)
                                        {
                                            case 1:
                                                {
                                                    switch (sw)
                                                    {
                                                        case 1:
                                                            { Bot.ML(ref Deck, X, Y); round++; i++; }
                                                            break;
                                                        case 2:
                                                            { Bot.MR(ref Deck, X, Y); round++; i++; }
                                                            break;
                                                        default: continue;
                                                    }
                                                }
                                                break;
                                            case 2:
                                                {
                                                    Difficulty.DiffMedium(ref Deck, X, Y, sw, ref round, ref i, ref next);
                                                    if (next > 0)
                                                    {
                                                        continue;
                                                    }
                                                }
                                                break;
                                            case 3:
                                                {
                                                    Difficulty.DiffPseudoHARD(ref Deck, X, Y, iter,ref Plan, ref count,ref round, ref i);
                                                }
                                                break;
                                        }

                                    }
                                    else
                                    {
                                        if (X + 1 < 9 && Y + 1 < 9)
                                        {
                                            if (Deck[X + 1, Y + 1] == Pieces.EmptyPiece())
                                            {
                                                switch (diff)
                                                {
                                                    case 1:
                                                        {
                                                            Bot.MR(ref Deck, X, Y); round++; i++;
                                                        }
                                                        break;
                                                    case 2:
                                                        {
                                                            Difficulty.DiffMedium(ref Deck, X, Y, 2, ref round, ref i, ref next);
                                                            if (next > 0)
                                                            {
                                                                continue;
                                                            }
                                                        }
                                                        break;
                                                    case 3:
                                                        {
                                                            Difficulty.DiffPseudoHARD(ref Deck, X, Y, iter, ref Plan, ref count, ref round, ref i);
                                                        }
                                                        break;
                                                }

                                            }
                                        }
                                        else
                                        {
                                            if (X + 1 < 9 && Y - 1 > 0)
                                            {
                                                if (Deck[X + 1, Y - 1] == Pieces.EmptyPiece())
                                                {
                                                    switch (diff)
                                                    {
                                                        case 1:
                                                            {
                                                                Bot.ML(ref Deck, X, Y); round++; i++;
                                                            }
                                                            break;
                                                        case 2:
                                                            {
                                                                Difficulty.DiffMedium(ref Deck, X, Y, 1, ref round, ref i, ref next);
                                                                if (next > 0)
                                                                {
                                                                    continue;
                                                                }
                                                            }
                                                            break;
                                                        case 3:
                                                            {
                                                                Difficulty.DiffPseudoHARD(ref Deck, X, Y, iter, ref Plan, ref count, ref round, ref i);
                                                            }
                                                            break;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                continue;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }

            }
            Console.Clear();
            Color.CheckersDeckColorStart(Deck);
            Text.Score(Deck, out p, out int b);
            Console.Write($"\nAlive: Player - {p}\tBot - {b}");
            if (player0 > p)
            {
                Console.Write("\nPlayer bears losses");
            }
            if (bot0 > b)
            {
                Console.Write("\nBot bears losses");
            }
            Console.Write("\n\t_\t_  _ _Press_any_key_////");
            Console.ReadKey();
        }



    }
}

