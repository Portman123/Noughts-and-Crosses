using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noughts_and_Crosses
{
    internal abstract class Reinforcement
    {
        public abstract void Reinforce(Game g, PlayerMenace menace);
        public abstract void WinReinforcement(Bead b, int turnNumber);

        public abstract void DrawReinforcement(Bead b, int turnNumber);

        public abstract void LossReinforcement(Bead b, int turnNumber);
    }
}
