using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Dargons_of_Kir.Tiles
{
    public class WarTentTile : Tile
    {
        private Player player;
        private static Image getPic()
        {
            return Image.FromFile("..\\..\\..\\..\\images\\redtent.JPG");
        }
        public WarTentTile(Player playerIn)
            : base(getPic())
        {
            this.Priority = 0;
            this.player = playerIn;
        }

        public WarTentTile(int id)
        {
            this.ID = id;
        }

        override public bool callback()
        {
            return true;
        }
    }
}