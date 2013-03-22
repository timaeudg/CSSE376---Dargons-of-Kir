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
    class TestBoard
    {

        [Test]
        public void testInit()
        {
            Board b = new Board();
            Assert.NotNull(b);
            for (int i = 0; i < 8; i++)
            {
                for (int k = 0; k < 8; k++)
                {
                    Assert.NotNull(b.getBoard()[k, i]);
                    Assert.Null(b.getTileAt(k, i));
                }
            }
        }

        [Test]
        public void testPlaceTile()
        {
            Board b = new Board();
            MonkTile monk = new MonkTile();
            Board.location loc = new Board.location();
            loc.x = 4;
            loc.y = 2;
            b.addPiece(monk, Board.orientation.UP, loc);
            Assert.NotNull(b.getTileAt(4, 2));
        }




    }
}
