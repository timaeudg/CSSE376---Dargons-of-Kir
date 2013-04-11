using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Dargons_of_Kir.Tiles
{
    public class RoninTile: Tile
    {
        private static Image getPic(){
             return Image.FromFile("..\\..\\..\\..\\images\\ronin.JPG");
        }
        public RoninTile() : base(getPic())
        {
            this.Priority = 0;
        }

        override public bool callback()
        {
            return true;
        }

        public override void placeEffects(Board board)
        {
            List<Effect> list = board.getEffectAt(this.location);
            if (this.orientation == Board.orientation.UP || this.orientation == Board.orientation.DOWN)
            {
                list.Add(new Effect(Board.makeBoardLocation(this.location.x, this.location.y + 1), Board.orientation.DOWN, Board.orientation.UP, 0, 1, this.ID, this.callback));
                list.Add(new Effect(Board.makeBoardLocation(this.location.x, this.location.y - 1), Board.orientation.UP, Board.orientation.DOWN, 0, 1, this.ID, this.callback));
            }
            else
            {
                list.Add(new Effect(Board.makeBoardLocation(this.location.x+1, this.location.y ), Board.orientation.RIGHT, Board.orientation.LEFT, 0, 1, this.ID, this.callback));
                list.Add(new Effect(Board.makeBoardLocation(this.location.x-1, this.location.y ), Board.orientation.LEFT, Board.orientation.RIGHT, 0, 1, this.ID, this.callback));
            }

        }
    }
}
