using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dargons_of_Kir.Tiles
{
    public class JSONTile : Tile
    {
        private static Image getPic()
        {
            return Image.FromFile("..\\..\\..\\..\\images\\storm.JPG");
        }

        public JSONTile()
            : base(getPic())
        {

        }


        override public bool callback()
        {
            return true;
        }

        public override void placeEffects(Board board)
        {
            
        }


    }
}
