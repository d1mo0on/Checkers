using System;
using System.Collections.Generic;
using System.Text;


namespace Checkers
{
    class Game
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Text.RULES(out int diff);
            Properties Deck = new Properties();
            
            Deck.DeckPieces = Fill.DeckFillEmpt(Deck.DeckPieces);
            Deck.DeckPieces = Fill.DeckFillPieces(Deck.DeckPieces);
            int round = 1;
            int player = 12;
            int bot = 12;
            int iter = 0;
            int count = 0; 

            if (diff == 3)
            {
                iter = Difficulty.PlanIterations();
            }
            List<int> Plan = new List<int>(1) {0};
            while (1 > 0)
            {
                int player0 = player;
                int bot0 = bot;
                int br = 0;
                Text.Rounds(round);
                Turns.PlayersTurn(ref Deck.DeckPieces, ref bot, br, round);
                br = 0;
                Turns.BotTurn(ref Deck.DeckPieces, ref round, ref player, br, player0, bot0, diff, Plan, ref count, iter);
                if (round > 50 || player == 0 || bot == 0)
                {
                    break;
                }
            }
            Text.GAMEOVER(round, player, bot);
            
        }
    }
}
