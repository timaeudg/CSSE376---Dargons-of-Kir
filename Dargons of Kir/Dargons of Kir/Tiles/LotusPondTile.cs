using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Dargons_of_Kir.Tiles
{
    public class LotusPondTile: Tile
    {
         private static Image getPic(){
             return Image.FromFile("..\\..\\..\\..\\images\\lotuspond.JPG");
        }
        public LotusPondTile() : base(getPic())
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

            toAdd1.Add(new Effect(Board.makeBoardLocation(this.location.x, this.location.y), Board.orientation.LEFT, Board.orientation.LEFT, 1, this.Priority, this));
            toAdd2.Add(new Effect(Board.makeBoardLocation(this.location.x, (this.location.y - 1) % 8), Board.orientation.LEFT, Board.orientation.LEFT, 2, this.Priority, this));
            toAdd1.Add(new Effect(Board.makeBoardLocation(this.location.x, this.location.y), Board.orientation.RIGHT, Board.orientation.RIGHT, 1, this.Priority, this));
            toAdd2.Add(new Effect(Board.makeBoardLocation(this.location.x, (this.location.y - 1) % 8), Board.orientation.RIGHT, Board.orientation.RIGHT, 2, this.Priority, this));
            toAdd1.Add(new Effect(Board.makeBoardLocation(this.location.x, this.location.y), Board.orientation.DOWN, Board.orientation.DOWN, 1, this.Priority, this));
            toAdd2.Add(new Effect(Board.makeBoardLocation(this.location.x, (this.location.y - 1) % 8), Board.orientation.DOWN, Board.orientation.DOWN, 2, this.Priority, this));
            board.getEffectAt(Board.makeBoardLocation(this.location.x, (this.location.y - 1) % 8)).AddRange(toAdd1);
            board.getEffectAt(Board.makeBoardLocation(this.location.x, (this.location.y - 2) % 8)).AddRange(toAdd2);
            toAdd1.Clear();
            toAdd2.Clear();
            toAdd1.Add(new Effect(Board.makeBoardLocation(this.location.x, this.location.y), Board.orientation.LEFT, Board.orientation.LEFT, 1, this.Priority, this));
            toAdd2.Add(new Effect(Board.makeBoardLocation(this.location.x, (this.location.y + 1) % 8), Board.orientation.LEFT, Board.orientation.LEFT, 2, this.Priority, this));
            toAdd1.Add(new Effect(Board.makeBoardLocation(this.location.x, this.location.y), Board.orientation.RIGHT, Board.orientation.RIGHT, 1, this.Priority, this));
            toAdd2.Add(new Effect(Board.makeBoardLocation(this.location.x, (this.location.y + 1) % 8), Board.orientation.RIGHT, Board.orientation.RIGHT, 2, this.Priority, this));
            toAdd1.Add(new Effect(Board.makeBoardLocation(this.location.x, this.location.y), Board.orientation.UP, Board.orientation.UP, 1, this.Priority, this));
            toAdd2.Add(new Effect(Board.makeBoardLocation(this.location.x, (this.location.y + 1) % 8), Board.orientation.UP, Board.orientation.UP, 2, this.Priority, this));
            board.getEffectAt(Board.makeBoardLocation(this.location.x, (this.location.y + 1) % 8)).AddRange(toAdd1);
            board.getEffectAt(Board.makeBoardLocation(this.location.x, (this.location.y + 2) % 8)).AddRange(toAdd2);
            toAdd1.Clear();
            toAdd2.Clear();
            toAdd1.Add(new Effect(Board.makeBoardLocation(this.location.x, this.location.y), Board.orientation.LEFT, Board.orientation.LEFT, 1, this.Priority, this));
            toAdd2.Add(new Effect(Board.makeBoardLocation((this.location.x + 1) % 8, this.location.y), Board.orientation.LEFT, Board.orientation.LEFT, 2, this.Priority, this));
            toAdd1.Add(new Effect(Board.makeBoardLocation(this.location.x, this.location.y), Board.orientation.DOWN, Board.orientation.DOWN, 1, this.Priority, this));
            toAdd2.Add(new Effect(Board.makeBoardLocation((this.location.x + 1) % 8, this.location.y), Board.orientation.DOWN, Board.orientation.DOWN, 2, this.Priority, this));
            toAdd1.Add(new Effect(Board.makeBoardLocation(this.location.x, this.location.y), Board.orientation.UP, Board.orientation.UP, 1, this.Priority, this));
            toAdd2.Add(new Effect(Board.makeBoardLocation((this.location.x + 1) % 8, this.location.y), Board.orientation.UP, Board.orientation.UP, 2, this.Priority, this));
            board.getEffectAt(Board.makeBoardLocation((this.location.x + 1) % 8, this.location.y)).AddRange(toAdd1);
            board.getEffectAt(Board.makeBoardLocation((this.location.x + 2) % 8, this.location.y)).AddRange(toAdd2);
            toAdd1.Clear();
            toAdd2.Clear();
            toAdd1.Add(new Effect(Board.makeBoardLocation(this.location.x, this.location.y), Board.orientation.RIGHT, Board.orientation.RIGHT, 1, this.Priority, this));
            toAdd2.Add(new Effect(Board.makeBoardLocation((this.location.x - 1) % 8, this.location.y), Board.orientation.RIGHT, Board.orientation.RIGHT, 2, this.Priority, this));
            toAdd1.Add(new Effect(Board.makeBoardLocation(this.location.x, this.location.y), Board.orientation.DOWN, Board.orientation.DOWN, 1, this.Priority, this));
            toAdd2.Add(new Effect(Board.makeBoardLocation((this.location.x - 1) % 8, this.location.y), Board.orientation.DOWN, Board.orientation.DOWN, 2, this.Priority, this));
            toAdd1.Add(new Effect(Board.makeBoardLocation(this.location.x, this.location.y), Board.orientation.UP, Board.orientation.UP, 1, this.Priority, this));
            toAdd2.Add(new Effect(Board.makeBoardLocation((this.location.x - 1) % 8, this.location.y), Board.orientation.UP, Board.orientation.UP, 2, this.Priority, this));
            board.getEffectAt(Board.makeBoardLocation((this.location.x - 1) % 8, this.location.y)).AddRange(toAdd1);
            board.getEffectAt(Board.makeBoardLocation((this.location.x - 2) % 8, this.location.y)).AddRange(toAdd2);
        }
    }
}
