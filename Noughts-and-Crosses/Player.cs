using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noughts_and_Crosses
{
    abstract class Player
    {
        public string Name { get; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }

        public Player(string name)
        {
            Name = name;
            Wins = 0;
            Draws = 0;
            Losses = 0;
        }


        public abstract Turn PlayTurn(BoardPosition CurrentBoard, int turn, int turnNumber);
        public abstract void LogDiagnostics();
        public abstract void Reinforce(Game g);


        protected void LogDiagnosticsBase()
        {
            Console.WriteLine("");
            Console.WriteLine("-------------------------");
            Console.WriteLine("");
            Console.Write(Name);
            Console.Write(" DIAGNOSTICS");
            Console.WriteLine("");
        }

        protected void PlayTurnBase(BoardPosition CurrentBoard, int turn)
        {
            Console.WriteLine("");
            Console.Write(Name);
            Console.Write("'s Turn: ");
            Console.WriteLine("");
        }
    }
}
