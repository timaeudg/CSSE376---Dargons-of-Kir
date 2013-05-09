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
        

    }
}
