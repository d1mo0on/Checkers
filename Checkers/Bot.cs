using System;
using System.Collections.Generic;
using System.Text;

namespace Checkers
{
    class Bot
    {
        public static void ML(ref string[,] Deck, int X, int Y)
        {
            Deck[X, Y] = Pieces.EmptyPiece();
            Deck[X + 1, Y - 1] = Pieces.BotPiece();
        }
        public static void MR(ref string[,] Deck, int X, int Y)
        {
            Deck[X, Y] = Pieces.EmptyPiece();
            Deck[X + 1, Y + 1] = Pieces.BotPiece();
        }
    }
}
