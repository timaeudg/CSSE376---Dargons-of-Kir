using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Dargons_of_Kir
{
    public class TwoRiversTile: Tile
    {
        private static Image getPic(){
             return Image.FromFile("..\\..\\..\\..\\images\\tworivers.JPG");
        }
        public TwoRiversTile() : base(getPic())
        {
            this.Priority = 0;
        }

        public TwoRiversTile(int id)
        {
            this.ID = id;
        }

        override public bool callback()
        {
            return true;
        }
    }
}
