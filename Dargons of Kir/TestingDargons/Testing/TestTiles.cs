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
        public static bool checkEffectListHas(List<Effect> list, Board.location ending, Board.orientation start, Board.orientation end, int distance, int priority)
        {
            foreach(Effect e in list){
                if(e.destination.Equals(ending) && e.endingOrientaion == end && e.requiredStartingOrientation == start && e.distance == distance && e.priority == priority){
                    return true;
                }
            }
            return false;
        }

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
        public void TestMonkEffectsCorrect()
        {
            GameInfo game = new GameInfo();
            MonkTile monk = new MonkTile();

            game.placeTileAtPosition(Board.makeBoardLocation(1, 1), Board.orientation.UP, monk);
            Board board = game.getTileBoard();
            List<Effect> e = board.getEffectAt(Board.makeBoardLocation(1, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(0,1),Board.orientation.RIGHT, Board.orientation.LEFT, 0,1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 1), Board.orientation.LEFT, Board.orientation.RIGHT, 0, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(1, 2), Board.orientation.UP, Board.orientation.DOWN, 0, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(1, 0), Board.orientation.DOWN, Board.orientation.UP, 0, 1));
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
        public void TestSamuraiEffectsCorrect()
        {
            GameInfo game = new GameInfo();
            SamuraiTile sam = new SamuraiTile();

            game.placeTileAtPosition(Board.makeBoardLocation(1, 1), Board.orientation.UP, sam);
            Board board = game.getTileBoard();
            List<Effect> e = board.getEffectAt(Board.makeBoardLocation(1, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 1), Board.orientation.DOWN, Board.orientation.RIGHT, 0, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(1, 0), Board.orientation.LEFT, Board.orientation.UP, 0, 1));

            sam = new SamuraiTile();
            game.placeTileAtPosition(Board.makeBoardLocation(2, 3), Board.orientation.RIGHT, sam);
            e = board.getEffectAt(Board.makeBoardLocation(2, 3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 3), Board.orientation.UP, Board.orientation.RIGHT, 0, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 4), Board.orientation.LEFT, Board.orientation.DOWN, 0, 1));

            sam = new SamuraiTile();
            game.placeTileAtPosition(Board.makeBoardLocation(2, 4), Board.orientation.DOWN, sam);
            e = board.getEffectAt(Board.makeBoardLocation(2, 4));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(1, 4), Board.orientation.UP, Board.orientation.LEFT, 0, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 5), Board.orientation.RIGHT, Board.orientation.DOWN, 0, 1));

            sam = new SamuraiTile();
            game.placeTileAtPosition(Board.makeBoardLocation(3,3), Board.orientation.LEFT, sam);
            e = board.getEffectAt(Board.makeBoardLocation(3, 3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 3), Board.orientation.DOWN, Board.orientation.LEFT, 0, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 2), Board.orientation.RIGHT, Board.orientation.UP, 0, 1));
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

        [Test]
        public void TestRoninCorrectEffects()
        {
            GameInfo game = new GameInfo();
            RoninTile ron = new RoninTile();

            game.placeTileAtPosition(Board.makeBoardLocation(1, 1), Board.orientation.UP, ron);
            Board board = game.getTileBoard();
            List<Effect> e = board.getEffectAt(Board.makeBoardLocation(1, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 1), Board.orientation.LEFT, Board.orientation.RIGHT, 0, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(0, 1), Board.orientation.RIGHT, Board.orientation.LEFT, 0, 1));

            ron = new RoninTile();
            game.placeTileAtPosition(Board.makeBoardLocation(2, 3), Board.orientation.RIGHT, ron);
            e = board.getEffectAt(Board.makeBoardLocation(2, 3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 4), Board.orientation.UP, Board.orientation.DOWN, 0, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 2), Board.orientation.DOWN, Board.orientation.UP, 0, 1));

        }

        [Test]
        public void TestSingleRiverEffects()
        {
            GameInfo game = new GameInfo();
            SingleRiverTile riv;
            Board board = game.getTileBoard();

            riv = new SingleRiverTile();
            game.placeTileAtPosition(Board.makeBoardLocation(4, 3), Board.orientation.UP, riv);
            List<Effect> e = board.getEffectAt(Board.makeBoardLocation(4, 3));
            Assert.AreEqual(2, e.Count);

            riv = new SingleRiverTile();
            game.placeTileAtPosition(Board.makeBoardLocation(4, 4), Board.orientation.LEFT, riv);
            e = board.getEffectAt(Board.makeBoardLocation(4, 4));
            Assert.AreEqual(2, e.Count);

            riv = new SingleRiverTile();
            game.placeTileAtPosition(Board.makeBoardLocation(3, 4), Board.orientation.DOWN, riv);
            e = board.getEffectAt(Board.makeBoardLocation(3, 4));
            Assert.AreEqual(2, e.Count);

            riv = new SingleRiverTile();
            game.placeTileAtPosition(Board.makeBoardLocation(3, 3), Board.orientation.RIGHT, riv);
            e = board.getEffectAt(Board.makeBoardLocation(3, 3));
            Assert.AreEqual(2, e.Count);

        }

        [Test]
        public void TestSingleRiverCorrectEffect()
        {
            GameInfo game = new GameInfo();
            SingleRiverTile riv = new SingleRiverTile();

            game.placeTileAtPosition(Board.makeBoardLocation(1, 1), Board.orientation.RIGHT, riv);
            Board board = game.getTileBoard();
            List<Effect> e = board.getEffectAt(Board.makeBoardLocation(1, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(1, 0), Board.orientation.UP, Board.orientation.UP, 0, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(1, 2), Board.orientation.DOWN, Board.orientation.DOWN, 0, 1));

            riv = new SingleRiverTile();
            game.placeTileAtPosition(Board.makeBoardLocation(2, 3), Board.orientation.UP, riv);
            e = board.getEffectAt(Board.makeBoardLocation(2, 3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 3), Board.orientation.RIGHT, Board.orientation.RIGHT, 0, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(1, 3), Board.orientation.LEFT, Board.orientation.LEFT, 0, 1));
        }

        [Test]
        public void TestDoubleRiverEffects()
        {
            GameInfo game = new GameInfo();
            TwoRiversTile riv;
            Board board = game.getTileBoard();

            riv = new TwoRiversTile();
            game.placeTileAtPosition(Board.makeBoardLocation(4, 3), Board.orientation.UP, riv);
            List<Effect> e = board.getEffectAt(Board.makeBoardLocation(4, 3));
            Assert.AreEqual(2, e.Count);

            riv = new TwoRiversTile();
            game.placeTileAtPosition(Board.makeBoardLocation(4, 4), Board.orientation.LEFT, riv);
            e = board.getEffectAt(Board.makeBoardLocation(4, 4));
            Assert.AreEqual(2, e.Count);

            riv = new TwoRiversTile();
            game.placeTileAtPosition(Board.makeBoardLocation(3, 4), Board.orientation.DOWN, riv);
            e = board.getEffectAt(Board.makeBoardLocation(3, 4));
            Assert.AreEqual(2, e.Count);

            riv = new TwoRiversTile();
            game.placeTileAtPosition(Board.makeBoardLocation(3, 3), Board.orientation.RIGHT, riv);
            e = board.getEffectAt(Board.makeBoardLocation(3, 3));
            Assert.AreEqual(2, e.Count);

        }

        [Test]
        public void TestDoubleRiverEffectCorrect()
        {
            GameInfo game = new GameInfo();
            TwoRiversTile riv = new TwoRiversTile();

            game.placeTileAtPosition(Board.makeBoardLocation(1, 1), Board.orientation.UP, riv);
            Board board = game.getTileBoard();
            List<Effect> e = board.getEffectAt(Board.makeBoardLocation(1, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(1, 2), Board.orientation.RIGHT, Board.orientation.DOWN, 0, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(1, 2), Board.orientation.LEFT, Board.orientation.DOWN, 0, 1));

            riv = new TwoRiversTile();
            game.placeTileAtPosition(Board.makeBoardLocation(2, 3), Board.orientation.LEFT, riv);
            e = board.getEffectAt(Board.makeBoardLocation(2, 3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 3), Board.orientation.UP, Board.orientation.RIGHT, 0, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 3), Board.orientation.DOWN, Board.orientation.RIGHT, 0, 1));

            riv = new TwoRiversTile();
            game.placeTileAtPosition(Board.makeBoardLocation(2, 4), Board.orientation.DOWN, riv);
            e = board.getEffectAt(Board.makeBoardLocation(2, 4));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 3), Board.orientation.LEFT, Board.orientation.UP, 0, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 3), Board.orientation.RIGHT, Board.orientation.UP, 0, 1));

            riv = new TwoRiversTile();
            game.placeTileAtPosition(Board.makeBoardLocation(3, 3), Board.orientation.RIGHT, riv);
            e = board.getEffectAt(Board.makeBoardLocation(3, 3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 3), Board.orientation.DOWN, Board.orientation.LEFT, 0, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 3), Board.orientation.UP, Board.orientation.LEFT, 0, 1));
        }

        [Test]
        public void TestTripleRiverEffects()
        {
            GameInfo game = new GameInfo();
            ThreeRiversTile riv;
            Board board = game.getTileBoard();

            riv = new ThreeRiversTile();
            game.placeTileAtPosition(Board.makeBoardLocation(4, 3), Board.orientation.UP, riv);
            List<Effect> e = board.getEffectAt(Board.makeBoardLocation(4, 3));
            Assert.AreEqual(3, e.Count);

            riv = new ThreeRiversTile();
            game.placeTileAtPosition(Board.makeBoardLocation(4, 4), Board.orientation.LEFT, riv);
            e = board.getEffectAt(Board.makeBoardLocation(4, 4));
            Assert.AreEqual(3, e.Count);

            riv = new ThreeRiversTile();
            game.placeTileAtPosition(Board.makeBoardLocation(3, 4), Board.orientation.DOWN, riv);
            e = board.getEffectAt(Board.makeBoardLocation(3, 4));
            Assert.AreEqual(3, e.Count);

            riv = new ThreeRiversTile();
            game.placeTileAtPosition(Board.makeBoardLocation(3, 3), Board.orientation.RIGHT, riv);
            e = board.getEffectAt(Board.makeBoardLocation(3, 3));
            Assert.AreEqual(3, e.Count);

        }

        [Test]
        public void TestTripleRiverEffectsCorrect()
        {
            GameInfo game = new GameInfo();
            ThreeRiversTile riv = new ThreeRiversTile();

            game.placeTileAtPosition(Board.makeBoardLocation(1, 1), Board.orientation.UP, riv);
            Board board = game.getTileBoard();
            List<Effect> e = board.getEffectAt(Board.makeBoardLocation(1, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(1, 2), Board.orientation.RIGHT, Board.orientation.DOWN, 0, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(1, 2), Board.orientation.LEFT, Board.orientation.DOWN, 0, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(1, 2), Board.orientation.DOWN, Board.orientation.DOWN, 0, 1));

            riv = new ThreeRiversTile();
            game.placeTileAtPosition(Board.makeBoardLocation(2, 3), Board.orientation.LEFT, riv);
            e = board.getEffectAt(Board.makeBoardLocation(2, 3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 3), Board.orientation.UP, Board.orientation.RIGHT, 0, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 3), Board.orientation.DOWN, Board.orientation.RIGHT, 0, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3,3), Board.orientation.RIGHT, Board.orientation.RIGHT, 0, 1));

            riv = new ThreeRiversTile();
            game.placeTileAtPosition(Board.makeBoardLocation(2, 4), Board.orientation.DOWN, riv);
            e = board.getEffectAt(Board.makeBoardLocation(2, 4));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 3), Board.orientation.LEFT, Board.orientation.UP, 0, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 3), Board.orientation.RIGHT, Board.orientation.UP, 0, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2,3), Board.orientation.UP, Board.orientation.UP, 0, 1));

            riv = new ThreeRiversTile();
            game.placeTileAtPosition(Board.makeBoardLocation(3, 3), Board.orientation.RIGHT, riv);
            e = board.getEffectAt(Board.makeBoardLocation(3, 3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 3), Board.orientation.DOWN, Board.orientation.LEFT, 0, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 3), Board.orientation.UP, Board.orientation.LEFT, 0, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2,3), Board.orientation.LEFT, Board.orientation.LEFT, 0, 1));
        }

        [Test]
        public void TestLotusPondEffectPlacing()
        {
            GameInfo game = new GameInfo();
            LotusPondTile lot = new LotusPondTile();
            Board b = game.getTileBoard();

            game.placeTileAtPosition(Board.makeBoardLocation(4, 4), Board.orientation.UP, lot);
            List<Effect> mergedList = new List<Effect>();

            mergedList.AddRange(b.getEffectAt(Board.makeBoardLocation(3, 4)));
            mergedList.AddRange(b.getEffectAt(Board.makeBoardLocation(2, 4)));
            mergedList.AddRange(b.getEffectAt(Board.makeBoardLocation(5, 4)));
            mergedList.AddRange(b.getEffectAt(Board.makeBoardLocation(6, 4)));
            mergedList.AddRange(b.getEffectAt(Board.makeBoardLocation(4, 5)));
            mergedList.AddRange(b.getEffectAt(Board.makeBoardLocation(4, 6)));
            mergedList.AddRange(b.getEffectAt(Board.makeBoardLocation(4, 2)));
            mergedList.AddRange(b.getEffectAt(Board.makeBoardLocation(4, 3)));

            Assert.AreEqual(mergedList.Count, 24);
        }

        [Test]
        public void TestLotusPondCorrect()
        {
            GameInfo game = new GameInfo();
            LotusPondTile pond = new LotusPondTile();

            game.placeTileAtPosition(Board.makeBoardLocation(3, 3), Board.orientation.UP, pond);
            Board board = game.getTileBoard();
            List<Effect> e = board.getEffectAt(Board.makeBoardLocation(3, 3));

            e = board.getEffectAt(Board.makeBoardLocation(3, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 3), Board.orientation.LEFT, Board.orientation.LEFT, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 3), Board.orientation.RIGHT, Board.orientation.RIGHT, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 3), Board.orientation.DOWN, Board.orientation.DOWN, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(3, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 2), Board.orientation.LEFT, Board.orientation.LEFT, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 2), Board.orientation.RIGHT, Board.orientation.RIGHT,2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 2), Board.orientation.DOWN, Board.orientation.DOWN, 2, 2));

            e = board.getEffectAt(Board.makeBoardLocation(2, 3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 3), Board.orientation.UP, Board.orientation.UP, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 3), Board.orientation.DOWN, Board.orientation.DOWN, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 3), Board.orientation.RIGHT, Board.orientation.RIGHT, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(1, 3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 3), Board.orientation.DOWN, Board.orientation.DOWN, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 3), Board.orientation.UP, Board.orientation.UP, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 3), Board.orientation.RIGHT, Board.orientation.RIGHT, 2, 2));

            e = board.getEffectAt(Board.makeBoardLocation(3, 4));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 3), Board.orientation.LEFT, Board.orientation.LEFT, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 3), Board.orientation.RIGHT, Board.orientation.RIGHT, 1,2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 3), Board.orientation.UP, Board.orientation.UP, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(3, 5));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 4), Board.orientation.LEFT, Board.orientation.LEFT, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 4), Board.orientation.RIGHT, Board.orientation.RIGHT, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 4), Board.orientation.UP, Board.orientation.UP, 2, 2));

            e = board.getEffectAt(Board.makeBoardLocation(4, 3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 3), Board.orientation.UP, Board.orientation.UP, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 3), Board.orientation.DOWN, Board.orientation.DOWN, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 3), Board.orientation.LEFT, Board.orientation.LEFT, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(5, 3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(4, 3), Board.orientation.DOWN, Board.orientation.DOWN, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(4, 3), Board.orientation.UP, Board.orientation.UP, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(4, 3), Board.orientation.LEFT, Board.orientation.LEFT, 2, 2));

        }

        [Test]
        public void TestLotusPondWrap()
        {

            GameInfo game = new GameInfo();
            LotusPondTile pond = new LotusPondTile();

            game.placeTileAtPosition(Board.makeBoardLocation(7, 0), Board.orientation.UP, pond);
            Board board = game.getTileBoard();
            List<Effect> e = board.getEffectAt(Board.makeBoardLocation(7, 7));

            
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 0), Board.orientation.LEFT, Board.orientation.LEFT, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 0), Board.orientation.RIGHT, Board.orientation.RIGHT, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 0), Board.orientation.DOWN, Board.orientation.DOWN, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(7, 6));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7,7), Board.orientation.LEFT, Board.orientation.LEFT, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7,7), Board.orientation.RIGHT, Board.orientation.RIGHT, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7,7), Board.orientation.DOWN, Board.orientation.DOWN, 2, 2));

            e = board.getEffectAt(Board.makeBoardLocation(0, 0));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 0), Board.orientation.UP, Board.orientation.UP, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 0), Board.orientation.DOWN, Board.orientation.DOWN, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 0), Board.orientation.LEFT, Board.orientation.LEFT, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(1,0));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(0,0), Board.orientation.DOWN, Board.orientation.DOWN, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(0,0), Board.orientation.UP, Board.orientation.UP, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(0,0), Board.orientation.LEFT, Board.orientation.LEFT, 2, 2));

            e = board.getEffectAt(Board.makeBoardLocation(7,1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7,0), Board.orientation.LEFT, Board.orientation.LEFT, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7,0), Board.orientation.RIGHT, Board.orientation.RIGHT, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7,0), Board.orientation.UP, Board.orientation.UP, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(7,2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7,1), Board.orientation.LEFT, Board.orientation.LEFT, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7,1), Board.orientation.RIGHT, Board.orientation.RIGHT, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7,1), Board.orientation.UP, Board.orientation.UP, 2, 2));

            e = board.getEffectAt(Board.makeBoardLocation(6,0));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7,0), Board.orientation.UP, Board.orientation.UP, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7,0), Board.orientation.DOWN, Board.orientation.DOWN, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7,0), Board.orientation.RIGHT, Board.orientation.RIGHT, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(5,0));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(6,0), Board.orientation.DOWN, Board.orientation.DOWN, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(6,0), Board.orientation.UP, Board.orientation.UP, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(6,0), Board.orientation.RIGHT, Board.orientation.RIGHT, 2, 2));
        }

        [Test]
        public void TestStormEffectPlacing()
        {
            GameInfo game = new GameInfo();
            StormTile lot = new StormTile();
            Board b = game.getTileBoard();

            game.placeTileAtPosition(Board.makeBoardLocation(4, 4), Board.orientation.UP, lot);
            List<Effect> mergedList = new List<Effect>();

            mergedList.AddRange(b.getEffectAt(Board.makeBoardLocation(3, 4)));
            mergedList.AddRange(b.getEffectAt(Board.makeBoardLocation(2, 4)));
            mergedList.AddRange(b.getEffectAt(Board.makeBoardLocation(5, 4)));
            mergedList.AddRange(b.getEffectAt(Board.makeBoardLocation(6, 4)));
            mergedList.AddRange(b.getEffectAt(Board.makeBoardLocation(4, 5)));
            mergedList.AddRange(b.getEffectAt(Board.makeBoardLocation(4, 6)));
            mergedList.AddRange(b.getEffectAt(Board.makeBoardLocation(4, 2)));
            mergedList.AddRange(b.getEffectAt(Board.makeBoardLocation(4, 3)));

            Assert.AreEqual(mergedList.Count, 24);
        }

        [Test]
        public void TestStormCorrect()
        {
            GameInfo game = new GameInfo();
            StormTile str = new StormTile();

            game.placeTileAtPosition(Board.makeBoardLocation(3, 3), Board.orientation.UP, str);
            Board board = game.getTileBoard();
            List<Effect> e = board.getEffectAt(Board.makeBoardLocation(3, 3));

            e = board.getEffectAt(Board.makeBoardLocation(3, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 1), Board.orientation.LEFT, Board.orientation.LEFT, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 1), Board.orientation.RIGHT, Board.orientation.RIGHT, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 1), Board.orientation.UP, Board.orientation.UP, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(3, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 0), Board.orientation.LEFT, Board.orientation.LEFT, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 0), Board.orientation.RIGHT, Board.orientation.RIGHT, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 0), Board.orientation.UP, Board.orientation.UP, 2, 2));

            e = board.getEffectAt(Board.makeBoardLocation(2, 3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(1, 3), Board.orientation.UP, Board.orientation.UP, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(1, 3), Board.orientation.DOWN, Board.orientation.DOWN, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(1, 3), Board.orientation.LEFT, Board.orientation.LEFT, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(1, 3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(0, 3), Board.orientation.DOWN, Board.orientation.DOWN, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(0, 3), Board.orientation.UP, Board.orientation.UP, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(0, 3), Board.orientation.LEFT, Board.orientation.LEFT, 2, 2));

            e = board.getEffectAt(Board.makeBoardLocation(3, 4));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 5), Board.orientation.LEFT, Board.orientation.LEFT, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 5), Board.orientation.RIGHT, Board.orientation.RIGHT, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 5), Board.orientation.DOWN, Board.orientation.DOWN, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(3, 5));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 6), Board.orientation.LEFT, Board.orientation.LEFT, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 6), Board.orientation.RIGHT, Board.orientation.RIGHT, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 6), Board.orientation.DOWN, Board.orientation.DOWN, 2, 2));

            e = board.getEffectAt(Board.makeBoardLocation(4, 3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(5, 3), Board.orientation.UP, Board.orientation.UP, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(5, 3), Board.orientation.DOWN, Board.orientation.DOWN, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(5, 3), Board.orientation.RIGHT, Board.orientation.RIGHT, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(5, 3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(6, 3), Board.orientation.DOWN, Board.orientation.DOWN, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(6, 3), Board.orientation.UP, Board.orientation.UP, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(6, 3), Board.orientation.RIGHT, Board.orientation.RIGHT, 2, 2));

        }

        [Test]
        public void TestStormWrap()
        {

            GameInfo game = new GameInfo();
            StormTile str = new StormTile();

            game.placeTileAtPosition(Board.makeBoardLocation(7, 0), Board.orientation.UP, str);
            Board board = game.getTileBoard();
            List<Effect> e = board.getEffectAt(Board.makeBoardLocation(7, 7));


            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 6), Board.orientation.LEFT, Board.orientation.LEFT, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 6), Board.orientation.RIGHT, Board.orientation.RIGHT, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 6), Board.orientation.UP, Board.orientation.UP, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(7, 6));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 5), Board.orientation.LEFT, Board.orientation.LEFT, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 5), Board.orientation.RIGHT, Board.orientation.RIGHT, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 5), Board.orientation.UP, Board.orientation.UP, 2, 2));

            e = board.getEffectAt(Board.makeBoardLocation(0, 0));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(1, 0), Board.orientation.UP, Board.orientation.UP, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(1, 0), Board.orientation.DOWN, Board.orientation.DOWN, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(1, 0), Board.orientation.RIGHT, Board.orientation.RIGHT, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(1, 0));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 0), Board.orientation.DOWN, Board.orientation.DOWN, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 0), Board.orientation.UP, Board.orientation.UP, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 0), Board.orientation.RIGHT, Board.orientation.RIGHT, 2, 2));

            e = board.getEffectAt(Board.makeBoardLocation(7, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 2), Board.orientation.LEFT, Board.orientation.LEFT, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 2), Board.orientation.RIGHT, Board.orientation.RIGHT, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 2), Board.orientation.DOWN, Board.orientation.DOWN, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(7, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 3), Board.orientation.LEFT, Board.orientation.LEFT, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 3), Board.orientation.RIGHT, Board.orientation.RIGHT, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 3), Board.orientation.DOWN, Board.orientation.DOWN, 2, 2));

            e = board.getEffectAt(Board.makeBoardLocation(6, 0));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(5, 0), Board.orientation.UP, Board.orientation.UP, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(5, 0), Board.orientation.DOWN, Board.orientation.DOWN, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(5, 0), Board.orientation.LEFT, Board.orientation.LEFT, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(5, 0));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(4, 0), Board.orientation.DOWN, Board.orientation.DOWN, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(4, 0), Board.orientation.UP, Board.orientation.UP, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(4, 0), Board.orientation.LEFT, Board.orientation.LEFT, 2, 2));
        }

        [Test]
        public void TestLotusFlowerEffectPlacing()
        {
            GameInfo game = new GameInfo();
            LotusFlowerTile lot;
            Board b = game.getTileBoard();
            List<Effect> counter = new List<Effect>();

            lot = new LotusFlowerTile();
            game.placeTileAtPosition(Board.makeBoardLocation(4, 4), Board.orientation.RIGHT, lot);
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(5, 4)));
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(6,4)));
            Assert.AreEqual(6, counter.Count);
            counter.Clear();

            lot = new LotusFlowerTile();
            game.placeTileAtPosition(Board.makeBoardLocation(3, 4), Board.orientation.DOWN, lot);
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(3, 5)));
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(3, 6)));
            Assert.AreEqual(6, counter.Count);
            counter.Clear();

            lot = new LotusFlowerTile();
            game.placeTileAtPosition(Board.makeBoardLocation(4, 3), Board.orientation.UP, lot);
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(4, 2)));
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(4, 1)));
            Assert.AreEqual(6, counter.Count);
            counter.Clear();

            lot = new LotusFlowerTile();
            game.placeTileAtPosition(Board.makeBoardLocation(3, 3), Board.orientation.LEFT, lot);
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(2, 3)));
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(1, 3)));
            Assert.AreEqual(6, counter.Count);
            counter.Clear();

        }

        [Test]
        public void TestWindEffectPlacing()
        {
            GameInfo game = new GameInfo();
            WindTile lot;
            Board b = game.getTileBoard();
            List<Effect> counter = new List<Effect>();

            lot = new WindTile();
            game.placeTileAtPosition(Board.makeBoardLocation(4, 4), Board.orientation.UP, lot);
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(5, 4)));
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(6, 4)));
            Assert.AreEqual(6, counter.Count);
            counter.Clear();

            lot = new WindTile();
            game.placeTileAtPosition(Board.makeBoardLocation(3, 4), Board.orientation.RIGHT, lot);
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(3, 5)));
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(3, 6)));
            Assert.AreEqual(6, counter.Count);
            counter.Clear();

            lot = new WindTile();
            game.placeTileAtPosition(Board.makeBoardLocation(4, 3), Board.orientation.LEFT, lot);
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(4, 2)));
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(4, 1)));
            Assert.AreEqual(6, counter.Count);
            counter.Clear();

            lot = new WindTile();
            game.placeTileAtPosition(Board.makeBoardLocation(3, 3), Board.orientation.DOWN, lot);
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(2, 3)));
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(1, 3)));
            Assert.AreEqual(6, counter.Count);
            counter.Clear();

        }

        [Test]
        public void TestWatchFireEffectsPlacing()
        {
            GameInfo game = new GameInfo();
            WatchfireTile watch;
            Board b = game.getTileBoard();
            List<Effect> counter = new List<Effect>();

            watch = new WatchfireTile();
            game.placeTileAtPosition(Board.makeBoardLocation(3, 3), Board.orientation.UP, watch);
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(2, 3)));
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(3, 2)));
            Assert.AreEqual(2, counter.Count);
            counter.Clear();

            watch = new WatchfireTile();
            game.placeTileAtPosition(Board.makeBoardLocation(4, 3), Board.orientation.RIGHT, watch);
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(4, 2)));
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(5, 3)));
            Assert.AreEqual(2, counter.Count);
            counter.Clear();

            watch = new WatchfireTile();
            game.placeTileAtPosition(Board.makeBoardLocation(4, 4), Board.orientation.DOWN, watch);
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(4, 5)));
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(5, 4)));
            Assert.AreEqual(2, counter.Count);
            counter.Clear();

            watch = new WatchfireTile();
            game.placeTileAtPosition(Board.makeBoardLocation(3, 4), Board.orientation.LEFT, watch);
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(3, 5)));
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(2, 4)));
            Assert.AreEqual(2, counter.Count);
            counter.Clear();

        }

        [Test]
        public void TestWildFireEffectsPlacing()
        {
            GameInfo game = new GameInfo();
            WildfireTile watch;
            Board b = game.getTileBoard();
            List<Effect> counter = new List<Effect>();

            watch = new WildfireTile();
            game.placeTileAtPosition(Board.makeBoardLocation(3, 3), Board.orientation.UP, watch);
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(2, 3)));
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(4, 3)));
            Assert.AreEqual(2, counter.Count);
            counter.Clear();

            watch = new WildfireTile();
            game.placeTileAtPosition(Board.makeBoardLocation(5, 3), Board.orientation.RIGHT, watch);
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(5, 4)));
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(5, 2)));
            Assert.AreEqual(2, counter.Count);
            counter.Clear();

            watch = new WildfireTile();
            game.placeTileAtPosition(Board.makeBoardLocation(3, 4), Board.orientation.DOWN, watch);
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(2, 4)));
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(4, 4)));
            Assert.AreEqual(2, counter.Count);
            counter.Clear();

            watch = new WildfireTile();
            game.placeTileAtPosition(Board.makeBoardLocation(6, 3), Board.orientation.LEFT, watch);
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(6, 2)));
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(6, 4)));
            Assert.AreEqual(2, counter.Count);
            counter.Clear();

        }

    }
}
