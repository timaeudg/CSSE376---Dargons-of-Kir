using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dargons_of_Kir
{
    public abstract class Tile
    {
        public System.Drawing.Image TilePicture;
        public Board.orientation orientation;
        public Board.location location;
        public int Priority;
        protected int ID;
        private static int nextID;
        public static bool Drawable { get; protected set;}

        public Tile()
        {
            Tile.Drawable = true;
            ID = Tile.genID();
            orientation = Board.orientation.UP;
        }

        public Tile(System.Drawing.Image pic):this()
        {
            this.TilePicture = pic;
        }

        public System.Drawing.Image getPicture()
        {
            return this.TilePicture;
        }

        public abstract bool callback();

        public void place(Board.location location, Board.orientation orientation) {
            this.location = location;
            this.setOrientation(orientation);
        
        }

        public int getID()
        {
            return this.ID;
        }

        public void setOrientation(Board.orientation rot)
        {
            this.orientation = rot;
        }

        protected static int genID()
        {
            int ret = Tile.nextID;
            Tile.nextID = Tile.nextID + 1;
            return ret;
        }

    }
}
