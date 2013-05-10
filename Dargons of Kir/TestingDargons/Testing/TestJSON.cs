using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Web;
using Dargons_of_Kir;
using Dargons_of_Kir.Tiles;

namespace TestingDargons.Testing
{
    [TestFixture]
    class TestJSON
    {

        [Test]
        public static void TestJSONFileLoad()
        {
            StreamReader re = new StreamReader("..\\..\\..\\..\\JSON Tiles\\TestTile.json");
            String file = re.ReadToEnd();

            JObject jsonStuff = JsonConvert.DeserializeObject<JObject>(file);
            JObject testObj = JObject.Parse(file);


            object priority = testObj["priority"];
            int parsedPriority = Convert.ToInt32(priority);
            string parsedName = Convert.ToString(testObj["name"]);
            string filename = Convert.ToString(testObj["image"]);

            JToken effects = testObj["Effects"];
            List<JToken> effectList = effects.ToList();
            JToken firstElement = effectList[0];
            JObject firstObject = firstElement.ToObject<JObject>();
            //List<JObject> firstEffect = effectList.Cast<JObject>();

            Assert.AreEqual(1, parsedPriority);
            Assert.AreEqual("JSONTest.jpg", filename);
            Assert.AreEqual("TestTile", parsedName);

            Assert.NotNull(jsonStuff);

        }

        [Test]
        public static void TestAnonJSON()
        {
            StreamReader re = new StreamReader("..\\..\\..\\..\\JSON Tiles\\TestTile.json");
            String file = re.ReadToEnd();

            var anonEffect = new {x = new int(), y = new int() , inDir = "" , outDir = "", outX = new int(), outY = new int()};
            var JSON_FORMAT = new { name = "",
                                    image = "",
                                    priority = new int(),
                                    Effects = new[] {anonEffect} 
                                  };

            var TestTile = JsonConvert.DeserializeAnonymousType(file, JSON_FORMAT);

            Assert.NotNull(TestTile);
            Assert.AreEqual("DOWN", TestTile.Effects[0].inDir);

        }

        [Test]
        public static void TestJSONTileInit()
        {
            JSONTile jsonTest = new JSONTile("TestTile.json");

            Assert.NotNull(jsonTest);
            Assert.AreEqual("TestTile", jsonTest.name);


        }

        [Test]
        public static void TestTileEffects()
        {
            GameInfo game = new GameInfo();
            JSONTile testTile = new JSONTile("TestTile.json");

            game.placeTileAtPosition(Board.makeBoardLocation(1, 1), Board.orientation.UP, testTile);
            Board board = game.getTileBoard();
            List<Effect> e = board.getEffectAt(Board.makeBoardLocation(1, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(0, 1), Board.orientation.DOWN, Board.orientation.DOWN, 0, 1));

            testTile = new JSONTile("TestTile.json");
            game.placeTileAtPosition(Board.makeBoardLocation(2, 2), Board.orientation.LEFT, testTile);
            e = board.getEffectAt(Board.makeBoardLocation(2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 3), Board.orientation.RIGHT, Board.orientation.RIGHT, 0, 1));

            testTile = new JSONTile("TestTile.json");
            game.placeTileAtPosition(Board.makeBoardLocation(3, 3), Board.orientation.RIGHT, testTile);
            e = board.getEffectAt(Board.makeBoardLocation(3, 3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 2), Board.orientation.LEFT, Board.orientation.LEFT, 0, 1));

            testTile = new JSONTile("TestTile.json");
            game.placeTileAtPosition(Board.makeBoardLocation(5, 5), Board.orientation.DOWN, testTile);
            e = board.getEffectAt(Board.makeBoardLocation(5, 5));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(6, 5), Board.orientation.UP, Board.orientation.UP, 0, 1));


        }


        [Test]
        public static void ExtendedSamuraiEffects()
        {
            GameInfo game = new GameInfo();
            JSONTile testTile = new JSONTile("extendedSamurai.json");

            game.placeTileAtPosition(Board.makeBoardLocation(1, 1), Board.orientation.UP, testTile);
            Board board = game.getTileBoard();
            List<Effect> e = board.getEffectAt(Board.makeBoardLocation(1, 3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(1, 4), Board.orientation.UP, Board.orientation.RIGHT, 2, 2));
            e = board.getEffectAt(Board.makeBoardLocation(3, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(4, 1), Board.orientation.LEFT, Board.orientation.UP, 2, 2));

            game = new GameInfo();
            testTile = new JSONTile("extendedSamurai.json");
            game.placeTileAtPosition(Board.makeBoardLocation(3, 3), Board.orientation.LEFT, testTile);
            e = board.getEffectAt(Board.makeBoardLocation(5, 3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(6, 3), Board.orientation.LEFT, Board.orientation.UP, 2, 2));
            e = board.getEffectAt(Board.makeBoardLocation(3, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 0), Board.orientation.DOWN, Board.orientation.LEFT, 2, 2));

            game = new GameInfo();
            testTile = new JSONTile("extendedSamurai.json");
            game.placeTileAtPosition(Board.makeBoardLocation(3, 3), Board.orientation.RIGHT, testTile);
            e = board.getEffectAt(Board.makeBoardLocation(1, 3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(0, 3), Board.orientation.RIGHT, Board.orientation.DOWN, 2, 2));
            e = board.getEffectAt(Board.makeBoardLocation(3, 5));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 6), Board.orientation.UP, Board.orientation.RIGHT, 2, 2));

            game = new GameInfo();
            testTile = new JSONTile("extendedSamurai.json");
            game.placeTileAtPosition(Board.makeBoardLocation(3, 3), Board.orientation.DOWN, testTile);
            e = board.getEffectAt(Board.makeBoardLocation(1, 3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(0, 3), Board.orientation.RIGHT, Board.orientation.DOWN, 2, 2));
            e = board.getEffectAt(Board.makeBoardLocation(3, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 0), Board.orientation.DOWN, Board.orientation.LEFT, 2, 2));


        }

    }
}
