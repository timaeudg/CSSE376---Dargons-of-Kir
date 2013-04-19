using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Dargons_of_Kir.Tiles
{
    public class SingleRiverTile: Tile
    {
        private static Image getPic(){
             return Image.FromFile("..\\..\\..\\..\\images\\singleriver.JPG");
        }
        public SingleRiverTile() : base(getPic())
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
            if (this.orientation == Board.orientation.UP || this.orientation == Board.orientation.DOWN)
            {
                toAdd.Add(new Effect(Board.makeBoardLocation((this.location.x - 1) % 8, this.location.y), Board.orientation.LEFT, Board.orientation.LEFT, 0, 1, this));
                toAdd.Add(new Effect(Board.makeBoardLocation((this.location.x + 1) % 8, this.location.y), Board.orientation.RIGHT, Board.orientation.RIGHT, 0, 1, this));
            }
            if (this.orientation == Board.orientation.LEFT || this.orientation == Board.orientation.RIGHT)
            {
                toAdd.Add(new Effect(Board.makeBoardLocation(this.location.x, (this.location.y - 1) % 8), Board.orientation.UP, Board.orientation.UP, 0, 1, this));
                toAdd.Add(new Effect(Board.makeBoardLocation(this.location.x, (this.location.y + 1) % 8), Board.orientation.DOWN, Board.orientation.DOWN, 0, 1, this));
            }

            board.getEffectAt(this.location).AddRange(toAdd);
        }
      
    }
}
