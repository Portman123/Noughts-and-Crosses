using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noughts_and_Crosses
{
    internal class AIOptimalMove : AI
    {
        public static LinkedList<int[,]> WinningPositions = new LinkedList<int[,]> ();

        public AIOptimalMove()
        {
            // Top Row
            WinningPositions.AddLast(new int[,] { { 0, 0 }, { 0, 1 }, { 0, 2 } });
            // Middle Row
            WinningPositions.AddLast(new int[,] { { 1, 0 }, { 1, 1 }, { 1, 2 } });
            // Bottom Row
            WinningPositions.AddLast(new int[,] { { 2, 0 }, { 2, 1 }, { 2, 2 } });
            // Left Column
            WinningPositions.AddLast(new int[,] { { 0, 0 }, { 1, 0 }, { 2, 0 } });
            // Middle Column
            WinningPositions.AddLast(new int[,] { { 0, 1 }, { 1, 1 }, { 2, 1 } });
            // Right Column
            WinningPositions.AddLast(new int[,] { { 0, 2 }, { 1, 2 }, { 2, 2 } });
            // First Diagonal 
            WinningPositions.AddLast(new int[,] { { 0, 0 }, { 1, 1 }, { 2, 2 } });
            // Second Diagonal
            WinningPositions.AddLast(new int[,] { { 0, 2 }, { 1, 1 }, { 2, 0 } });
        }



        public override int[] PlayTurn(BoardPosition boardPos, int turn)
        {
            int[] winMove = Win(boardPos, turn);
            int[] blockMove = Block(boardPos, turn);

            if (winMove != null) return winMove;// Try to win
            if (blockMove != null) return blockMove;// Try to block
            else
            {
                LinkedList<int[]> available = DetermineAvailableMoves(boardPos);

                // return a random move from those available
                return available.ElementAt(RandomNumberGenerator.Next(available.Count));
            }
        }

        public int[] Win(BoardPosition boardPos, int turn)
        {
            // Determine the winning coordinate
            foreach (var winPos in WinningPositions)
            {
                // Work out if there are any winning positions which can be completed
                int progress = 0;
                int[] winCoord = null;
                for(int i = 0; i < 3; i++)
                {
                    int x = winPos[i, 0];
                    int y = winPos[i, 1];
                    if (boardPos.Coords[x,y] == turn) progress++;
                    else if (boardPos.Coords[x,y] == 0) winCoord = new int[] {x,y}; // take note of which coordinate was available
                }
                if (progress == 2 && winCoord != null) return winCoord;
            }
            return null;
        }

        // NOT WORKING
        public int[] Block(BoardPosition boardPos, int turn)
        {
            // Determine the winning coordinate
            foreach (var winPos in WinningPositions)
            {
                // Work out if there are any winning positions which can be completed
                int progress = 0;
                int[] blockCoord = null;
                for (int i = 0; i < 3; i++)
                {
                    int x = winPos[i, 0];
                    int y = winPos[i, 1];
                    if (boardPos.Coords[x, y] == turn*-1) progress++;
                    else if (boardPos.Coords[x, y] == 0) blockCoord = new int[] { x, y }; // take note of which coordinate was available
                }
                if (progress == 2 && blockCoord != null) return blockCoord;
            }
            return null;
        }

        public LinkedList<int[]> DetermineAvailableMoves(BoardPosition boardPos)
        {
            // return a list of available moves to be made
            LinkedList<int[]> available = new LinkedList<int[]>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (boardPos.Coords[i, j] == 0)
                    {
                        available.AddLast(new int[] { i, j });
                    }
                }
            }
            return available;
        }
    }
}
