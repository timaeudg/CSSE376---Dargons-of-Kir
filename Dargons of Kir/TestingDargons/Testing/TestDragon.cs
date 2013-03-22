using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Dargons_of_Kir;

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
    }
}
