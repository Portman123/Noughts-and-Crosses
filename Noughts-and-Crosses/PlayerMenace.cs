using System;

namespace Noughts_and_Crosses
{
    internal class PlayerMenace : Player
    {
        public PlayerMenace(MENACE engine, string name) : base(name)
        {
            AI = engine;
        }

        public MENACE AI { get; }

        public override Turn PlayTurn(BoardPosition CurrentBoard, int turn, int turnNumber)
        {
            //base.PlayTurnBase(CurrentBoard, turn);

            int[] AIMove = AI.PlayTurn(CurrentBoard, turn);
            return new Turn(this, CurrentBoard, CurrentBoard.MakeMove(AIMove[0], AIMove[1], turn), AIMove[0], AIMove[1], turnNumber);
        }

        public override void LogDiagnostics()
        {
            base.LogDiagnosticsBase();

            Console.Write("Number of Nodes: ");
            Console.Write(AI.NumOfMatchboxes());
            Console.WriteLine("");
            Console.Write("Number of Moves: ");
            Console.Write(AI.NumOfMoves());
            //Console.ReadKey();
        }

        public void Reward(GameHistory game)
        {
            AI.Reward(game, Name);
        }

        public void Punish(GameHistory game)
        {
            AI.Punish(game, Name);
        }

    }
}
