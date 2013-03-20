using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dargons_of_Kir
{
    class Dragon
    {
        private int dragondID;
        private BoardLocation currentPosition;
        private int orientation;
        private int previousEffectTileId;
        public Dragon(int id, BoardLocation startingLocation, int rotation)
        {
            this.dragondID = id;
            this.currentPosition = startingLocation;
            this.orientation = rotation;
            this.previousEffectTileId = -1;
        }

    }
}
