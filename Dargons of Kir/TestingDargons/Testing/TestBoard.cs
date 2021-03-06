﻿using System;
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
            monk.location.x = 4;
            monk.location.y = 2;
            Assert.IsTrue(b.addPiece(monk));
            Assert.NotNull(b.getTileAt(4, 2));
        }

        [Test]
        public void testPlaceTileFailure()
        {
            Board b = new Board();
            MonkTile monk = new MonkTile();
            monk.location.x = 4;
            monk.location.y = 5;
            Assert.IsTrue(b.addPiece(monk));
            Assert.NotNull(b.getTileAt(4, 5));
            Assert.IsFalse(b.addPiece(monk));
        }


        [Test]
        public void testMakeBoardLocation()
        {
            Board.location loc = new Board.location();

            loc.x = 4;
            loc.y = 4;
            Assert.AreEqual(loc, Board.makeBoardLocation(4, 4));

        }

        [Test]
        public void testDestroyTileAt()
        {
            GameInfo game = new GameInfo();

            game.placeTileAtPosition(Board.makeBoardLocation(0, 0), Board.orientation.LEFT, new MonkTile());
            Assert.True(game.destroyTileAt(Board.makeBoardLocation(0, 0)));
            Assert.False(game.destroyTileAt(Board.makeBoardLocation(0, 0)));

        }

    }

}

