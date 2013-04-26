using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Dargons_of_Kir.Tiles;

namespace Dargons_of_Kir
{
    public class Dragon
    {
        public class movement
        {
            public Board.direction moveFrom;
            public Board.direction facing;
        }
        public Board.location position { get; private set; }
        public Board.direction orientation { get; private set; }
        private Image _image;
        public Image image 
        {
            get
            {
                //Ensure we are returning a correctly rotated image
                System.Drawing.Image temp;
                switch (this.orientation)
                {
                    case (Board.direction.UP):
                        temp = this._image; break;
                    case (Board.direction.LEFT):
                        temp = (System.Drawing.Image)this._image.Clone();
                        temp.RotateFlip(RotateFlipType.Rotate90FlipX); break;
                    case (Board.direction.DOWN):
                        temp = (System.Drawing.Image)this._image.Clone();
                        temp.RotateFlip(RotateFlipType.RotateNoneFlipY); break;
                    default:
                        temp = (System.Drawing.Image)this._image.Clone();
                        temp.RotateFlip(RotateFlipType.Rotate90FlipNone); break;
                }
                return temp;
            }
            set {_image = value;}
        }
        private static int id = 0;

        public class trueposition
        {
            private Board.location location;
            private Board.direction orientation;

            public trueposition(Board.location location, Board.direction orientation)
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

        public Dragon(int id, Board.location startingLocation, Board.direction rotation)
        {
            switch (Dragon.id++ % 4)
            {
                case (0): { image = Image.FromFile("..\\..\\..\\..\\images\\bluedragon.jpg"); break; }
                case (1): { image = Image.FromFile("..\\..\\..\\..\\images\\reddragon.jpg"); break; }
                case (2): { image = Image.FromFile("..\\..\\..\\..\\images\\greendragon.jpg"); break; }
                case (3): { image = Image.FromFile("..\\..\\..\\..\\images\\yellowdragon.jpg"); break; }
                default: { image = Image.FromFile("..\\..\\..\\..\\images\\blue.png"); break; }
            }
            this.position = startingLocation;
            this.orientation = rotation;
        }

        public List<Tile> move(Board board)
        {
            List<trueposition> PathList = new List<trueposition>();
            List<Tile> toRemove = new List<Tile>();
            List<Tile> toIgnore = new List<Tile>();
            bool movedSideways = false;
            Board.location prevLoc = this.position;
            Board.direction prevOrient = this.orientation;
            Type tileType = null;
            bool effectNotImpact = false;

            switch (this.orientation)
            {
                case Board.direction.UP: this.position.y--; break;
                case Board.direction.RIGHT: this.position.x++; break;
                case Board.direction.DOWN: this.position.y++; break;
                case Board.direction.LEFT: this.position.x--; break;
            }
//            PathList.Add(new trueposition(this.currentPosition, this.orientation));  
            Effect currentEffect = board[position].getActiveEffect(this.orientation,toIgnore);

            if (board[position].tile != null)
            {
                tileType = board[position].tile.GetType();
            }
            bool isImpact = (tileType == typeof(MonkTile) || tileType == typeof(SingleRiverTile) || tileType == typeof(TwoRiversTile) || tileType == typeof(ThreeRiversTile) || tileType == typeof(RoninTile) || tileType == typeof(SamuraiTile));

            if (tileType != null)
            {
                if (!isImpact)
                {
                    toRemove.Add(board[position].tile);
                }
                else
                {
                    effectNotImpact = currentEffect == null;
                    if (!effectNotImpact)
                    {
                        effectNotImpact = currentEffect.parent != board[position].tile;
                    }
                    if (movedSideways || effectNotImpact)
                    {
                        toRemove.Add(board[position].tile);
                    }
                }
            }


            prevOrient = this.orientation;
            prevLoc = this.position;

            if (currentEffect != null)
            {
                //Apply the Effect
                // TODO Apply new Effects properly
                toIgnore.Add(currentEffect.parent);
            }
            movedSideways = this.checkIfMovedSideways(prevLoc, this.position, prevOrient, this.orientation);

            while (currentEffect != null)
            {
                
               // if (PathList.Contains(new trueposition(this.currentPosition, this.orientation)))
               if(new trueposition(this.position, this.orientation).alreadyVisited(PathList))
                {
                    PathList.Clear();
                    return toRemove;
                }
                else
                {
                    PathList.Add(new trueposition(this.position, this.orientation));
                }

                currentEffect = board[position].getActiveEffect(this.orientation,toIgnore);

                if (toIgnore.Count > 1) toIgnore.RemoveAt(0);
                if (currentEffect != null && currentEffect.parent != null) toIgnore.Add(currentEffect.parent); 
                tileType = null;
                if (board[position].tile != null)
                {
                    tileType = board[position].tile.GetType();
                }

                isImpact = (tileType == typeof(MonkTile) || tileType == typeof(SingleRiverTile) || tileType == typeof(TwoRiversTile) || tileType == typeof(ThreeRiversTile) || tileType == typeof(RoninTile) || tileType == typeof(SamuraiTile));

                if (tileType != null)
                {
                    if (!isImpact)
                    {
                        toRemove.Add(board[position].tile);
                    }
                    else
                    {
                        effectNotImpact = currentEffect == null;
                        if (!effectNotImpact)
                        {
                            effectNotImpact = currentEffect.parent != board[position].tile;
                        }
                        if (movedSideways || effectNotImpact)
                        {
                            toRemove.Add(board[position].tile);
                        }
                    }
                }

                prevLoc = this.position;
                prevOrient = this.orientation;

                if (currentEffect == null)
                {
                    break;
                }

                // TODO apply effect

                movedSideways = this.checkIfMovedSideways(prevLoc, this.position, prevOrient, this.orientation);

            }

            //PathList.Clear();
            return toRemove;

        }

        public bool checkIfMovedSideways(Board.location prev, Board.location current, Board.direction prevOrient, Board.direction currentOrient)
        {
            bool movedSideways = false;
            if (prevOrient == currentOrient)
            {
                //This means that at some point, the dragon was moved without being turned, and as such, should be checked to see if it moved sideways
                if (this.orientation == Board.direction.UP || this.orientation == Board.direction.DOWN)
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
