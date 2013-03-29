using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Dargons_of_Kir
{
    public class WarTentTile : Tile
    {
        public Player owner {get; private set;}
        public Board.location pos { get; private set; }
        new public static bool Drawable { get; private set; }

        private static int x = 0;
        public static Image getPic()
        {
            if(x++ == 0)
            {
                return Image.FromFile("..\\..\\..\\..\\images\\bluetent.jpg");
            } else {
                return Image.FromFile("..\\..\\..\\..\\images\\redtent.jpg");
            }
        }
 
        public WarTentTile(Player player, Board.location pos): base(getPic())
        {
            WarTentTile.Drawable = false;
            this.owner = player;
            this.pos = pos;
        }

        override public bool getDrawable()
        {
            return WarTentTile.Drawable;
        }

        public WarTentTile(): base(getPic())
        {
            this.owner = null;
            this.pos = new Board.location();
        }

        public override bool callback()
        {
            return true;
        }


    }
}
