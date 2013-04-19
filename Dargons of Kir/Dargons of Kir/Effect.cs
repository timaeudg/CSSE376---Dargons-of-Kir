using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dargons_of_Kir
{

    public class Effect
    {
        public Board.location destination { get; private set; }
        public Board.orientation requiredStartingOrientation {  get;  set; }
        public Board.orientation endingOrientaion {  get;  private set; }
        public int distance {  get; private set; }
        public int priority {  get;  private set; }
        public Tile parentTile {  get;  private set; }

        public Effect(Board.location destination, Board.orientation startorientation,Board.orientation endorientation, int distance, int priority, Tile parent)
        {
            this.destination = destination;
            this.requiredStartingOrientation = startorientation;
            this.endingOrientaion = endorientation;
            this.distance = distance;
            this.priority = priority;
            this.parentTile = parent;
        }

        public bool activateCallback()
        {
           
            if(parentTile != null) return this.parentTile.callback();
            return true;
        }
    }
}
