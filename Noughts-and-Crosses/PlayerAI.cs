using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noughts_and_Crosses
{
    internal class PlayerAI : Player
    {
        public PlayerAI(AI engine, string name) : base(name)
        {
            AIEngine = engine;
        }

        public AI AIEngine { get; }


        public override Turn PlayTurn(BoardPosition CurrentBoard, int turn, int turnNumber)
        {
            //base.PlayTurnBase(CurrentBoard, turn);

            int[] AIMove = AIEngine.PlayTurn(CurrentBoard, turn);
            return new Turn(this, CurrentBoard, CurrentBoard.MakeMove(AIMove[0], AIMove[1], turn), AIMove[0], AIMove[1], turnNumber);
        }

        public override void LogDiagnostics()
        {
            base.LogDiagnosticsBase();
            Console.WriteLine("Working perfectly :)");
        }

        public override void Reinforce(Game g)
        {
            // nothing to see here ;)
        }
    }
}
