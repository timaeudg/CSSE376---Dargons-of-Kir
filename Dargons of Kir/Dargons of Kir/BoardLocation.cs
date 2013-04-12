using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dargons_of_Kir
{
    public class BoardLocation
    {
        private List<Effect> effectList;
        public Tile tile { get; set; }
        public Board.location location { get; private set; }
        
        public BoardLocation()
        {
            this.effectList = new List<Effect>();
        }

        public BoardLocation(Board.location location)
        {
            this.effectList = new List<Effect>();
            this.location = location;
        }

        public List<Effect> getEffectList()
        {
            return this.effectList;
        }


        internal Effect getActiveEffect()
        {
            if (effectList.Count < 1) return null;
            return effectList[0];
        }
    }
}
