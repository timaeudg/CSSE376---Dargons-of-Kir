using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Dargons_of_Kir
{
    public class WarTentTile
    {
        private Player owner;
        private Board.location pos;

        public static Image getPic()
        {
            return Image.FromFile("..\\..\\..\\..\\images\\Tent.png");
        }
 
        public WarTentTile(Player player, Board.location pos)
        {
            this.owner = player;
            this.pos = pos;
        }


    }
}
