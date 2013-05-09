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
