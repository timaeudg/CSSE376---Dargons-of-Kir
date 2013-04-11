using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Dargons_of_Kir.Tiles
{
    public class LotusFlowerTile: Tile
    {
        private static Image getPic(){
             return Image.FromFile("..\\..\\..\\..\\images\\lotusflower.JPG");
        }
        public LotusFlowerTile() : base(getPic())
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
            switch (this.orientation)
            {
                case Board.orientation.UP:
                    toAdd.Add(new Effect(Board.makeBoardLocation(this.location.x, this.location.y), Board.orientation.LEFT, Board.orientation.LEFT, 1, 2, this.ID, this.callback));
                    toAdd.Add(new Effect(Board.makeBoardLocation(this.location.x, this.location.y - 1), Board.orientation.LEFT, Board.orientation.LEFT, 2, 2, this.ID, this.callback));
                    toAdd.Add(new Effect(Board.makeBoardLocation(this.location.x, this.location.y), Board.orientation.RIGHT, Board.orientation.RIGHT, 1, 2, this.ID, this.callback));
                    toAdd.Add(new Effect(Board.makeBoardLocation(this.location.x, this.location.y - 1), Board.orientation.RIGHT, Board.orientation.RIGHT, 2, 2, this.ID, this.callback));
                    toAdd.Add(new Effect(Board.makeBoardLocation(this.location.x, this.location.y), Board.orientation.DOWN, Board.orientation.DOWN, 1, 2, this.ID, this.callback));
                    toAdd.Add(new Effect(Board.makeBoardLocation(this.location.x, this.location.y - 1), Board.orientation.DOWN, Board.orientation.DOWN, 2, 2, this.ID, this.callback));
                    break;
                case Board.orientation.DOWN:
                    toAdd.Add(new Effect(Board.makeBoardLocation(this.location.x, this.location.y), Board.orientation.LEFT, Board.orientation.LEFT, 1, 2, this.ID, this.callback));
                    toAdd.Add(new Effect(Board.makeBoardLocation(this.location.x, this.location.y + 1), Board.orientation.LEFT, Board.orientation.LEFT, 2, 2, this.ID, this.callback));
                    toAdd.Add(new Effect(Board.makeBoardLocation(this.location.x, this.location.y), Board.orientation.RIGHT, Board.orientation.RIGHT, 1, 2, this.ID, this.callback));
                    toAdd.Add(new Effect(Board.makeBoardLocation(this.location.x, this.location.y + 1), Board.orientation.RIGHT, Board.orientation.RIGHT, 2, 2, this.ID, this.callback));
                    toAdd.Add(new Effect(Board.makeBoardLocation(this.location.x, this.location.y), Board.orientation.UP, Board.orientation.UP, 1, 2, this.ID, this.callback));
                    toAdd.Add(new Effect(Board.makeBoardLocation(this.location.x, this.location.y + 1), Board.orientation.UP, Board.orientation.UP, 2, 2, this.ID, this.callback));
                    break;
                case Board.orientation.RIGHT:
                    toAdd.Add(new Effect(Board.makeBoardLocation(this.location.x, this.location.y), Board.orientation.LEFT, Board.orientation.LEFT, 1, 2, this.ID, this.callback));
                    toAdd.Add(new Effect(Board.makeBoardLocation(this.location.x - 1, this.location.y), Board.orientation.LEFT, Board.orientation.LEFT, 2, 2, this.ID, this.callback));
                    toAdd.Add(new Effect(Board.makeBoardLocation(this.location.x, this.location.y), Board.orientation.DOWN, Board.orientation.DOWN, 1, 2, this.ID, this.callback));
                    toAdd.Add(new Effect(Board.makeBoardLocation(this.location.x - 1, this.location.y), Board.orientation.DOWN, Board.orientation.DOWN, 2, 2, this.ID, this.callback));
                    toAdd.Add(new Effect(Board.makeBoardLocation(this.location.x, this.location.y), Board.orientation.UP, Board.orientation.UP, 1, 2, this.ID, this.callback));
                    toAdd.Add(new Effect(Board.makeBoardLocation(this.location.x - 1, this.location.y), Board.orientation.UP, Board.orientation.UP, 2, 2, this.ID, this.callback));
                    break;
                case Board.orientation.LEFT:
                    toAdd.Add(new Effect(Board.makeBoardLocation(this.location.x, this.location.y), Board.orientation.RIGHT, Board.orientation.RIGHT, 1, 2, this.ID, this.callback));
                    toAdd.Add(new Effect(Board.makeBoardLocation(this.location.x - 1, this.location.y), Board.orientation.RIGHT, Board.orientation.RIGHT, 2, 2, this.ID, this.callback));
                    toAdd.Add(new Effect(Board.makeBoardLocation(this.location.x, this.location.y), Board.orientation.DOWN, Board.orientation.DOWN, 1, 2, this.ID, this.callback));
                    toAdd.Add(new Effect(Board.makeBoardLocation(this.location.x - 1, this.location.y), Board.orientation.DOWN, Board.orientation.DOWN, 2, 2, this.ID, this.callback));
                    toAdd.Add(new Effect(Board.makeBoardLocation(this.location.x, this.location.y), Board.orientation.UP, Board.orientation.UP, 1, 2, this.ID, this.callback));
                    toAdd.Add(new Effect(Board.makeBoardLocation(this.location.x - 1, this.location.y), Board.orientation.UP, Board.orientation.UP, 2, 2, this.ID, this.callback));
                    break;
            }
        }
    }
}
