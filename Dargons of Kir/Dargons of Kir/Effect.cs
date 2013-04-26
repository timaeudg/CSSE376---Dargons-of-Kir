using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dargons_of_Kir
{

    public class Effect
    {
        public Board.location[,] moveTo {get; private set;}
        private Board.direction parentIs = 0;
        public Tile parent = null;

        public Effect()
        {
            moveTo = new Board.location[4, 4];
        }

        public bool activateCallback()
        {
            if(parent != null) return this.parent.callback();
            return true;
        }
    }
}
