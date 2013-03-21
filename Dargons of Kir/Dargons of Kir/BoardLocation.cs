using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dargons_of_Kir
{
    public class BoardLocation
    {
        private List<Effect> effectList;
        private Tile tile;
        private Board.location location;

        public BoardLocation()
        {
            this.effectList = new List<Effect>();
        }

        public BoardLocation(Board.location location)
        {
            this.effectList = new List<Effect>();
            this.location = location;
        }

    }
}
