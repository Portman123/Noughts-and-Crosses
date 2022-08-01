using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noughts_and_Crosses
{
    internal class Game
    {
        public BoardPosition CurrentBoard { get; set; }
        public GameHistory History { get; }
        public bool Finished { get; set; }
        public Player P1 { get; }
        public Player P2 { get; }
        public Player Winner { get; set; }

        public Game(Player p1, Player p2)
        {
            CurrentBoard = new BoardPosition();
            P1 = p1;
            P2 = p2;
            History = new GameHistory(P1, P2);
            Finished = false;
        }

        public void PlayGame()
        {
            if (Finished) throw new Exception("Cannot play a game that has already Finished!");

            int turnNumber = 1;
            // Game Loop
            while (true)
            {
                // Player 1 turn
                Turn p1Turn = P1.PlayTurn(CurrentBoard, 1, turnNumber);
                CurrentBoard = p1Turn.After;
                History.AddMove(p1Turn);
                CurrentBoard.PrintBoard();
                turnNumber++;

                // Check Game End
                if (CurrentBoard.CheckWin() != 0 || CurrentBoard.BoardFull()) break;

                // Player 2 Turn 
                Turn p2Turn = P2.PlayTurn(CurrentBoard, -1, turnNumber);
                CurrentBoard = p2Turn.After;
                History.AddMove(p2Turn);
                CurrentBoard.PrintBoard();
                turnNumber++;

                // Check Game End
                if (CurrentBoard.CheckWin() != 0 || CurrentBoard.BoardFull()) break;
            }
            CurrentBoard.PrintBoard();
            AnnounceWinner();

            // This could probably be nicer
            Finished = true;
            DetermineWinner();
        }

        public void Train()
        {
            if (Finished) throw new Exception("Cannot play a game that has already Finished!");
            int turnNumber = 1;

            // Game Loop
            while (true)
            {
                // Player 1 turn
                Turn p1Turn = P1.PlayTurn(CurrentBoard, 1, turnNumber);
                CurrentBoard = p1Turn.After;
                History.AddMove(p1Turn);
                turnNumber++;


                // Check Game End
                if (CurrentBoard.CheckWin() != 0 || CurrentBoard.BoardFull()) break;

                // Player 2 Turn 
                Turn p2Turn = P2.PlayTurn(CurrentBoard, -1, turnNumber);
                CurrentBoard = p2Turn.After;
                History.AddMove(p2Turn);
                turnNumber++;


                // Check Game End
                if (CurrentBoard.CheckWin() != 0 || CurrentBoard.BoardFull()) break;
            }
            Finished = true;
            DetermineWinner();
        }

        public void AnnounceWinner()
        {
            // Write winner to console
            if (CurrentBoard.CheckWin() == 1) Console.WriteLine("Player 1 has won");
            else if (CurrentBoard.CheckWin() == -1) Console.WriteLine("Player 2 has won");
            else if (CurrentBoard.CheckWin() == 0) Console.WriteLine("Nobody has won");
            else Console.WriteLine("Something has gone wrong...");
        }

        public void DetermineWinner()
        {
            // Write winner to console
            if (CurrentBoard.CheckWin() == 1) Winner = P1;
            else if (CurrentBoard.CheckWin() == -1) Winner = P2;
            else if (CurrentBoard.CheckWin() == 0) Winner = null;
            else Console.WriteLine("Something has gone wrong...");
        }
    }
}
