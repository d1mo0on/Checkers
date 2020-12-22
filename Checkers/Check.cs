using System;
using System.Collections.Generic;
using System.Text;

namespace Checkers
{
    class Check
    {
        public static bool piececheck(string[,] Deck, int X, int Y)
        {
            if (Deck[X, Y] != Pieces.PlayerPiece())
            {
                return false;
            }
            else return true;
        }

    }
    
}
