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
        private BoardLocation[,] board;

        public Board()
        {
            board = new BoardLocation[8, 8];

        }

        public BoardLocation[,] getBoard()
        {
            return this.board;
        }

        public Tile getTileAt(int x, int y)
        {
            return this.board[x,y].getTile();
        }

        public bool addPiece(Tile tile, orientation orientation, location loc)
        {
            tile.setOrientation(orientation);
            if (board[loc.x, loc.y].getTile() == null)
            {
                board[loc.x, loc.y].setTile(tile);
            }
            else
            {
                return false;
            }
            return true;
        }
    }
}
