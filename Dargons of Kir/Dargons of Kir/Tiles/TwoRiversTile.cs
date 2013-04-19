using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Dargons_of_Kir.Tiles
{
    public class TwoRiversTile: Tile
    {
        private static Image getPic(){
             return Image.FromFile("..\\..\\..\\..\\images\\tworivers.JPG");
        }
        public TwoRiversTile() : base(getPic())
        {
            this.Priority = 0;
        }

        override public bool callback()
        {
            return true;
        }

        public override void placeEffects(Board board)
        {
            List<Effect> toAdd = new List<Effect>();
            int wrap;
            switch (this.orientation)
            {
                case Board.orientation.UP:
                    toAdd.Add(new Effect(Board.makeBoardLocation(this.location.x, this.location.y + 1), Board.orientation.LEFT, Board.orientation.DOWN, 0, 1, this));
                    toAdd.Add(new Effect(Board.makeBoardLocation(this.location.x, this.location.y + 1), Board.orientation.RIGHT, Board.orientation.DOWN, 0, 1, this));
                    break;
                case Board.orientation.DOWN:
                    wrap = this.location.x - 1;
                    if (wrap == -1)
                    {
                        wrap = 7;
                    }
                    toAdd.Add(new Effect(Board.makeBoardLocation(this.location.x, wrap), Board.orientation.LEFT, Board.orientation.UP, 0, 1, this));
                    toAdd.Add(new Effect(Board.makeBoardLocation(this.location.x, wrap), Board.orientation.RIGHT, Board.orientation.UP, 0, 1, this));
                    break;
                case Board.orientation.LEFT:
                    toAdd.Add(new Effect(Board.makeBoardLocation(this.location.x + 1, this.location.y), Board.orientation.UP, Board.orientation.RIGHT, 0, 1, this));
                    toAdd.Add(new Effect(Board.makeBoardLocation(this.location.x + 1, this.location.y), Board.orientation.DOWN, Board.orientation.RIGHT, 0, 1, this));
                    break;
                case Board.orientation.RIGHT:
                    wrap = this.location.x - 1;
                    if (wrap == -1)
                    {
                        wrap = 7;
                    }
                    toAdd.Add(new Effect(Board.makeBoardLocation(wrap, this.location.y), Board.orientation.UP, Board.orientation.LEFT, 0, 1, this));
                    toAdd.Add(new Effect(Board.makeBoardLocation(wrap, this.location.y), Board.orientation.DOWN, Board.orientation.LEFT, 0, 1, this));
                    break;
            }
            board.getEffectAt(this.location).AddRange(toAdd);
        }
    }
}
