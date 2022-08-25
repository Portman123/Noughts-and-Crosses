using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noughts_and_Crosses
{
    abstract class AI
    {
        public abstract int[] PlayTurn(BoardPosition boardPos, int turn);
    }
}