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
            dynamic data = JsonConvert.DeserializeObject<dynamic>(file);
            int parsedPriority = Convert.ToInt32(priority);
            string parsedName = Convert.ToString(testObj["name"]);
            string filename = Convert.ToString(testObj["image"]);
            JToken effects = testObj["Effects"];
            List<JToken> effectList = effects.ToList();
            Assert.AreEqual(1, parsedPriority);
            Assert.AreEqual("JSONTest.jpg", filename);
            Assert.AreEqual("TestTile", parsedName);
            Assert.NotNull(jsonStuff);

        }
        

    }
}
