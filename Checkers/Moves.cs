using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Checkers
{
    class Moves
    {
        public static void Move(ref string[,] Deck, int X, int Y,ref int Err,ref int err,ref int corr, ref int bot)
        {
            Fill.Movement(ref Deck, X, Y, ref Err, ref err, ref corr, ref bot);
            Console.Clear();
            Thread.Sleep(16);
            Color.CheckersDeckColorStart(Deck);
        }
        public static void MoveLeft(ref string[,] Deck, int X, int Y)
        {
            Deck[X, Y] = Pieces.EmptyPiece();
            Deck[X - 1, Y - 1] = Pieces.PlayerPiece();
            if (X - 1 > 0 && Y + 1 < 9)
            {
                if (Deck[X - 1, Y + 1] == Pieces.RightMarker())
                {
                    Deck[X - 1, Y + 1] = Pieces.EmptyPiece();
                }
            }
            
        }
        public static void MoveRight(ref string[,] Deck, int X, int Y)
        {
            Deck[X, Y] = Pieces.EmptyPiece();
            Deck[X - 1, Y + 1] = Pieces.PlayerPiece();
            if (X + 1 < 9 && Y + 1 < 9)
            {
                if (Deck[X - 1, Y - 1] == Pieces.LeftMarker())
                {
                    Deck[X - 1, Y - 1] = Pieces.EmptyPiece();
                }
            }
        }
        public static void MoveError(ref string[,] Deck, int X, int Y)
        {
            Deck[X, Y] = Pieces.PlayerPiece();
            
            if (Deck[X - 1, Y - 1] == Pieces.LeftMarker())
            {
                Deck[X - 1, Y - 1] = Pieces.EmptyPiece();
            }
            if (Deck[X - 1, Y + 1] == Pieces.RightMarker())
            {
                Deck[X - 1, Y + 1] = Pieces.EmptyPiece();
            }
        }
    }
}
