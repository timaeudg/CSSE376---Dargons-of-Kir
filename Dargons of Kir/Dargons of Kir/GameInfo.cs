using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Dargons_of_Kir
{
     
    
    public class GameInfo
    {
        private List<Tile> pileOfTiles;
        private Tile[,] tileBoard;
        private LinkedList<Dragon> dragons;

        public GameInfo()
        {
            this.pileOfTiles = new List<Tile>();
            this.tileBoard = new Tile[8, 8];
            this.dragons = new LinkedList<Dragon>();

        }

        public List<Tile> getTilePile()
        {
            return this.pileOfTiles;
        }

        public LinkedList<Dragon> getDragons()
        {
            return this.dragons;
        }

        public Tile[,] getTileBoard()
        {
            return this.tileBoard;
        }

    }
}
