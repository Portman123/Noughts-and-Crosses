using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noughts_and_Crosses
{
    internal class Matchbox
    {
        // Matchbox ID
        public BoardPosition BoardPosition { get; }

        public LinkedList<Bead> Beads { get; }

        public int NumOfBeads { get; set; }

        // Constructors
        public Matchbox(BoardPosition boardPosition)
        {
            BoardPosition = boardPosition;
            Beads = new LinkedList<Bead>();
            
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (BoardPosition.Coords[i, j] == 0)
                    {
                        Beads.AddLast(new Bead(i, j));
                        NumOfBeads++;   // Since this is a new matchbox there will be one instance of each bead
                    }
                }
            }
        }

        public Bead GetBead(int x, int y)
        {
            foreach (Bead b in Beads)
            {
                if (b.X == x && b.Y == y) return b;
            }
            return null;
        }

        //This is where I'm starting to see I need a coordinate object
        public int[] Shake(int turn)
        {
            // !!!!START TEMPORARY!!!!
            NumOfBeads = 0;
            foreach (Bead b in Beads)
            {
                NumOfBeads += b.Count;
            }
            // !!!!END TEMPORARY!!!!

            // Generate random number
            Random rnd = new Random();
            int randomNumber = rnd.Next(1, NumOfBeads);

            // Determine which move the random number points to
            int count = 0;
            foreach (Bead move in Beads)
            {
                count += move.Count;
                if (randomNumber <= count) return new int[] {move.X, move.Y};
            }
            throw new Exception("Something went wrong while MENACE was picking it's next move.");
        }

        public void Reward(int x, int y, int amount)
        {
            foreach (Bead b in Beads)
            {
                if (b.X == x && b.Y == y)
                {
                    for (int i = 0; i < amount; i++)
                    {
                        b.Double();
                    }
                }
            }
        }

        public void Punish(int x, int y, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                // Messy code needs cleaning up
                bool safe = true;
                foreach (Bead b in Beads)
                {
                    if (b.Count >= 238609294) safe = false;
                }

                if (safe)
                {
                    foreach (Bead b in Beads)
                    {
                        b.Double();
                    }
                    foreach (Bead b in Beads)
                    {
                        if (b.X == x && b.Y == y) b.Half();
                    }
                }
            }
        }
    }
}
