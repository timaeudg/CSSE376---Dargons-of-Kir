using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dargons_of_Kir
{
    public class Board
    {
        public enum direction { LEFT, UP, RIGHT, DOWN };
        public class location {
            private int _x;
            private int _y;
             public int x {
                 get { return _x; }
                 set {
                     if (value > 7) value = value % 8;
                     while (value < 0) value = value + 8;
                     _x = value;
                 } }
            public int y { 
                get { return _y; } 
                set {
                     if (value > 7) value = value % 8;
                     while (value < 0) value = value + 8;
                     _y = value;
                 }
            }
            public location(int newX, int newY)
            {
                x = newX;
                y = newY;
            }
        };

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

        public BoardLocation this[Board.location k]
        {
            get { return board[k.x,k.y]; }
            set { board[k.x,k.y] = value; }
        }

        public BoardLocation this[int x, int y]
        {
            get { return board[x, y]; }
            set { board[x, y] = value; }
        }

        public bool addTile(Tile tile)
        {
            
            if (this[tile.location].tile == null)
            {
                this[tile.location].tile = tile;
            }
            else
            {
                return false;
            }
            return true;
        }

        public void destroyTile(Board.location loc)
        {
            Tile removed = this[loc].tile;
            this[loc].tile = null;
            List<Effect> effectsToRemove = new List<Effect>();
            for (int i = 0; i < 8; i++)
            {

                for (int k = 0; k < 8; k++)
                {
                    foreach (Effect e in this[loc].effects)
                    {
                        if (e.parent.Equals(removed))
                        {
                            effectsToRemove.Add(e);
                        }
                    }
                    foreach (Effect e in effectsToRemove)
                    {
                        this[loc].effects.Remove(e);
                    }
                }
            }
        }
    }
}
