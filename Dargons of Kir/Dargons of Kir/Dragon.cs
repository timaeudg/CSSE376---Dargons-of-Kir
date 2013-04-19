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
            this.currentPosition = startingLocation;
            this.orientation = rotation;
            this.previousEffectTileId = -1;
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
             System.Drawing.Image temp;

            switch (this.orientation)
            {
                case(Board.orientation.UP):
                    return this.image;
                case(Board.orientation.LEFT):
                    temp = (System.Drawing.Image)this.image.Clone();
                    temp.RotateFlip(RotateFlipType.Rotate90FlipX);
                    return temp;
                case(Board.orientation.DOWN):
                    temp = (System.Drawing.Image)this.image.Clone();
                    temp.RotateFlip(RotateFlipType.RotateNoneFlipY);
                    return temp;
                default:
                    temp = (System.Drawing.Image)this.image.Clone();
                    temp.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    return temp;

            }

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

        public List<Tile> move(Board board)
        {
            List<Tile> toRemove = new List<Tile>();
            switch (this.orientation)
            {
                case Board.orientation.UP: 
                    this.currentPosition = Board.makeBoardLocation(this.currentPosition.x, (this.currentPosition.y-1)%8);
                    if (this.currentPosition.y == -1) this.currentPosition = Board.makeBoardLocation(this.currentPosition.x,7);
                    break;
                case Board.orientation.RIGHT:
                    this.currentPosition = Board.makeBoardLocation((this.currentPosition.x + 1) % 8, this.currentPosition.y);
                    break;
                case Board.orientation.DOWN:
                    this.currentPosition = Board.makeBoardLocation(this.currentPosition.x, (this.currentPosition.y + 1) % 8);
                    break;
                case Board.orientation.LEFT:
                    this.currentPosition = Board.makeBoardLocation((this.currentPosition.x - 1) % 8, this.currentPosition.y);
                    if (this.currentPosition.x == -1) this.currentPosition = Board.makeBoardLocation(7, this.currentPosition.y);
                    break;
            }
            Effect currentEffect = board.getBoard()[this.currentPosition.x, this.currentPosition.y].getActiveEffect(this.orientation); 
            while(currentEffect != null)
            {
                this.currentPosition = currentEffect.destination;
                this.orientation = currentEffect.endingOrientaion;
                if(board.getBoard()[this.currentPosition.x, this.currentPosition.y].tile != null)
                {
                    toRemove.Add(board.getBoard()[this.currentPosition.x, this.currentPosition.y].tile);
                }
                currentEffect = board.getBoard()[this.currentPosition.x, this.currentPosition.y].getActiveEffect(this.orientation); 
            }
            if(board.getBoard()[this.currentPosition.x, this.currentPosition.y].tile != null)
            {
                
                toRemove.Add(board.getBoard()[this.currentPosition.x, this.currentPosition.y].tile);
            }
            
            return toRemove;

        }
    }
}
