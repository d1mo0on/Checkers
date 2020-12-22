using System;
using System.Collections.Generic;
using System.Text;

namespace Checkers
{
    class Color
    {
        public static void CheckersDeckColorStart(string[,] Deck, int x = 8)
        {
            Table.TableR(Deck);
            Console.Write("\t\n");
            for (int m = 0; m < x; m += 2)
            {
                Table.TableC(Deck, 1 + m, 0);
                Fill.FillUnpairedStart(Deck, m);
                Console.ResetColor();
                Console.Write("\t\n");
                Table.TableC(Deck, 2 + m, 0);
                if ((2 + m) == x + 1) { }
                else Fill.FillPairedStart(Deck, m);
            }
        }
        public static void CheckersDeckColorChosen(string[,] Deck, int X, int Y, int x = 8)
        {
            Console.Clear();
            Table.TableR(Deck);
            Console.Write("\t\n");
            for (int m = 0; m < x; m += 2)
            {
                Table.TableC(Deck, 1 + m, 0);
                for (int i = 1; i < x + 1; i++)
                {
                    if (1 + m == X && i == Y) { Pieces.ChosenPiece(Deck, X, Y); }
                    else { Fill.FillUnpaired(Deck, m, i); }
                    
                }
                Console.ResetColor();
                Console.Write("\t\n");
                Table.TableC(Deck, 2 + m, 0);
                if ((2 + m) == x + 1) { }
                else
                {
                    

                    for (int i = 1; i < x + 1; i++)
                    {
                        if ((2 + m) == X && i == Y) { Pieces.ChosenPiece(Deck, X, Y); }
                        else { Fill.FillPaired(Deck, m, i); }
                    }
                }
                Console.ResetColor();
                Console.Write("\t\n");
            }
        }
        public static void CheckersDeckColorChooseWay(string[,] Deck, int X, int Y, int x = 8)
        {
            Console.Clear();
            Table.TableR(Deck);
            Console.Write("\t\n");
            for (int m = 0; m < x; m += 2)
            {
                Table.TableC(Deck, 1 + m, 0);
                for (int i = 1; i < x + 1; i++)
                {
                    if (1 + m == X && i == Y) { Pieces.ChosenPiece(Deck, X, Y); }
                    else 
                    {
                        if (Deck[(1 + m), i] == " R " || Deck[(1 + m), i] == " L ") { Pieces.ChosenWay(Deck, 1 + m, i); }
                        else { Fill.FillUnpaired(Deck, m, i); }
                    }

                }
                Console.ResetColor();
                Console.Write("\t\n");
                Table.TableC(Deck, 2 + m, 0);
                if ((2 + m) == x + 1) { }
                else
                {


                    for (int i = 1; i < x + 1; i++)
                    {
                        if ((2 + m) == X && i == Y) { Pieces.ChosenPiece(Deck, X, Y); }
                        else 
                        {
                            if (Deck[(2 + m), i] == " R " || Deck[(2 + m), i] == " L ") { Pieces.ChosenWay(Deck, (2+m), (i)); }
                            else { Fill.FillPaired(Deck, m, i); }
                        }
                    }
                }
                Console.ResetColor();
                Console.Write("\t\n");
            }
        }

    }
}
