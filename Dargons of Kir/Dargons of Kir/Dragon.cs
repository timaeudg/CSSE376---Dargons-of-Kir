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
        public System.Drawing.Image image;
        public Dragon(int id, Board.location startingLocation, Board.orientation rotation)
        {
            this.dragondID = id;
            this.currentPosition = startingLocation;
            this.orientation = rotation;
            this.previousEffectTileId = -1;
            this.image = System.Drawing.Image.FromFile("..\\..\\..\\..\\images\\reddragon.JPG");
        }

        public int getDragonID()
        {
            return this.dragondID;
        }

        public void setImage(System.Drawing.Image pic)
        {
            this.image = pic;
        }

        public System.Drawing.Image getImage()
        {
            return image;
        }

        public Board.orientation getOrientation()
        {
            return this.orientation;
        }

        public void setOrientation(Board.orientation newOrient)
        {
            this.orientation = newOrient;

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

        public void move()
        {
            switch (this.orientation)
            {
                case Board.orientation.UP: 
                    this.currentPosition.y = (this.currentPosition.y-1)%8;
                    if (this.currentPosition.y == -1) this.currentPosition.y = 7;
                    break;
                case Board.orientation.RIGHT:
                    this.currentPosition.x = (this.currentPosition.x + 1) % 8;
                    break;
                case Board.orientation.DOWN:
                    this.currentPosition.y = (this.currentPosition.y + 1) % 8;
                    break;
                case Board.orientation.LEFT:
                    this.currentPosition.x = (this.currentPosition.x - 1) % 8;
                    if (this.currentPosition.x == -1) this.currentPosition.x = 7;
                    break;
            }

        }
    }
}
