using System;
using System.Collections.Generic;
using System.Text;

namespace Checkers
{
    public class Difficulty
    {
        public static void DiffMedium(ref string[,] Deck, int X, int Y, int sw, ref int round, ref int i, ref int next)
        {
            switch (sw)
            {
                case 2:
                    {
                        if (X + 2 < 9 && Y + 2 < 9)
                        {
                            if (Deck[X + 2, Y + 2] == Pieces.PlayerPiece() || (Deck[X + 2, Y] == Pieces.PlayerPiece() && Deck[X, Y + 2] == Pieces.EmptyPiece()) || (Deck[X, Y + 2] == Pieces.PlayerPiece() && Deck[X + 2, Y] == Pieces.EmptyPiece()))
                            {
                                next++;
                            }
                            else
                            {
                                Bot.MR(ref Deck, X, Y); round++; i++;
                            }
                        }
                        else
                        {
                            Bot.MR(ref Deck, X, Y); round++; i++;
                        }
                    }
                    break;
                case 1:
                    {
                        if (X + 2 < 9 && Y - 2 > 0)
                        {
                            if (Deck[X + 2, Y - 2] == Pieces.PlayerPiece() || (Deck[X + 2, Y] == Pieces.PlayerPiece() && Deck[X, Y - 2] == Pieces.EmptyPiece()) || (Deck[X, Y - 2] == Pieces.PlayerPiece() && Deck[X + 2, Y] == Pieces.EmptyPiece()))
                            {
                                next++;
                            }
                            else
                            {
                                Bot.ML(ref Deck, X, Y); round++; i++;
                            }
                        }
                        else
                        {
                            Bot.ML(ref Deck, X, Y); round++; i++;
                        }
                    }
                    break;
            }
        }
        public static int PlanIterations()
        {
            int it = 0;
            while (true)
            {
                try
                {
                    Console.Clear();
                    if (it > 0)
                    {
                        Text.Error();
                    }
                    Console.Write("\nHow many turns should plan bot(no more than 5)?" +
                        "\nYour choice:\t");
                    int i = int.Parse(Console.ReadLine());
                    if (i > 0 && i <= 5)
                    {
                        return i;
                    }
                    else
                    {
                        it++;
                        continue;
                    }
                }
                catch
                {
                    it++;
                    continue;
                }
            }

        }
        public static void DiffPseudoHARD(ref string[,] Deck, int X, int Y, int iter, ref List<int> Plan, ref int count, ref int round, ref int i)
        {
            if (count == iter || count == 0)
            {
                count = 0;
                if (count == iter)
                {
                    Plan.RemoveRange(0, iter - 1);
                }

                Turns.BotTurn0(ref Deck);
                Random Move = new Random();
                for (int j = 1; j < iter; j++)
                {
                    switch (Move.Next(1, 3)) // 1 - left, 2 - right
                    {
                        case 1:
                            {
                                if (X + 1 < 9 && Y - 1 > 0 && Deck[X + 1, Y - 1] == Pieces.EmptyPiece())
                                {
                                    X++; Y--;
                                    Plan.Add(X * 100 + Y * 10 + 1);
                                }
                                else
                                {
                                    if (X + 1 < 9 && Y + 1 < 9 && Deck[X + 1, Y + 1] == Pieces.EmptyPiece())
                                    {
                                        X++; Y--;
                                        Plan.Add(X * 100 + Y * 10 + 2);
                                    }
                                    else Plan.Add(0);
                                }
                            }
                            break;
                        case 2:
                            {
                                if (X + 1 < 9 && Y + 1 < 9 && Deck[X + 1, Y + 1] == Pieces.EmptyPiece())
                                {
                                    X++; Y++;
                                    Plan.Add(X * 100 + Y * 10 + 2);
                                }
                                else
                                {
                                    if (X + 1 < 9 && Y - 1 > 0 && Deck[X + 1, Y - 1] == Pieces.EmptyPiece())
                                    {
                                        X++; Y--;
                                        Plan.Add(X * 100 + Y * 10 + 1);
                                    }
                                    else Plan.Add(0);
                                }
                            }
                            break;
                    }
                }
                round++;

            }
            else
            {
                try
                {

                    if (Plan[count] != 0)
                    {
                        int coords = Plan[count];
                        int I = coords / 100;
                        int J = (coords - I * 100) / 10;
                        int m = coords - (I * 100 + J * 10);
                        if (Deck[I, J] != Pieces.BotPiece() && Deck[I, J] != Pieces.PlayerPiece())
                        {
                            switch (m)
                            {
                                case 1:
                                    {
                                        if (Deck[I - 1, J + 1] == Pieces.BotPiece())
                                        {
                                            Deck[I, J] = Pieces.BotPiece();
                                            Deck[I - 1, J + 1] = Pieces.EmptyPiece();
                                            round++;
                                        }
                                        else Turns.BotTurn0(ref Deck);
                                    }
                                    break;
                                case 2:
                                    {
                                        if (Deck[I - 1, J - 1] == Pieces.BotPiece())
                                        {
                                            Deck[I, J] = Pieces.BotPiece();
                                            Deck[I - 1, J - 1] = Pieces.EmptyPiece();
                                            round++;
                                        }
                                        else Turns.BotTurn0(ref Deck);
                                    }
                                    break;
                            }
                        }

                    }
                    else { Turns.BotTurn0(ref Deck); }
                }

                catch
                {
                    Turns.BotTurn0(ref Deck);
                }
            }
            count++;
            i++;


        }
    }
}



