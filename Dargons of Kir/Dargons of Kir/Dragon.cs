using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dargons_of_Kir
{
    public class Dragon
    {
        private int dragondID;
        private BoardLocation currentPosition;
        private Board.orientation orientation;
        private int previousEffectTileId;
        public Dragon(int id, BoardLocation startingLocation, Board.orientation rotation)
        {
            this.dragondID = id;
            this.currentPosition = startingLocation;
            this.orientation = rotation;
            this.previousEffectTileId = -1;
        }

        public int getDragonID()
        {
            return this.dragondID;
        }


    }
}
