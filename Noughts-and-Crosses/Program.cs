using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noughts_and_Crosses
{
    public class Program
    {
        static void Main(string[] args)
        {
            PlayerMenace Menace1 = new PlayerMenace(new AIMenace(), "Menace1");
            PlayerMenace Menace2 = new PlayerMenace(new AIMenace(), "Menace2");
            PlayerAI Rando = new PlayerAI(new AIRandomMove(), "Rando");
            PlayerAI Optimo1 = new PlayerAI(new AIOptimalMove(), "Optimo");
            PlayerAI Optimo2 = new PlayerAI(new AIOptimalMove(), "Optimo");
            Player Human1 = new PlayerHuman("Human1");

            // Training against MENACE Start
            for (int i = 0; i < 10000; i++)
            {
                //Console.WriteLine("training");
                Game g = new Game(Menace1, Menace2);
                g.Train();
                for (int k = 0; k < 5; k++)
                {
                    Game optiTrain1 = new Game(Menace1, Optimo1);
                    Game optiTrain2 = new Game(Optimo2, Menace2);
                    optiTrain1.Train();
                    optiTrain2.Train();
                }
                for (int j = 0; j < 20; j++)
                {
                    Game rand1 = new Game(Menace1, Rando);
                    Game rand2 = new Game(Rando, Menace2);
                    rand1.Train();
                    rand2.Train();
                }
            }
            // Training against MENACE End

            Menace1.LogDiagnostics();
            Menace2.LogDiagnostics();
            Optimo1.LogDiagnostics();
            Optimo2.LogDiagnostics();
            Console.WriteLine("");
            Console.WriteLine("");


            while (true)
            {
                Game h = new Game(Menace1, Human1);
                h.PlayGame();
                Menace1.LogDiagnostics();
            }



            //// Test DetermineIntersections Method
            //AIOptimalMove temp = new AIOptimalMove();
            //if (temp.Intersections.Count == 0) Console.WriteLine("empty");

            //foreach (var Intersect in temp.Intersections)
            //{
            //    BoardPosition board = new BoardPosition();
            //    foreach (var coord1 in Intersect.WinPos1.Coordinates)
            //    {
            //        board = new BoardPosition(board.MakeMove(coord1.X, coord1.Y, 1).Coords);
            //    }
            //    foreach (var coord2 in Intersect.WinPos2.Coordinates)
            //    {
            //        board = new BoardPosition(board.MakeMove(coord2.X, coord2.Y, -1).Coords);
            //    }
            //    board.PrintBoard();
            //}
            //// Test DetermineIntersections Method

            //Console.WriteLine("");
            //Console.WriteLine(temp.Intersections.Count);
            //Console.WriteLine("");


            //for (int i = 0; i < 1000; i++)
            //{
            //    Game h = new Game(Optimo1, Human1);

            //    h.PlayGame();
            //    Console.WriteLine("");
            //}





            // TESTING OPTIMO (should always draw against itself)
            for (int i = 0; i < 100000; i++)
            {
                Game h = new Game(Optimo1, Optimo2);

                h.Train();
                Console.WriteLine("");
            }
            Optimo1.LogDiagnostics();
            Optimo2.LogDiagnostics();
            Console.ReadKey();

        }
    }
}