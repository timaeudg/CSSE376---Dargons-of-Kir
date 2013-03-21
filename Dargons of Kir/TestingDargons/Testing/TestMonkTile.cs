using System;
using NUnit.Framework;
using Dargons_of_Kir;

namespace TestingDargons.Testing
{
    [TestFixture]
    public class TestMonkTile
    {
        [Test]
        public void TestInit()
        {
            MonkTile tile = new MonkTile();
            Assert.NotNull(tile);
        }
    }
}
