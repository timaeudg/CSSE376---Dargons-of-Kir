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


        /* 
         * Gets the effect that should be affecting the dragon
         * based on the dragon's orientation, and which tiles it
         * should be ignoring
         */
        public Effect getActiveEffect(Board.orientation dragonOrient, List<Tile> dontEffect)
        {
            List<Effect> validEffects = new List<Effect>();  
            foreach (Effect e in this.effectList)
            {
                if (e.parentTile != null && dontEffect != null && dontEffect.Contains(e.parentTile)) break;
                if (!e.activateCallback()) break;
                if (e.requiredStartingOrientation == dragonOrient) validEffects.Add(e);

            }
            if(validEffects.Count > 1) 
            {
                int min = 10000;
                for (int i = 0; i < validEffects.Count; i++ )
                {
                    if (validEffects[i].priority < min)
                    {
                        min = validEffects[i].priority;
                        for (int j = 0; j < validEffects.Count; j++ )
                        {
                            if (validEffects[j].priority > min) validEffects.RemoveAt(j--); 
                        }
                    }
                }
                if (validEffects.Count > 1)
                {
                    for (int i = 0; i < validEffects.Count; i++)
                    {
                        if (validEffects[i].distance < min)
                        {
                            min = validEffects[i].distance;
                            for (int j = 0; j < validEffects.Count; j++)
                            {
                                if (validEffects[j].distance > min) validEffects.RemoveAt(j--);
                            }
                        }
                    }
                }
            }

            if (validEffects.Count > 1)
            {
                Board.location loc = validEffects[0].destination;
                foreach (Effect e in validEffects)
                {
                    if (!e.destination.Equals(loc)) return null;
                }
            }
            if (validEffects.Count >= 1) return validEffects[0];
            return null;
        }
    }
}
