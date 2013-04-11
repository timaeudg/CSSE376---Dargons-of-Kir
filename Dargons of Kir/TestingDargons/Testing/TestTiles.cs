using System;
using NUnit.Framework;
using Dargons_of_Kir;
using Dargons_of_Kir.Tiles;
using System.Collections.Generic;

namespace TestingDargons.Testing
{
    [TestFixture]
    public class TestTiles
    {
        [Test]
        public void TestInitSingleRiver()
        {
            SingleRiverTile tile = new SingleRiverTile();
            Assert.True(tile.callback());
            Assert.NotNull(tile);
        }
        [Test]
        public void TestInitTwoRivers()
        {
            TwoRiversTile tile = new TwoRiversTile();
            Assert.True(tile.callback());
            Assert.NotNull(tile);
        }
        [Test]
        public void TestInitThreeRivers()
        {
            ThreeRiversTile tile = new ThreeRiversTile();
            Assert.True(tile.callback());
            Assert.NotNull(tile);
        }
        [Test]
        public void TestInitSamurai()
        {
            SamuraiTile tile = new SamuraiTile();
            Assert.True(tile.callback());
            Assert.NotNull(tile);
        }
        [Test]
        public void TestInitRonin()
        {
            RoninTile tile = new RoninTile();
            Assert.True(tile.callback());
            Assert.NotNull(tile);
        }
        [Test]
        public void TestInitMonk()
        {
            MonkTile tile = new MonkTile();
            Assert.True(tile.callback());
            Assert.NotNull(tile);
        }
        [Test]
        public void TestInitWatchfire()
        {
            WatchfireTile tile = new WatchfireTile();
            Assert.True(tile.callback());
            Assert.NotNull(tile);
        }
        [Test]
        public void TestInitWildfire()
        {
            WildfireTile tile = new WildfireTile();
            Assert.True(tile.callback());
            Assert.NotNull(tile);
        }
        [Test]
        public void TestInitLotusFlower()
        {
            LotusFlowerTile tile = new LotusFlowerTile();
            Assert.True(tile.callback());
            Assert.NotNull(tile);
        }
        [Test]
        public void TestInitLotusPond()
        {
            LotusPondTile tile = new LotusPondTile();
            Assert.True(tile.callback());
            Assert.NotNull(tile);
        }
        [Test]
        public void TestInitWind()
        {
            WindTile tile = new WindTile();
            Assert.True(tile.callback());
            Assert.NotNull(tile);
        }
        [Test]
        public void TestInitStorm()
        {
            StormTile tile = new StormTile();
            Assert.True(tile.callback());
            Assert.NotNull(tile);
        }
        [Test]
        public void TestInitDragonsLair()
        {
            DragonsLairTile tile = new DragonsLairTile();
            Assert.True(tile.callback());
            Assert.NotNull(tile);
        }
        [Test]
        public void TestInitDragonBreath()
        {
            DragonBreathTile tile = new DragonBreathTile();
            Assert.True(tile.callback());
            Assert.NotNull(tile);
        }
        

        [Test]
        public void TestSetOrientation()
        {
            DragonBreathTile tile = new DragonBreathTile();
            tile.setOrientation(Board.orientation.DOWN);
            Assert.AreEqual(tile.orientation, Board.orientation.DOWN);
        }

        [Test]
        public void TestPlace()
        {
            MonkTile monk = new MonkTile();
            Board.location loc = new Board.location();
            loc.x = 4;
            loc.y = 7;
            monk.place(loc, Board.orientation.LEFT);

            Assert.AreEqual(monk.orientation, Board.orientation.LEFT);
            Assert.AreEqual(monk.location, loc);
        }

        [Test]
        public void TestMonkEffectsPlacing()
        {
            GameInfo game = new GameInfo();
            MonkTile monk = new MonkTile();

            game.placeTileAtPosition(Board.makeBoardLocation(4,4), Board.orientation.DOWN, monk);
            Board board = game.getTileBoard();
            List<Effect> e =board.getEffectAt(Board.makeBoardLocation(4, 4));
            Assert.AreEqual(4, e.Count);

        }

        [Test]
        public void TestSamuraiEffectsPlacing()
        {
            GameInfo game = new GameInfo();
            SamuraiTile sam;
            Board board = game.getTileBoard();

            List<Effect> e = board.getEffectAt(Board.makeBoardLocation(4, 4));
            sam = new SamuraiTile();
            game.placeTileAtPosition(Board.makeBoardLocation(4,4), Board.orientation.UP, sam);
            Assert.AreEqual(2, e.Count);

            e = board.getEffectAt(Board.makeBoardLocation(4, 3));
            sam = new SamuraiTile();
            game.placeTileAtPosition(Board.makeBoardLocation(4, 3), Board.orientation.DOWN, sam);
            Assert.AreEqual(2, e.Count);

            e = board.getEffectAt(Board.makeBoardLocation(3, 4));
            sam = new SamuraiTile();
            game.placeTileAtPosition(Board.makeBoardLocation(3, 4), Board.orientation.LEFT, sam);
            Assert.AreEqual(2, e.Count);

            e = board.getEffectAt(Board.makeBoardLocation(3,3));
            sam = new SamuraiTile();
            game.placeTileAtPosition(Board.makeBoardLocation(3, 3), Board.orientation.RIGHT, sam);
            Assert.AreEqual(2, e.Count);

        }

        [Test]
        public void TestRoninEffectsPlacing()
        {
            GameInfo game = new GameInfo();
            RoninTile ron;
            Board board = game.getTileBoard();

            ron = new RoninTile();
            game.placeTileAtPosition(Board.makeBoardLocation(4, 4), Board.orientation.UP, ron);
            List<Effect> e = board.getEffectAt(Board.makeBoardLocation(4, 4));
            Assert.AreEqual(2, e.Count);

            ron = new RoninTile();
            game.placeTileAtPosition(Board.makeBoardLocation(4, 3), Board.orientation.DOWN, ron);
            e = board.getEffectAt(Board.makeBoardLocation(4, 4));
            Assert.AreEqual(2, e.Count);

            ron = new RoninTile();
            game.placeTileAtPosition(Board.makeBoardLocation(3, 4), Board.orientation.LEFT, ron);
            e = board.getEffectAt(Board.makeBoardLocation(4, 4));
            Assert.AreEqual(2, e.Count);

            ron = new RoninTile();
            game.placeTileAtPosition(Board.makeBoardLocation(3, 3), Board.orientation.RIGHT, ron);
            e = board.getEffectAt(Board.makeBoardLocation(4, 4));
            Assert.AreEqual(2, e.Count);

        }

    }
}
