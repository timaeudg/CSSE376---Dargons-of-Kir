﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Dargons_of_Kir.Tiles
{
    public class DragonBreathTile: Tile
    {
        private static Image getPic(){
             return Image.FromFile("..\\..\\..\\..\\images\\dragonbreath.JPG");
        }
        public DragonBreathTile() : base(getPic())
        {
            this.Priority = 5;
            this.TilePicture = Image.FromFile("..\\..\\..\\..\\images\\dragonbreath.JPG");
        }

        override public bool callback()
        {
            return true;
        }
    }
}
