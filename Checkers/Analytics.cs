using System;
using System.Collections.Generic;
using System.Text;

namespace Checkers
{
    class Analytics
    {
        
        public static bool LeftCheck(string[,] Deck, int X, int Y, int x = 8)
        {
            if (Deck[X - 1, Y - 1] == Pieces.EmptyPiece() || (Deck[X - 1, Y - 1] == Pieces.BotPiece() && X - 2 > 0 && Y - 2 > 0 && Deck[X - 2, Y -2] == Pieces.EmptyPiece()) || Deck[X - 1, Y - 1] == " L " && Y - 1 > 0 && X - 1 > 0)
            {
                return true;
            }
            else return false;
        }
        public static bool RightCheck(string[,] Deck, int X, int Y, int x = 8)
        {
            if (Y != 8)
            {
                if (Deck[X - 1, Y + 1] == Pieces.EmptyPiece() || (Deck[X - 1, Y + 1] == Pieces.BotPiece() && X - 2 > 0 && Y + 2 < x + 1 && Deck[X - 2, Y + 2] == Pieces.EmptyPiece()) || Deck[X - 1, Y + 1] == " R " && Y + 1 < x + 1 && X - 1 > 0)
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }
    }
}
