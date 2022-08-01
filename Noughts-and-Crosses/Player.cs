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

        public Player(string name)
        {
            Name = name;
        }

        public abstract Turn PlayTurn(BoardPosition CurrentBoard, int turn, int turnNumber);

        public abstract void LogDiagnostics();

        protected void LogDiagnosticsBase()
        {
            Console.WriteLine("");
            Console.WriteLine("-------------------------");
            Console.WriteLine("");
        }

        protected void PlayTurnBase(BoardPosition CurrentBoard, int turn)
        {
            Console.WriteLine("");
            Console.Write(Name);
            Console.Write("'s Turn: ");
            Console.WriteLine("");
        }

        public static int[] GetUserInput()
        {
            String UserInput = Console.ReadLine();
            if (UserInput == "1") return new int[] { 0, 0 };
            if (UserInput == "2") return new int[] { 0, 1 };
            if (UserInput == "3") return new int[] { 0, 2 };
            if (UserInput == "4") return new int[] { 1, 0 };
            if (UserInput == "5") return new int[] { 1, 1 };
            if (UserInput == "6") return new int[] { 1, 2 };
            if (UserInput == "7") return new int[] { 2, 0 };
            if (UserInput == "8") return new int[] { 2, 1 };
            if (UserInput == "9") return new int[] { 2, 2 };
            return null;
        }
    }
}
