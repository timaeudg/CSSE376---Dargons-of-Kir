﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Dargons_of_Kir.Tiles
{
    public class SamuraiTile: Tile
    {
        private static Image getPic(){
             return Image.FromFile("..\\..\\..\\..\\images\\samurai.JPG");
        }
        public SamuraiTile() : base(getPic())
        {
            this.Priority = 1;
        }

        override public bool callback()
        {
            return true;
        }

        public override void placeEffects(Board board)
        {
            List<Effect> toAdd = new List<Effect>();

            switch(this.orientation){
                case Board.orientation.UP:
                    toAdd.Add(new Effect(Board.makeBoardLocation(this.location.x + 1, this.location.y), Board.orientation.DOWN, Board.orientation.RIGHT, 0, this.Priority, this));
                    toAdd.Add(new Effect(Board.makeBoardLocation(this.location.x, this.location.y - 1), Board.orientation.LEFT, Board.orientation.UP, 0, this.Priority, this));
                    break;
                case Board.orientation.DOWN:
                    toAdd.Add(new Effect(Board.makeBoardLocation(this.location.x - 1, this.location.y), Board.orientation.UP, Board.orientation.LEFT, 0, this.Priority, this));
                    toAdd.Add(new Effect(Board.makeBoardLocation(this.location.x, this.location.y + 1), Board.orientation.RIGHT, Board.orientation.DOWN, 0, this.Priority, this));
                    break;
                case Board.orientation.LEFT:
                    toAdd.Add(new Effect(Board.makeBoardLocation(this.location.x - 1, this.location.y), Board.orientation.DOWN, Board.orientation.LEFT, 0, this.Priority, this));
                    toAdd.Add(new Effect(Board.makeBoardLocation(this.location.x, this.location.y - 1), Board.orientation.RIGHT, Board.orientation.UP, 0, this.Priority, this));
                    break;
                case Board.orientation.RIGHT:
                    toAdd.Add(new Effect(Board.makeBoardLocation(this.location.x, this.location.y + 1), Board.orientation.LEFT, Board.orientation.DOWN, 0, this.Priority, this));
                    toAdd.Add(new Effect(Board.makeBoardLocation(this.location.x + 1, this.location.y), Board.orientation.UP, Board.orientation.RIGHT, 0, this.Priority, this));
                    break;

            }

            board.getEffectAt(this.location).AddRange(toAdd);

        }
    }
}
