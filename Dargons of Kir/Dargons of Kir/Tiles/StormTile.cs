using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Dargons_of_Kir.Tiles
{
    public class StormTile: Tile
    {
        private static Image getPic(){
             return Image.FromFile("..\\..\\..\\..\\images\\storm.JPG");
        }
        public StormTile() : base(getPic())
        {
            this.Priority = 0;
        }

        override public bool callback()
        {
            return true;
        }

        public override void placeEffects(Board board)
        {
            List<Effect> toAdd1 = new List<Effect>();
            List<Effect> toAdd2 = new List<Effect>();
            
            toAdd1.Add(new Effect(Board.makeBoardLocation((this.location.x + 2) % 8, this.location.y), Board.orientation.UP, Board.orientation.UP, 1, 2, this));
            toAdd2.Add(new Effect(Board.makeBoardLocation((this.location.x + 3) % 8, this.location.y), Board.orientation.UP, Board.orientation.UP, 2, 2, this));
            toAdd1.Add(new Effect(Board.makeBoardLocation((this.location.x + 2) % 8, this.location.y), Board.orientation.RIGHT, Board.orientation.RIGHT, 1, 2, this));
            toAdd2.Add(new Effect(Board.makeBoardLocation((this.location.x + 3) % 8, this.location.y), Board.orientation.RIGHT, Board.orientation.RIGHT, 2, 2, this));
            toAdd1.Add(new Effect(Board.makeBoardLocation((this.location.x + 2) % 8, this.location.y), Board.orientation.DOWN, Board.orientation.DOWN, 1, 2, this));
            toAdd2.Add(new Effect(Board.makeBoardLocation((this.location.x + 3) % 8, this.location.y), Board.orientation.DOWN, Board.orientation.DOWN, 2, 2, this));
            board.getEffectAt(Board.makeBoardLocation((this.location.x + 1) % 8, this.location.y)).AddRange(toAdd1);
            board.getEffectAt(Board.makeBoardLocation((this.location.x + 2) % 8, this.location.y)).AddRange(toAdd2);
            toAdd1.Clear();
            toAdd2.Clear();
            toAdd1.Add(new Effect(Board.makeBoardLocation((this.location.x - 2) % 8, this.location.y), Board.orientation.UP, Board.orientation.UP, 1, 2, this));
            toAdd2.Add(new Effect(Board.makeBoardLocation((this.location.x - 3) % 8, this.location.y), Board.orientation.UP, Board.orientation.UP, 2, 2, this));
            toAdd1.Add(new Effect(Board.makeBoardLocation((this.location.x - 2) % 8, this.location.y), Board.orientation.LEFT, Board.orientation.LEFT, 1, 2, this));
            toAdd2.Add(new Effect(Board.makeBoardLocation((this.location.x - 3) % 8, this.location.y), Board.orientation.LEFT, Board.orientation.LEFT, 2, 2, this));
            toAdd1.Add(new Effect(Board.makeBoardLocation((this.location.x - 2) % 8, this.location.y), Board.orientation.DOWN, Board.orientation.DOWN, 1, 2, this));
            toAdd2.Add(new Effect(Board.makeBoardLocation((this.location.x - 3) % 8, this.location.y), Board.orientation.DOWN, Board.orientation.DOWN, 2, 2, this));
            board.getEffectAt(Board.makeBoardLocation((this.location.x - 1) % 8, this.location.y)).AddRange(toAdd1);
            board.getEffectAt(Board.makeBoardLocation((this.location.x - 2) % 8, this.location.y)).AddRange(toAdd2);
            toAdd1.Clear();
            toAdd2.Clear();
            toAdd1.Add(new Effect(Board.makeBoardLocation(this.location.x, (this.location.y + 2) % 8), Board.orientation.RIGHT, Board.orientation.RIGHT, 1, 2, this));
            toAdd2.Add(new Effect(Board.makeBoardLocation(this.location.x, (this.location.y + 3) % 8), Board.orientation.RIGHT, Board.orientation.RIGHT, 2, 2, this));
            toAdd1.Add(new Effect(Board.makeBoardLocation(this.location.x, (this.location.y + 2) % 8), Board.orientation.LEFT, Board.orientation.LEFT, 1, 2, this));
            toAdd2.Add(new Effect(Board.makeBoardLocation(this.location.x, (this.location.y + 3) % 8), Board.orientation.LEFT, Board.orientation.LEFT, 2, 2, this));
            toAdd1.Add(new Effect(Board.makeBoardLocation(this.location.x, (this.location.y + 2) % 8), Board.orientation.DOWN, Board.orientation.DOWN, 1, 2, this));
            toAdd2.Add(new Effect(Board.makeBoardLocation(this.location.x, (this.location.y + 3) % 8), Board.orientation.DOWN, Board.orientation.DOWN, 2, 2, this));
            board.getEffectAt(Board.makeBoardLocation(this.location.x, (this.location.y + 1) % 8)).AddRange(toAdd1);
            board.getEffectAt(Board.makeBoardLocation(this.location.x, (this.location.y + 2) % 8)).AddRange(toAdd2);
            toAdd1.Clear();
            toAdd2.Clear();
            toAdd1.Add(new Effect(Board.makeBoardLocation(this.location.x, (this.location.y - 2) % 8), Board.orientation.RIGHT, Board.orientation.RIGHT, 1, 2, this));
            toAdd2.Add(new Effect(Board.makeBoardLocation(this.location.x, (this.location.y - 3) % 8), Board.orientation.RIGHT, Board.orientation.RIGHT, 2, 2, this));
            toAdd1.Add(new Effect(Board.makeBoardLocation(this.location.x, (this.location.y - 2) % 8), Board.orientation.LEFT, Board.orientation.LEFT, 1, 2, this));
            toAdd2.Add(new Effect(Board.makeBoardLocation(this.location.x, (this.location.y - 3) % 8), Board.orientation.LEFT, Board.orientation.LEFT, 2, 2, this));
            toAdd1.Add(new Effect(Board.makeBoardLocation(this.location.x, (this.location.y - 2) % 8), Board.orientation.UP, Board.orientation.UP, 1, 2, this));
            toAdd2.Add(new Effect(Board.makeBoardLocation(this.location.x, (this.location.y - 3) % 8), Board.orientation.UP, Board.orientation.UP, 2, 2, this));
            board.getEffectAt(Board.makeBoardLocation(this.location.x, (this.location.y - 1) % 8)).AddRange(toAdd1);
            board.getEffectAt(Board.makeBoardLocation(this.location.x, (this.location.y - 2) % 8)).AddRange(toAdd2);
        }
    }
}
