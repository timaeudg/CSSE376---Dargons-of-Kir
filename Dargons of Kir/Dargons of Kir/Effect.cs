﻿using System;
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
        private int distance {  get;  set; }
        private int priority {  get;  set; }
        private int parentTileID {  get;  set; }
        private Func<bool> callback {  get;  set; }

        public Effect(Board.location destination, Board.orientation startorientation,Board.orientation endorientation, int distance, int priority, int parentID, Func<bool> functionCall)
        {
            this.destination = destination;
            this.requiredStartingOrientation = startorientation;
            this.endingOrientaion = endorientation;
            this.distance = distance;
            this.priority = priority;
            this.parentTileID = parentID;
            this.callback = functionCall;

        }

        public bool activateCallback()
        {
            return this.callback.Invoke();

        }




    }
}
