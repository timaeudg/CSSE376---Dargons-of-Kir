using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dargons_of_Kir
{
    public class Dragon
    {
        private int dragondID;
        private Board.location currentPosition;
        private Board.orientation orientation;
        private int previousEffectTileId;
        public Dragon(int id, Board.location startingLocation, Board.orientation rotation)
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

        public Board.orientation getOrientation()
        {
            return this.orientation;
        }


        public void setPreviousTile(int id)
        {
            this.previousEffectTileId = id ;
        }

        public int getPreviousTile()
        {
            return this.previousEffectTileId;
        }

        public Board.location getCurrentPosition()
        {
            return this.currentPosition;
        }
    }
}
