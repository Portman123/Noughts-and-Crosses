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
            PlayerMenace Menace1 = new PlayerMenace(new AIMenace(), "Menace1");
            PlayerMenace Menace2 = new PlayerMenace(new AIMenace(), "Menace2");
            PlayerAI Rando = new PlayerAI(new AIRandomMove(), "Rando");
            PlayerAI Optimo = new PlayerAI(new AIOptimalMove(), "Optimo");
            Player Human1 = new PlayerHuman("Human1");

            // Training against MENACE Start
            for (int i = 0; i < 10000; i++)
            {
                Console.WriteLine("training");
                Game g = new Game(Menace1, Menace2);
                g.Train();
                for (int j = 0; j < 5; j++)
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
            Console.WriteLine("");
            Console.WriteLine("");

            for (int i=0;i<10000;i++)
            {
                Game h = new Game(Menace1, Human1);
                h.PlayGame();

                Menace1.LogDiagnostics();
                Console.WriteLine("");
                Console.Write("end of game ");
                Console.Write(i+1);
                Console.WriteLine();
            }


            while (true)
            {
                Game h = new Game(Optimo, Human1);

                h.PlayGame();
                Console.WriteLine();
            }


        }
    }
}