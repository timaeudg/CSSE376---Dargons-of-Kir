using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Dargons_of_Kir
{
     
    
    class GameInfo
    {
        private List<Tile> pileOfTiles;
        private Tile[,] tileBoard = new Tile[8,8];
        private LinkedList<Dragon> dragons = new LinkedList<Dragon>();

        public GameInfo()
        {


        }

        public List<Tile> getTilePile()
        {
            return this.pileOfTiles;
        }

    }
}
