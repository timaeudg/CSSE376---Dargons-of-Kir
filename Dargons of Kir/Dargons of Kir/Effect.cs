using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dargons_of_Kir
{

    class Effect
    {
        private Board.location destination;
        private Board.orientation orientation;
        private int distance;
        private int priority;
        private int parentTileID;
        private Func<bool> callback;
    }
}
