using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dargons_of_Kir
{
    public abstract class Tile
    {
        protected System.Drawing.Image TilePicture;
        protected Board.orientation orientation;
        protected Board.location location;
        protected int Priority;
        protected int ID;

        public Tile()
        {
        }

        public Tile(int id)
        {
            this.ID = id;
        }


        public Tile(System.Drawing.Image pic)
        {
            this.TilePicture = pic;
        }

        public System.Drawing.Image getPicture()
        {
            return this.TilePicture;
        }

        public abstract bool callback();

        public void place(Board.location location, Board.orientation orientation) { return; }

        public int getID()
        {
            return this.ID;
        }

    }
}
