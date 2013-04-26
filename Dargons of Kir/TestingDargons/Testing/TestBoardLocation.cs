using System;
using NUnit.Framework;
using Dargons_of_Kir.Tiles;
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

        [Test]
        public void TestGetEffect()
        {
            BoardLocation loc = new BoardLocation();
            Effect eff = new Effect(Board.makeBoardLocation(1, 1), Board.direction.UP, Board.direction.UP, 1, 2, null);
            loc.getEffectList().Add(eff);
            Assert.IsNull(loc.getActiveEffect(Board.direction.DOWN,null));
            Assert.AreEqual(loc.getActiveEffect(Board.direction.UP,null), eff);
        }

        [Test]
        public void TestConflictingEffectsByPriority()
        {
            BoardLocation loc = new BoardLocation();
            Effect eff = new Effect(Board.makeBoardLocation(1, 1), Board.direction.UP, Board.direction.UP, 2, 1, null);
            Effect eff2 = new Effect(Board.makeBoardLocation(1, 1), Board.direction.UP, Board.direction.UP, 1, 2, null);
            loc.getEffectList().Add(eff);
            loc.getEffectList().Add(eff2);
            Assert.AreEqual(loc.getActiveEffect(Board.direction.UP,null), eff);
        }

        [Test]
        public void TestConflictingEffectsByDistance()
        {
            BoardLocation loc = new BoardLocation();
            Effect eff = new Effect(Board.makeBoardLocation(1, 1), Board.direction.UP, Board.direction.UP, 1, 2, null);
            Effect eff2 = new Effect(Board.makeBoardLocation(1, 1), Board.direction.UP, Board.direction.UP, 2, 2, null);
            loc.getEffectList().Add(eff2);
            loc.getEffectList().Add(eff);
            Assert.AreEqual(loc.getActiveEffect(Board.direction.UP,null), eff);
        }

        [Test]
        public void TestConflictingEffectsDifferentDirections()
        {
            BoardLocation loc = new BoardLocation();
            Effect eff = new Effect(Board.makeBoardLocation(1, 2), Board.direction.UP, Board.direction.UP, 1, 2, null);
            Effect eff2 = new Effect(Board.makeBoardLocation(1, 1), Board.direction.UP, Board.direction.UP, 1, 2, null);
            loc.getEffectList().Add(eff2);
            loc.getEffectList().Add(eff);
            Assert.IsNull(loc.getActiveEffect(Board.direction.UP,null));
        }

        [Test]
        public void TestConflictingEffectsSameDirections()
        {
            BoardLocation loc = new BoardLocation();
            Effect eff = new Effect(Board.makeBoardLocation(1, 1), Board.direction.UP, Board.direction.UP, 1, 2, null);
            Effect eff2 = new Effect(Board.makeBoardLocation(1, 1), Board.direction.UP, Board.direction.UP, 1, 2, null);
            loc.getEffectList().Add(eff2);
            loc.getEffectList().Add(eff);
            Assert.AreEqual(loc.getActiveEffect(Board.direction.UP,null),eff2);
        }

        [Test]
        public void TestIgnoreTile()
        {
            BoardLocation loc = new BoardLocation();
            Tile tile = new MonkTile();
            System.Collections.Generic.List<Tile> tiles = new System.Collections.Generic.List<Tile>();
            tiles.Add(tile);
            Effect eff = new Effect(Board.makeBoardLocation(1, 1), Board.direction.UP, Board.direction.UP, 1, 2, tile);
            loc.getEffectList().Add(eff);
            Assert.IsNull(loc.getActiveEffect(Board.direction.UP, tiles));
        }
    }
}
