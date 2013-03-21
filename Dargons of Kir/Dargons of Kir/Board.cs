using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dargons_of_Kir
{
    class Board
    {
        public enum orientation { LEFT, UP, RIGHT, DOWN };
        public struct location { int x; int y; };

        public bool addPiece(Tile tile, orientation orientation);
    }
}
