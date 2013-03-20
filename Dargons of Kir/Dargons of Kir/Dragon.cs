using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dargons_of_Kir
{
    class Dragon
    {
        private int dragondID;
        private int xPosition;
        private int yposition;
        private int orientation;
        public Dragon(int id, int xPos, int yPos, int rotation)
        {
            this.dragondID = id;
            this.xPosition = xPos;
            this.yposition = yPos;
            this.orientation = rotation;

        }

    }
}
