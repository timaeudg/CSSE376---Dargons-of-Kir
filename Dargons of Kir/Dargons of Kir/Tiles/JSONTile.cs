using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace Dargons_of_Kir.Tiles
{
    public class JSONTile : Tile
    {
        private JSON_File_Info tileInfo;
        public string name { get { return tileInfo.name; } }

        public JSONTile(string filename)
        {
            StreamReader read = new StreamReader("..\\..\\..\\..\\JSON Tiles\\" + filename);
            String file = read.ReadToEnd();

            this.tileInfo = JsonConvert.DeserializeObject<JSON_File_Info>(file);
            this.Priority = this.tileInfo.priority;
            this.TilePicture = Image.FromFile("..\\..\\..\\..\\images\\"+this.tileInfo.image);
                 
        }


        override public bool callback()
        {
            return true;
        }

        public override void placeEffects(Board board)
        {
            foreach (JSON_Effect e in tileInfo.effects)
            {
                JSON_Effect t = new JSON_Effect();
                //Rotate the effect according to the tile orientation
                switch (this.orientation)
                {
                    case Board.orientation.RIGHT: { t.x = e.y; t.y = e.x;
                                                 t.outX = e.outY; t.outY = e.outX; break; }
                    case Board.orientation.UP:    { t.x = e.x; t.y = e.y;
                                                 t.outX = e.outX; t.outY = e.outY; break; }
                    case Board.orientation.LEFT:  { t.x = -e.y;        t.y = -e.x;
                                                 t.outX = -e.outY; t.outY = -e.outX; break; }
                    case Board.orientation.DOWN:  { t.x = -e.x;       t.y = -e.y;
                                                 t.outX = -e.outX; t.outY = -e.outY; break; }
                }

                //get distance from tile
                int distance = (int)Math.Round(Math.Sqrt(t.x*t.x + t.y*t.y));

                //Apply tile offset
                t.x += this.location.x;
                t.y += this.location.y;
                t.outX += this.location.x;
                t.outY += this.location.y;

                //correct for board size
                while (t.x < 0) t.x += 8;
                while (t.y < 0) t.y += 8;
                while (t.outX < 0) t.outX += 8;
                while (t.outY < 0) t.outY += 8;
                if (t.x >= 8) t.x %= 8;
                if (t.y >= 8) t.y %= 8;
                if (t.outX >= 8) t.outX %= 8;
                if (t.outY >= 8) t.outY %= 8;

                Board.orientation startOrientation = 0;
                switch(e.inDir.ToUpper())
                {
                    case "UP" : startOrientation = Board.orientation.UP; break;
                    case "LEFT" : startOrientation = Board.orientation.LEFT; break;
                    case "RIGHT" : startOrientation = Board.orientation.RIGHT; break;
                    case "DOWN" : startOrientation = Board.orientation.DOWN; break;
                }

                Board.orientation endOrientation = 0;
                switch(e.outDir.ToUpper())
                {
                    case "UP" : endOrientation = Board.orientation.UP; break;
                    case "LEFT" : endOrientation = Board.orientation.LEFT; break;
                    case "RIGHT" : endOrientation = Board.orientation.RIGHT; break;
                    case "DOWN" : endOrientation = Board.orientation.DOWN; break;
                }


                board.getBoard()[t.x, t.y].getEffectList().Add(
                    new Effect(Board.makeBoardLocation(t.outX, t.outY),
                    (Board.orientation)(((int)startOrientation+(int)this.orientation-1)%4),
                    (Board.orientation)(((int)endOrientation+(int)this.orientation-1)%4),
                    distance,
                    this.Priority,
                    this));
            }
        }


        private sealed class JSON_Effect
        {
            public int x { get; set; }
            public int y { get; set; }
            public string inDir { get; set; }
            public string outDir { get; set; }
            public int outX { get; set; }
            public int outY { get; set; }
        }

        private sealed class JSON_File_Info
        {
            public string name { get; set; }
            public string image { get; set; }
            public int priority { get; set; }
            public JSON_Effect[] effects { get; set; }


        }


    }
}
