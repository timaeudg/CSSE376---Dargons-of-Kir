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
            for (int i = 0; i < 8; i++)
            {
                for (int k = 0; k < 8; k++)
                {
                    board[i, k] = new BoardLocation();
                }
            }
        }

        public BoardLocation[,] getBoard()
        {
            return this.board;
        }

        public static Board.location makeBoardLocation(int x, int y){
            Board.location toReturn = new Board.location();
            int newX = x;
            int newY = y;
            if (x < 0)
            {
                newX = x + 8; //this will end up with 7 if -1, 6 if -2, etc.
            }
            if (y < 0)
            {
                newY = y + 8;
            }
            toReturn.x = newX;
            toReturn.y = newY;

            return toReturn;
        }

        public Tile getTileAt(int x, int y)
        {
            return this.board[x,y].tile;
        }

        public bool addPiece(Tile tile)
        {
            
            if (board[tile.location.x, tile.location.y].tile == null)
            {
                board[tile.location.x, tile.location.y].tile = tile;
            }
            else
            {
                return false;
            }
            return true;
        }

        public void destroyTileAt(int x, int y)
        {
            Tile removed = this.board[x, y].tile;
            this.board[x, y].tile = null;
            List<Effect> effectsToRemove = new List<Effect>();
            for (int i = 0; i < 8; i++)
            {

                for (int k = 0; k < 8; k++)
                {
                    foreach (Effect e in this.board[i, k].getEffectList())
                    {
                        if (e.parentTile.Equals(removed))
                        {

                            effectsToRemove.Add(e);
                        }
                    }
                    foreach (Effect e in effectsToRemove)
                    {
                        this.board[i, k].getEffectList().Remove(e);
                    }
                }

            }


        }

        public List<Effect> getEffectAt(location location)
        {
            return this.board[location.x, location.y].getEffectList();
        }
    }
}
