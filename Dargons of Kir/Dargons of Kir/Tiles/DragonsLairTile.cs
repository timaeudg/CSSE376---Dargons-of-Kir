﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Dargons_of_Kir.Tiles
{
    public class DragonsLairTile: Tile
    {
        private static Image getPic(){
             return Image.FromFile("..\\..\\..\\..\\images\\dragonslair.JPG");
        }
        public DragonsLairTile() : base(getPic())
        {
            this.Priority = 0;
        }

        override public bool callback()
        {
            return true;
        }
        public override void placeEffects(Board board)
        {

        }
    }
}
