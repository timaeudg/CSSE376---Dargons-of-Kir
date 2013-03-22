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
            this.Priority = 0;
        }

        public LotusPondTile(int id)
        {
            this.ID = id;
        }

        override public bool callback()
        {
            return true;
        }
    }
}
