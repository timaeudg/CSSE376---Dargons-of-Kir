﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Dargons_of_Kir.Tiles;

namespace Dargons_of_Kir
{
    public class Dragon
    {
        private int dragonID;
        private List<trueposition> PathList = new List<trueposition>();
        public Board.location currentPosition { get; private set; }
        public Board.orientation orientation { get; set; }
        private int previousEffectTileId;
        public Image image { get; set; }

        /*
         * Class to keep track of a combination
         * of both the position on the board,
         * and the orientation that a dragon is facing
         * to check for repeats that would indicate a loop 
         * in it's movement.
         */
        public class trueposition
        {
            private Board.location location;
            private Board.orientation orientation;

            public trueposition(Board.location location, Board.orientation orientation)
            {
                this.location = location;
                this.orientation = orientation;
            }

            public bool Equals(trueposition other)
            {
                return (this.location.Equals(other.location) && this.orientation.Equals(other.orientation));
            }

            public Boolean alreadyVisited(List<trueposition> list)
            {
                foreach (trueposition value in list)
                {
                    if (value.Equals(this))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public Dragon(int id, Board.location startingLocation, Board.orientation rotation)
        {
            this.dragonID = id;
            switch (dragonID % 4)
            {
                case (0): { image = Image.FromFile("..\\..\\..\\..\\images\\bluedragon.jpg"); break; }
                case (1): { image = Image.FromFile("..\\..\\..\\..\\images\\reddragon.jpg"); break; }
                case (2): { image = Image.FromFile("..\\..\\..\\..\\images\\greendragon.jpg"); break; }
                case (3): { image = Image.FromFile("..\\..\\..\\..\\images\\yellowdragon.jpg"); break; }
                //This is just for in case something goes wrong, if we ever see that picture, something has gone horribly wrong
                default: { image = Image.FromFile("..\\..\\..\\..\\images\\blue.png"); break; }
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
                //flips and rotates the picture according to the orientation value.
                case (Board.orientation.UP):
                    return this.image;
                case (Board.orientation.LEFT):
                    temp = (System.Drawing.Image)this.image.Clone();
                    temp.RotateFlip(RotateFlipType.Rotate90FlipX);
                    return temp;
                case (Board.orientation.DOWN):
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
            this.previousEffectTileId = id;
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
            List<Tile> toIgnore = new List<Tile>();
            bool movedSideways = false;
            Board.location prevLoc = this.currentPosition;
            Board.orientation prevOrient = this.orientation;
            Type tileType = null;
            bool effectNotImpact = false;

            //Move the dragon forward one according to its current orientation
            switch (this.orientation)
            {
                case Board.orientation.UP:
                    this.currentPosition = Board.makeBoardLocation(this.currentPosition.x, (this.currentPosition.y - 1) % 8);
                    if (this.currentPosition.y == -1) this.currentPosition = Board.makeBoardLocation(this.currentPosition.x, 7);
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
            //Add the current position + orientation to a list to check for loops
            //Also get the current effect that should be affecting the dragon at this time.
            PathList.Add(new trueposition(this.currentPosition, this.orientation));  
            Effect currentEffect = board.getBoard()[this.currentPosition.x, this.currentPosition.y].getActiveEffect(this.orientation,toIgnore);

            if (board.getTileAt(this.currentPosition.x, this.currentPosition.y) != null)
            {
                tileType = board.getTileAt(this.currentPosition.x, this.currentPosition.y).GetType();
            }

            bool isImpact = false;


            if (board.getTileAt(this.currentPosition.x, this.currentPosition.y) != null)
            {
                isImpact = board.getTileAt(this.currentPosition.x, this.currentPosition.y).Priority == 1;
            }

            //if there is a tile
            if (tileType != null)
            {
                //if the tile is not an impact tile
                if (!isImpact)
                {
                    //we need to remove this tile
                    toRemove.Add(board.getTileAt(this.currentPosition.x, this.currentPosition.y));
                }
                else
                {
                    //we need to check and see if the current effect is actually from the tile we're touching
                    effectNotImpact = currentEffect == null;
                    if (!effectNotImpact)
                    {
                        effectNotImpact = currentEffect.parentTile != board.getTileAt(this.currentPosition.x, this.currentPosition.y);
                    }
                    if (movedSideways || effectNotImpact)
                    {
                        //if it isn't or if we moved sideways over a tile, remove it
                        toRemove.Add(board.getTileAt(this.currentPosition.x, this.currentPosition.y));
                    }
                }
            }


            prevOrient = this.orientation;
            prevLoc = this.currentPosition;

            //take the movement associated with the current effect
            if (currentEffect != null)
            {
                this.currentPosition = currentEffect.destination;
                this.orientation = currentEffect.endingOrientaion;
                toIgnore.Add(currentEffect.parentTile);


            }
            //check to see if the dragon has been moved sideways
            movedSideways = this.checkIfMovedSideways(prevLoc, this.currentPosition, prevOrient, this.orientation);

            if (movedSideways)
            {
                if (board.getTileAt(this.currentPosition.x, this.currentPosition.y) != null)
                {
                    toIgnore.Add(board.getTileAt(this.currentPosition.x, this.currentPosition.y));
                }
            }

            
            while (currentEffect != null)
            {
                
               //if a loop is detected, then stop and return, otherwise add the current position and orientation to the list
               if(new trueposition(this.currentPosition, this.orientation).alreadyVisited(PathList))
                {
                    PathList.Clear();
                    return toRemove;
                }
                else
                {
                    PathList.Add(new trueposition(this.currentPosition, this.orientation));
                }

                currentEffect = board.getBoard()[this.currentPosition.x, this.currentPosition.y].getActiveEffect(this.orientation,toIgnore);

                //since we've gotten the effect, we can toss our tiles to ignore, since those are now valid to pay attention to again
                toIgnore = new List<Tile>();
                
                if (currentEffect != null && currentEffect.parentTile != null) toIgnore.Add(currentEffect.parentTile); 
                tileType = null;
                if (board.getTileAt(this.currentPosition.x, this.currentPosition.y) != null)
                {
                    tileType = board.getTileAt(this.currentPosition.x, this.currentPosition.y).GetType();
                }

                if (board.getTileAt(this.currentPosition.x, this.currentPosition.y) != null)
                {
                    isImpact = board.getTileAt(this.currentPosition.x, this.currentPosition.y).Priority == 1;
                }
                else
                {
                    isImpact = false;
                }

                if (tileType != null)
                {
                    if (!isImpact)
                    {
                        toRemove.Add(board.getTileAt(this.currentPosition.x, this.currentPosition.y));
                    }
                    else
                    {
                        effectNotImpact = currentEffect == null;
                        if (!effectNotImpact)
                        {
                            effectNotImpact = currentEffect.parentTile != board.getTileAt(this.currentPosition.x, this.currentPosition.y);
                        }
                        if (movedSideways || effectNotImpact)
                        {
                            if (movedSideways && !effectNotImpact) toIgnore.Add(currentEffect.parentTile);
                            toRemove.Add(board.getTileAt(this.currentPosition.x, this.currentPosition.y));
                        }
                    }
                }

                prevLoc = this.currentPosition;
                prevOrient = this.orientation;

                if (currentEffect == null)
                {
                    break;
                }

                this.currentPosition = currentEffect.destination;
                this.orientation = currentEffect.endingOrientaion;

                movedSideways = this.checkIfMovedSideways(prevLoc, this.currentPosition, prevOrient, this.orientation);

                if (movedSideways)
                {
                    if (board.getTileAt(this.currentPosition.x, this.currentPosition.y) != null)
                    {
                        toIgnore.Add(board.getTileAt(this.currentPosition.x, this.currentPosition.y));
                    }
                }

            }

            //PathList.Clear();
            return toRemove;

        }

        public bool checkIfMovedSideways(Board.location prev, Board.location current, Board.orientation prevOrient, Board.orientation currentOrient)
        {
            bool movedSideways = false;
            //if the orientation is not the same, then obviously, the dragon was not moved sideways
            if (prevOrient == currentOrient)
            {
                //This means that at some point, the dragon was moved without being turned, and as such, should be checked to see if it moved sideways
                if (this.orientation == Board.orientation.UP || this.orientation == Board.orientation.DOWN)
                {
                    if (current.x != prev.x)
                    {
                        movedSideways = true;
                    }
                }
                else
                {
                    if (current.y != prev.y)
                    {
                        movedSideways = true;
                    }
                }
            }
            return movedSideways;

        }
    }
}
