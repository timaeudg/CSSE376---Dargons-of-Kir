using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Dargons_of_Kir
{
    public class Dragon
    {
        private int dragonID;
        public Board.location currentPosition {get; private set; }
        public Board.orientation orientation {get; private set; }
        private int previousEffectTileId;
        public Image image { get; set; }

        public Dragon(int id, Board.location startingLocation, Board.orientation rotation)
        {
            this.dragonID = id;
            switch(dragonID % 4) {
                case (0) : { image = Image.FromFile("..\\..\\..\\..\\images\\bluedragon.jpg"); break; }
                case (1) : { image = Image.FromFile("..\\..\\..\\..\\images\\reddragon.jpg"); break; }
                case (2) : { image = Image.FromFile("..\\..\\..\\..\\images\\greendragon.jpg"); break; }
                case (3) : { image = Image.FromFile("..\\..\\..\\..\\images\\yellowdragon.jpg"); break; }
                default  : { image = Image.FromFile("..\\..\\..\\..\\images\\blue.png"); break; }
            }
            currentPosition = startingLocation;
            this.orientation = rotation;
            this.previousEffectTileId = -1;
            this.image = System.Drawing.Image.FromFile("..\\..\\..\\..\\images\\reddragon.JPG");
        }

        public int getDragonID()
        {
            return this.dragonID;
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
                   currentPosition.y = (currentPosition.y-1)%8;
                    if (this.currentPosition.y == -1) currentPosition.y = 7;
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
