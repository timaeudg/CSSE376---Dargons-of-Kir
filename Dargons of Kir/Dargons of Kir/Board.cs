using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dargons_of_Kir
{
    public class Board
    {
        public enum orientation { LEFT, UP, RIGHT, DOWN };
        public struct location { public int x { get; set; } public int y { get; set; } };

        public bool addPiece(Tile tile, orientation orientation)
        {

            return true;
        }
    }
}
