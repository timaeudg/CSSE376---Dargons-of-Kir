using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Dargons_of_Kir.Tiles
{
    public class WatchfireTile: Tile
    {
        private static Image getPic(){
             return Image.FromFile("..\\..\\..\\..\\images\\watchfire.JPG");
        }
        public WatchfireTile() : base(getPic())
        {
            this.Priority = 2;
        }

        override public bool callback()
        {
            return true;
        }

        public override void placeEffects(Board board)
        {
            List<Effect> toAdd1 = new List<Effect>();
            List<Effect> toAdd2 = new List<Effect>();
            switch (this.orientation)
            {
                case Board.orientation.UP:
                    toAdd1.Add(new Effect(Board.makeBoardLocation(this.location.x, (this.location.y - 1) % 8), Board.orientation.UP, Board.orientation.RIGHT, 1, this.Priority, this));
                    toAdd2.Add(new Effect(Board.makeBoardLocation((this.location.x - 1) % 8, this.location.y), Board.orientation.LEFT, Board.orientation.DOWN, 1, this.Priority, this));
                    board.getEffectAt(Board.makeBoardLocation((this.location.x - 1) % 8, this.location.y)).AddRange(toAdd1);
                    board.getEffectAt(Board.makeBoardLocation(this.location.x, (this.location.y - 1) % 8)).AddRange(toAdd2);
                    break;
                case Board.orientation.DOWN:
                    toAdd1.Add(new Effect(Board.makeBoardLocation(this.location.x, (this.location.y + 1) % 8), Board.orientation.DOWN, Board.orientation.LEFT, 1, this.Priority, this));
                    toAdd2.Add(new Effect(Board.makeBoardLocation((this.location.x + 1) % 8, this.location.y), Board.orientation.RIGHT, Board.orientation.UP, 1, this.Priority, this));
                    board.getEffectAt(Board.makeBoardLocation((this.location.x + 1) % 8, this.location.y)).AddRange(toAdd1);
                    board.getEffectAt(Board.makeBoardLocation(this.location.x, (this.location.y + 1) % 8)).AddRange(toAdd2);
                    break;
                case Board.orientation.RIGHT:
                    toAdd1.Add(new Effect(Board.makeBoardLocation(this.location.x, (this.location.y - 1) % 8), Board.orientation.UP, Board.orientation.LEFT, 1, this.Priority, this));
                    toAdd2.Add(new Effect(Board.makeBoardLocation((this.location.x + 1) % 8, this.location.y), Board.orientation.RIGHT, Board.orientation.DOWN, 1, this.Priority, this));
                    board.getEffectAt(Board.makeBoardLocation((this.location.x + 1) % 8, this.location.y)).AddRange(toAdd1);
                    board.getEffectAt(Board.makeBoardLocation(this.location.x, (this.location.y - 1) % 8)).AddRange(toAdd2);
                    break;
                case Board.orientation.LEFT:
                    toAdd1.Add(new Effect(Board.makeBoardLocation(this.location.x, (this.location.y + 1) % 8), Board.orientation.DOWN, Board.orientation.RIGHT, 1, this.Priority, this));
                    toAdd2.Add(new Effect(Board.makeBoardLocation((this.location.x - 1) % 8, this.location.y), Board.orientation.LEFT, Board.orientation.UP, 1, this.Priority, this));
                    board.getEffectAt(Board.makeBoardLocation(this.location.x, (this.location.y + 1) % 8)).AddRange(toAdd2);
                    board.getEffectAt(Board.makeBoardLocation((this.location.x - 1) % 8, this.location.y)).AddRange(toAdd1);
                    break;
            }
        }
    }
}