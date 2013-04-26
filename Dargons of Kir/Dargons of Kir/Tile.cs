using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dargons_of_Kir
{
    public abstract class Tile
    {
        public System.Drawing.Image picture { get; private set;}
        public Board.direction orientation;
        public Board.location location;
        public int Priority;
        public static bool Drawable { get; protected set;}

        public Tile()
        {
            Tile.Drawable = true;
            location = new Board.location(0, 0);
            orientation = Board.direction.UP;
        }

        virtual public bool getDrawable(){
            return Tile.Drawable;
        }

        public Tile(System.Drawing.Image pic):this()
        {
            this.picture = pic;
        }

        public abstract bool callback();

        public void place(Board.location location, Board.direction orientation) {
            this.location = location;
            this.orientation = orientation;
        
        }

        public abstract void placeEffects(Board board);

    }
}
