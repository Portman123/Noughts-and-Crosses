using System;

namespace Noughts_and_Crosses
{
    internal class PlayerHuman : Player
    {
        public PlayerHuman(string name) : base(name)
        {
        }

        public override void LogDiagnostics()
        {
            // Move along please... nothing to see here...
        }

        public override Turn PlayTurn(BoardPosition CurrentBoard, int turn, int turnNumber)
        {
            base.PlayTurnBase(CurrentBoard, turn);

            int[] userInput = GetUserInput();
            return new Turn(this, CurrentBoard, CurrentBoard.MakeMove(userInput[0], userInput[1], turn), userInput[0], userInput[1], turnNumber);
        }
    }
}

