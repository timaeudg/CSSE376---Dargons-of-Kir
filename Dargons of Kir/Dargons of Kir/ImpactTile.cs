﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Dargons_of_Kir
{
    public class MonkTile: Tile
    {
        private static Image getPic(){
             return Image.FromFile(".\\Game Piece Images\\monk.jpg");
        }
        public MonkTile() : base(getPic())
        {
            this.Priority = 0;
        }

        override public bool callback()
        {
            return true;
        }
        
      
    }
}
