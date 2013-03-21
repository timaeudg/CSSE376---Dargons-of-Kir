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
            Dragon drag = new Dragon(0, new BoardLocation(), 0);
            Assert.NotNull(drag);
        }

        [Test]
        public void testGetDragonID()
        {
            Dragon drag;
            BoardLocation loc = new BoardLocation();
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
            BoardLocation loc = new BoardLocation();
            for (int i = 0; i < 1000; i++)
            {
                drag  = new Dragon(i,loc,Board.orientation.DOWN);
            }
        }

    }
}
