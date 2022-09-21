using System;
using System.Collections.Generic;

namespace Noughts_and_Crosses
{
    public class PlayerMenace : PlayerAI
    {
        public PlayerMenace(AIMenace engine, string name) : base(engine, name)
        {
            MenaceEngine = engine;
        }

        public AIMenace MenaceEngine { get; }

        public override Turn PlayTurn(BoardPosition CurrentBoard, int turn, int turnNumber)
        {
            //base.PlayTurnBase(CurrentBoard, turn);

            int[] AIMove = AIEngine.PlayTurn(CurrentBoard, turn);
            return new Turn(this, CurrentBoard, CurrentBoard.MakeMove(AIMove[0], AIMove[1], turn), AIMove[0], AIMove[1], turnNumber);
        }

        public override void Reinforce(Game g)
        {
            MenaceEngine.Reinforce(g, this);
        }

        public override void LogDiagnostics()
        {
            base.LogDiagnosticsBase();

            Console.Write("Number of Matchboxes: ");
            Console.Write(MenaceEngine.NumOfMatchboxes());
            Console.WriteLine("");
            Console.Write("Number of Moves Known: ");
            Console.Write(MenaceEngine.NumOfMoves());
            Console.WriteLine("");
            Console.Write("Number of Beads: ");
            Console.Write(MenaceEngine.NumOfBeads());
            Console.WriteLine("");
            Console.Write("Wins/Draws/Losses: ");
            Console.Write(Wins);
            Console.Write(" / ");
            Console.Write(Draws);
            Console.Write(" / ");
            Console.Write(Losses);
            Console.WriteLine("");
            //Console.ReadKey();
        }

        //public void Reward(GameHistory game)
        //{
        //    Wins++;
        //    MenaceEngine.Reward(game, Name);
        //}

        //public void DrawReward (GameHistory game)
        //{
        //    Draws++;
        //    MenaceEngine.DrawReward(game, Name);
        //}

        //public void Punish(GameHistory game)
        //{
        //    Losses++;
        //    MenaceEngine.Punish(game, Name);
        //}
    }
}
