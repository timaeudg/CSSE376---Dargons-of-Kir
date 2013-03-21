using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dargons_of_Kir
{
    public interface Tile
    {
        private System.Drawing.Image TilePicture;
        private Board.orientation orientation;
        private Board.location location;

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
