using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Dargons_of_Kir.Tiles
{
    public class MonkTile: Tile
    {
        private static Image getPic(){
             return Image.FromFile("..\\..\\..\\..\\images\\monk.JPG");
        }
        public MonkTile() : base(getPic())
        {
            this.Priority = 1;
        }

        override public bool callback()
        {
            return true;
        }

        public override void placeEffects(Board board)
        {
            Effect Left = new Effect(Board.makeBoardLocation(this.location.x - 1, this.location.y), Board.orientation.RIGHT, Board.orientation.LEFT, 0, this.Priority, this);
            Effect Right = new Effect(Board.makeBoardLocation(this.location.x + 1, this.location.y), Board.orientation.LEFT, Board.orientation.RIGHT, 0, this.Priority, this);
            Effect Down = new Effect(Board.makeBoardLocation(this.location.x, this.location.y - 1), Board.orientation.DOWN, Board.orientation.UP, 0, this.Priority, this);
            Effect Up = new Effect(Board.makeBoardLocation(this.location.x, this.location.y + 1), Board.orientation.UP, Board.orientation.DOWN, 0, this.Priority, this);

            board.getBoard()[this.location.x, this.location.y].getEffectList().Add(Left);
            board.getBoard()[this.location.x, this.location.y].getEffectList().Add(Right);
            board.getBoard()[this.location.x, this.location.y].getEffectList().Add(Up);
            board.getBoard()[this.location.x, this.location.y].getEffectList().Add(Down);
        }

        
      
    }
}
