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
            this.Priority = 0;
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