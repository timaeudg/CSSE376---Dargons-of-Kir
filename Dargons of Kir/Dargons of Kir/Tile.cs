using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dargons_of_Kir
{
    abstract class Tile
    {
        protected System.Drawing.Image TilePicture;
        protected Board.orientation orientation;
        protected Board.location location;

        public Tile()
        {
        }

        public Tile(System.Drawing.Image pic)
        {
            this.TilePicture = pic;
        }

        public System.Drawing.Image getPicture()
        {
            return this.TilePicture;
        }

        public bool callback()
        {
            return true;
        }

    }
}
