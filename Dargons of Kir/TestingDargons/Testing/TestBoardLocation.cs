using System;
using NUnit.Framework;
using Dargons_of_Kir;

namespace TestingDargons
{
    [TestFixture]
    public class TestBoardLocation
    {
        [Test]
        public void TestBoardLocInit()
        {
            BoardLocation loc = new BoardLocation();
            Assert.IsNotNull(loc);

            Board.location l = new Board.location();
            l.x = 7;
            l.y = 7;

            BoardLocation loc2 = new BoardLocation(l);
            Assert.IsNotNull(loc2);
            Assert.AreEqual(loc2.location.x,7);
            Assert.AreEqual(loc2.location.y,7);
        }

        [Test]
        public void TestGetSetTile()
        {
            BoardLocation loc = new BoardLocation();
            MonkTile monk = new MonkTile();
            loc.tile = monk;
            Assert.AreEqual(loc.tile, monk);
        }
    }
}
