using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dargons_of_Kir
{
    class Player
    {
        ArrayList tiles = new ArrayList();
        public Player()
        {
            this.drawTile();
            this.drawTile();
            this.drawTile();
            this.drawTile();
        }
        internal void takeTurn()
        {
            throw new NotImplementedException();
        }
        internal void drawTile()
        {
            // tiles.Add(pile.draw());
            // this will be fixed when devon tells me what frack is storing our tiles.
        }

    }
}