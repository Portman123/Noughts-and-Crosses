using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noughts_and_Crosses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PlayerMenace Menace1 = new PlayerMenace(new MENACE(), "Menace1");
            PlayerMenace Menace2 = new PlayerMenace(new MENACE(), "Menace2");
            Player Human1 = new PlayerHuman("Human1");

            for (int i = 0; i < 10000; i++)
            {
                Console.WriteLine("training");
                Game g = new Game(Menace1, Menace2);
                g.Train();

                if (g.Winner == Menace1)
                {
                    Menace1.Reward(g.History);
                    Menace2.Punish(g.History);
                }
                else if (g.Winner == Menace2)
                {
                    Menace1.Punish(g.History);
                    Menace2.Reward(g.History);
                }
            }

            Menace1.LogDiagnostics();
            Menace2.LogDiagnostics();
            Console.WriteLine("");
            Console.WriteLine("");

            while (true)
            {
                Game h = new Game(Menace1, Human1);

                h.PlayGame();
                if (h.Winner == Menace1)
                {
                    Menace1.Reward(h.History);
                }
                else
                {
                    Menace1.Punish(h.History);
                }

                Menace1.LogDiagnostics();
                Console.WriteLine();
            }
        }


        //public static void PlayMENACE(MENACE menace)
        //{
        //    // Initialise new game object
        //    Game myGame = new Game();

        //    // Game Loop
        //    while (true)
        //    {
        //        // Player 1 turn
        //        Console.WriteLine("Player 1: ");
        //        myGame.CurrentBoard = myGame.CurrentBoard.MakeMove(Game.GetUserInput(), 1);
        //        myGame.CurrentBoard.PrintBoard();

        //        // Check Game End
        //        if (myGame.CurrentBoard.CheckWin() != 0 || myGame.CurrentBoard.BoardFull()) break;

        //        // MENACE Turn 
        //        Console.WriteLine("MENACE: ");

        //        myGame.CurrentBoard = menace.PlayTurn(myGame.CurrentBoard);
        //        myGame.CurrentBoard.PrintBoard();

        //        // Check Game End
        //        if (myGame.CurrentBoard.CheckWin() != 0 || myGame.CurrentBoard.BoardFull()) break;
        //    }

        //    myGame.CurrentBoard.PrintBoard();
        //    myGame.AnnounceWinner();
        //}
    }
}
