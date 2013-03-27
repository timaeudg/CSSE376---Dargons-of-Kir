using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Dargons_of_Kir;
using Dargons_of_Kir.Tiles;

namespace TestingDargons.Testing
{
    [TestFixture]
    class TestDragon
    {

        [Test]
        public void testMakingDragons(){
            Board.location loc = new Board.location();
            Dragon drag = new Dragon(0, loc, 0);
            Assert.NotNull(drag);
        }

        [Test]
        public void testGetDragonID()
        {
            Dragon drag;
            Board.location loc = new Board.location();
            for (int i = 0; i < 1000; i++)
            {
                drag = new Dragon(i, loc, 0);
                Assert.True(i==drag.getDragonID());
            }
        }

        [Test]
        public void testGetOrientation()
        {
            Dragon drag;
            Board.location loc = new Board.location();
            drag  = new Dragon(0,loc,Board.orientation.DOWN);
            Assert.True(Board.orientation.DOWN == drag.getOrientation());

        }


        [Test]
        public void testPreviousTileID()
        {
            Board.location loc = new Board.location();
            Dragon drag = new Dragon(0,loc, Board.orientation.LEFT);
            Tile tester = new MonkTile();
            drag.setPreviousTile(tester.getID());
            Assert.True(drag.getPreviousTile() == tester.getID());

        }

        [Test]
        public void testGetCurrentPosition()
        {
            Board.location loc = new Board.location();
            loc.x = 4;
            loc.y = -4;
            Dragon drag = new Dragon(0, loc, Board.orientation.RIGHT);
            Board.location dragLoc = drag.getCurrentPosition();
            Assert.True((dragLoc.x == loc.x) && (dragLoc.y == loc.y));

        }


        [Test]
        public void testSetOrientation()
        {
            Board.location loc = new Board.location();

            loc.x = 6;
            loc.y = 6;
            Dragon drag = new Dragon(0, loc, Board.orientation.RIGHT);
            Assert.AreEqual(drag.getOrientation(), Board.orientation.RIGHT);
            drag.setOrientation(Board.orientation.LEFT);
            Assert.AreEqual(drag.getOrientation(), Board.orientation.LEFT);


        }

        [Test]
        public void testDragonMovement()
        {
            Board.location loc = new Board.location();
            loc.x = 4;
            loc.y = 4;
            Dragon drag = new Dragon(0, loc, Board.orientation.UP);
            Assert.AreEqual(drag.getCurrentPosition(), loc);
            drag.move();
            loc = new Board.location();
            loc.x = 4;
            loc.y = 3;
            Assert.AreEqual(drag.getCurrentPosition(), loc);
            drag.setOrientation(Board.orientation.LEFT);
            drag.move();
            loc.x = 3;
            Assert.AreEqual(drag.getCurrentPosition(), loc);

        }

        [Test]
        public void testDragonWraparound()
        {
            Board.location loc = new Board.location();
            loc.x = 7;
            loc.y = 0;
            Dragon drag = new Dragon(0, loc, Board.orientation.RIGHT);
            drag.move();
            Board.location check = new Board.location();
            check.x = 0;
            check.y = 0;
            Assert.AreEqual(drag.getCurrentPosition(), check);

            drag.setOrientation(Board.orientation.UP);
            drag.move();
            check.y = 7;
            Assert.AreEqual(drag.getCurrentPosition(), check);

            drag.setOrientation(Board.orientation.DOWN);
            drag.move();
            check.y = 0;
            Assert.AreEqual(drag.getCurrentPosition(), check);
            drag.setOrientation(Board.orientation.LEFT);
            drag.move();
            check.x = 7;
            Assert.AreEqual(drag.getCurrentPosition(), check);

        }
    }
}
