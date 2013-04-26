using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dargons_of_Kir
{
    public class BoardLocation
    {
        public List<Effect> effects { get; private set; }
        public Tile tile { get; set; }
        
        public BoardLocation()
        {
            this.effects = new List<Effect>();
        }

        public Effect getActiveEffect(Board.direction dragonOrient, List<Tile> dontEffect)
        {
            // TODO Implement this properly
            return null;
        }
    }
}
