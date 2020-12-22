using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Checkers
{
    class Text
    {
        public static void RULES(out int difficulty)
        {

            while (1 > 0)
            {
                try
                {
                    Console.Clear();
                    Console.Write("\n!!\tRULES\t!!" +
                "\nThis game is a classic version of Soviet Checkers or Draughts" +
                "\nYou are fighting against a computer" +
                "\nYour turn will start the game" +
                "\nYou have to choose a piece you would like to move" +
                "\nYou should write the coordinates of it in such way:" +
                "\na1, where 'a' stands for the position in a row and '1' stands for position in a coloumn" +
                "\nThen you need to write 'Left' to move it 1 step diagonally on left, or 'Right' to move it 1 step diagonally right" +
                "\nIf there is an opponent`s piece on your one`s way, you beat it automatically" +
                "\nAlso, if there are two or more opponent`s pieces on one flex line with a gap of 1 stem between each piece, you beat them all in one turn");
                    Console.Write("\nIf you accept this rules, write YES, instead write NO:");
                    string acception = Console.ReadLine();
                    acception = acception.ToLower().Trim();
                    if (acception == "yes") { break; }
                    else
                    {
                        if (acception == "no") { Environment.Exit(0); }
                        else { Console.Write("\n!!\tERROR\t!!\tINVALID\tINPUT\t!!\n"); }
                    }
                }
                catch (Exception) { Console.Write("\n!!\tERROR\t!!\tINVALID\tINPUT\t!!\n"); }
            }
            Console.Clear();
            while (1 > 0)
            {
                try
                {
                    Console.Write("\nChoose the difficuty, please:" +
                        "\n1 - bot makes random moves" +
                        "\n2 - bot tries to avoid beating of his pieces, but still moves randomly" +
                        "\n3 - bot plans some turns for 1 piece (you choose the number of turns)" +
                        "\n\nYour choice:\t");
                    difficulty = int.Parse(Console.ReadLine());
                    
                    if (difficulty == 1) { break; }
                    else
                    {
                        if (difficulty == 2) { break; }
                        else 
                        {
                            if (difficulty == 3) { break; }
                            else { Console.Write("\n!!\tERROR\t!!\tINVALID\tINPUT\t!!\n"); }
                        }
                        
                    }
                }
                catch (Exception) {                Console.Clear(); Console.Write("\n!!\tERROR\t!!\tINVALID\tINPUT\t!!\n"); }

            }
        }

        public static void Error()
        {
            Console.Write("\n!!\tERROR\t!!\tINVALID\tINPUT\t!!\n");
        }

        public static void Rounds(int round)
        {
            int err = 0;
            ConsoleKeyInfo keyInfo;
            Console.Clear();
            do
            {
                Console.Clear();
                Console.Write($"\n\t_\t_Round_{round}_\t_\t");
                if (err > 0) Console.Write($"\n\t_\t_  _ _INVALID_INPUT_////");
                Console.Write($"\n\t_\t   _  _ _Press_ENTER_to_continue_////" +
                    $"\n\t_\t_  _ _Press_ESC_to_quit_////");
                keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Text.Loser();
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                if (keyInfo.Key == ConsoleKey.Enter) break;
                err++;
            } while (1 > 0);
            Console.Clear();
        }
        public static void Score(string[,] Deck, out int player, out int bot)
        {
            player = 0; bot = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (Deck[i, j] == Pieces.BotPiece())
                    {
                        bot++;
                    }
                    if (Deck[i, j] == Pieces.PlayerPiece())
                    {
                        player++;
                    }
                }
            }
            
        }
        public static void Winner()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nWINNER,\tWINNER,\tCHICKEN\tDINNER\t\tWINNER,\tWINNER,\tCHICKEN\tDINNER\t\tWINNER,\tWINNER,\tCHICKEN\tDINNER\t\n");
            Console.Write("\nWINNER,\tWINNER,\tCHICKEN\tDINNER\t\tWINNER,\tWINNER,\tCHICKEN\tDINNER\t\tWINNER,\tWINNER,\tCHICKEN\tDINNER\t\n");
            Console.Write("\nWINNER,\tWINNER,\tCHICKEN\tDINNER\t\tWINNER,\tWINNER,\tCHICKEN\tDINNER\t\tWINNER,\tWINNER,\tCHICKEN\tDINNER\t\n");
        }
        public static void Loser()
        {
            Console.Write("\n!!!\tHa-hA-HA-ha\t!!!\t!!!\tHa-hA-HA-ha\t!!!\t!!!\tHa-hA-HA-ha\t!!!\t");
            Console.Write("\n!!!\tHa-hA-HA-ha\t!!! ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\t    Y O U\tL O S T   \t");
            Console.ResetColor();
            Console.Write("!!!\tHa-hA-HA-ha\t!!!");
            Console.Write("\n!!!\tHa-hA-HA-ha\t!!!\t!!!\tHa-hA-HA-ha\t!!!\t!!!\tHa-hA-HA-ha\t!!!\t");
        }
        public static void GAMEOVER(int round, int player, int bot)
        {
            Console.Clear();
            Console.Write("\n\tGAME OVER\n");
            if (round > 50)
            {
                Console.Write("\nThere were more than 50 rounds, damn!\n");
                Thread.Sleep(128);
                Console.Write("\nNow it`s interesting to know, who won: you or this stupid machine???\n");
                Thread.Sleep(128);
                Console.Write("\nIf you want to know tha result, pay 100$ to the following bank account");
                Thread.Sleep(128);
                Console.Write("\nHa-hA-HA-ha!!! It`s a joke! Just press any key\n");
                Thread.Sleep(128);
                Console.Write("\n\t_\t_  _ _Press_any_key_to_examine_results_////");
                Console.ReadKey();
                if (player > bot)
                {
                    Text.Winner();
                }
                else
                {
                    Text.Loser();
                }
                Thread.Sleep(64);
                Console.Write("\n\t_\t_  _ _Press_any_key_to_exit_////");
                Console.ReadKey();
            }
        }

    }
}
