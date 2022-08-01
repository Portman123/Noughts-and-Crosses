using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Noughts_and_Crosses
{
    internal class MENACE
    {
        // List of all Matchboxes
        public LinkedList<Matchbox> Matchboxes { get; set; }

        // Constructor
        public MENACE()
        {
            Matchboxes = new LinkedList<Matchbox>();
        }


        public void AddMatchbox(BoardPosition newBoardPos)
        {
            /*
            // (pass board position) 
            // check existence before adding
            if (!CheckExistence(newBoardPos))
            {
                Matchboxes.AddLast(new Matchbox(newBoardPos));
                // return true if the matchbox was sucessfully added
            }*/

            Matchboxes.AddLast(new Matchbox(newBoardPos));
        }



        // Find Matchbox/Check Existence in Menace by specifying board position
        public Matchbox MatchboxByBoardPos(BoardPosition boardPosition)
        {
            // If the matchbox exists in MENACE then return it
            foreach (Matchbox box in Matchboxes)
            {
                if (box.BoardPosition.SameAs(boardPosition))
                {
                    return box;
                }
            }
            // Return null if it doesn't
            return null;
        }
        public bool CheckExistence(BoardPosition boardPosition)
        {
            // If the matchbox exists in MENACE then return true
            foreach (Matchbox box in Matchboxes)
            {
                if (box.BoardPosition.SameAs(boardPosition)) return true;
            }
            // Return false if it doesn't
            return false;
        }

        // DIAGNOSTIC METHODS
        //  Returns number of Matchboxes present in MENACE
        public int NumOfMatchboxes()
        {
            return Matchboxes.Count();
        }
        // returns the number of edges present in the graph
        public int NumOfMoves()
        {
            int count = 0;
            foreach (Matchbox box in Matchboxes)
            {
                count += box.Beads.Count;
            }
            return count;
        }

        //This is where I'm starting to see I need a coordinate object
        public int[] PlayTurn(BoardPosition boardPos, int turn)
        {
            // If Menace hasn't encountered this position before
            if (!CheckExistence(boardPos))
            {
                AddMatchbox(boardPos);
                Console.WriteLine("Adding new position to MENACE");
                boardPos.PrintBoard();
            }

            Matchbox box = MatchboxByBoardPos(boardPos);

            return box.Shake(turn);
        }

        public void Reward(GameHistory game, string nameCheck)
        {
            foreach (Turn t in game.TurnHistory)
            {
                if (t.MoveMaker.Name == nameCheck)
                {
                    // This should be broken down into methods that are part of the corresponding classes
                    MatchboxByBoardPos(t.Before).Reward(t.X,t.Y,t.TurnNumber); // This needs to be some function
                }
            }
        }

        public void Punish(GameHistory game, string nameCheck)
        {
            foreach (Turn t in game.TurnHistory)
            {
                // This should be broken down into methods that are part of the corresponding classes
                if (t.MoveMaker.Name == nameCheck)
                {
                    MatchboxByBoardPos(t.Before).Punish(t.X, t.Y,t.TurnNumber);
                }
            }
        }
    }
}
