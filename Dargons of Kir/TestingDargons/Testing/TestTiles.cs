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
        public static bool checkEffectListHas(List<Effect> list, Board.location ending, Board.direction start, Board.direction end, int distance, int priority)
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
            tile.setOrientation(Board.direction.DOWN);
            Assert.AreEqual(tile.orientation, Board.direction.DOWN);
        }

        [Test]
        public void TestPlace()
        {
            MonkTile monk = new MonkTile();
            Board.location loc = new Board.location();
            loc.x = 4;
            loc.y = 7;
            monk.place(loc, Board.direction.LEFT);

            Assert.AreEqual(monk.orientation, Board.direction.LEFT);
            Assert.AreEqual(monk.location, loc);
        }

        [Test]
        public void TestMonkEffectsPlacing()
        {
            GameInfo game = new GameInfo();
            MonkTile monk = new MonkTile();

            game.placeTileAtPosition(Board.makeBoardLocation(4,4), Board.direction.DOWN, monk);
            Board board = game.getTileBoard();
            List<Effect> e =board.getEffectAt(Board.makeBoardLocation(4, 4));
            Assert.AreEqual(4, e.Count);

        }

        [Test]
        public void TestMonkEffectsCorrect()
        {
            GameInfo game = new GameInfo();
            MonkTile monk = new MonkTile();

            game.placeTileAtPosition(Board.makeBoardLocation(1, 1), Board.direction.UP, monk);
            Board board = game.getTileBoard();
            List<Effect> e = board.getEffectAt(Board.makeBoardLocation(1, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(0,1),Board.direction.RIGHT, Board.direction.LEFT, 0,1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 1), Board.direction.LEFT, Board.direction.RIGHT, 0, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(1, 2), Board.direction.UP, Board.direction.DOWN, 0, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(1, 0), Board.direction.DOWN, Board.direction.UP, 0, 1));
        }

        [Test]
        public void TestSamuraiEffectsPlacing()
        {
            GameInfo game = new GameInfo();
            SamuraiTile sam;
            Board board = game.getTileBoard();

            List<Effect> e = board.getEffectAt(Board.makeBoardLocation(4, 4));
            sam = new SamuraiTile();
            game.placeTileAtPosition(Board.makeBoardLocation(4,4), Board.direction.UP, sam);
            Assert.AreEqual(2, e.Count);

            e = board.getEffectAt(Board.makeBoardLocation(4, 3));
            sam = new SamuraiTile();
            game.placeTileAtPosition(Board.makeBoardLocation(4, 3), Board.direction.DOWN, sam);
            Assert.AreEqual(2, e.Count);

            e = board.getEffectAt(Board.makeBoardLocation(3, 4));
            sam = new SamuraiTile();
            game.placeTileAtPosition(Board.makeBoardLocation(3, 4), Board.direction.LEFT, sam);
            Assert.AreEqual(2, e.Count);

            e = board.getEffectAt(Board.makeBoardLocation(3,3));
            sam = new SamuraiTile();
            game.placeTileAtPosition(Board.makeBoardLocation(3, 3), Board.direction.RIGHT, sam);
            Assert.AreEqual(2, e.Count);

        }

        [Test]
        public void TestSamuraiEffectsCorrect()
        {
            GameInfo game = new GameInfo();
            SamuraiTile sam = new SamuraiTile();

            game.placeTileAtPosition(Board.makeBoardLocation(1, 1), Board.direction.UP, sam);
            Board board = game.getTileBoard();
            List<Effect> e = board.getEffectAt(Board.makeBoardLocation(1, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 1), Board.direction.DOWN, Board.direction.RIGHT, 0, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(1, 0), Board.direction.LEFT, Board.direction.UP, 0, 1));

            sam = new SamuraiTile();
            game.placeTileAtPosition(Board.makeBoardLocation(2, 3), Board.direction.RIGHT, sam);
            e = board.getEffectAt(Board.makeBoardLocation(2, 3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 3), Board.direction.UP, Board.direction.RIGHT, 0, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 4), Board.direction.LEFT, Board.direction.DOWN, 0, 1));

            sam = new SamuraiTile();
            game.placeTileAtPosition(Board.makeBoardLocation(2, 4), Board.direction.DOWN, sam);
            e = board.getEffectAt(Board.makeBoardLocation(2, 4));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(1, 4), Board.direction.UP, Board.direction.LEFT, 0, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 5), Board.direction.RIGHT, Board.direction.DOWN, 0, 1));

            sam = new SamuraiTile();
            game.placeTileAtPosition(Board.makeBoardLocation(3,3), Board.direction.LEFT, sam);
            e = board.getEffectAt(Board.makeBoardLocation(3, 3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 3), Board.direction.DOWN, Board.direction.LEFT, 0, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 2), Board.direction.RIGHT, Board.direction.UP, 0, 1));
        }

        [Test]
        public void TestRoninEffectsPlacing()
        {
            GameInfo game = new GameInfo();
            RoninTile ron;
            Board board = game.getTileBoard();

            ron = new RoninTile();
            game.placeTileAtPosition(Board.makeBoardLocation(4, 4), Board.direction.UP, ron);
            List<Effect> e = board.getEffectAt(Board.makeBoardLocation(4, 4));
            Assert.AreEqual(2, e.Count);

            ron = new RoninTile();
            game.placeTileAtPosition(Board.makeBoardLocation(4, 3), Board.direction.DOWN, ron);
            e = board.getEffectAt(Board.makeBoardLocation(4, 4));
            Assert.AreEqual(2, e.Count);

            ron = new RoninTile();
            game.placeTileAtPosition(Board.makeBoardLocation(3, 4), Board.direction.LEFT, ron);
            e = board.getEffectAt(Board.makeBoardLocation(4, 4));
            Assert.AreEqual(2, e.Count);

            ron = new RoninTile();
            game.placeTileAtPosition(Board.makeBoardLocation(3, 3), Board.direction.RIGHT, ron);
            e = board.getEffectAt(Board.makeBoardLocation(4, 4));
            Assert.AreEqual(2, e.Count);

        }

        [Test]
        public void TestRoninCorrectEffects()
        {
            GameInfo game = new GameInfo();
            RoninTile ron = new RoninTile();

            game.placeTileAtPosition(Board.makeBoardLocation(1, 1), Board.direction.UP, ron);
            Board board = game.getTileBoard();
            List<Effect> e = board.getEffectAt(Board.makeBoardLocation(1, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 1), Board.direction.LEFT, Board.direction.RIGHT, 0, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(0, 1), Board.direction.RIGHT, Board.direction.LEFT, 0, 1));

            ron = new RoninTile();
            game.placeTileAtPosition(Board.makeBoardLocation(2, 3), Board.direction.RIGHT, ron);
            e = board.getEffectAt(Board.makeBoardLocation(2, 3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 4), Board.direction.UP, Board.direction.DOWN, 0, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 2), Board.direction.DOWN, Board.direction.UP, 0, 1));

        }

        [Test]
        public void TestSingleRiverEffects()
        {
            GameInfo game = new GameInfo();
            SingleRiverTile riv;
            Board board = game.getTileBoard();

            riv = new SingleRiverTile();
            game.placeTileAtPosition(Board.makeBoardLocation(4, 3), Board.direction.UP, riv);
            List<Effect> e = board.getEffectAt(Board.makeBoardLocation(4, 3));
            Assert.AreEqual(2, e.Count);

            riv = new SingleRiverTile();
            game.placeTileAtPosition(Board.makeBoardLocation(4, 4), Board.direction.LEFT, riv);
            e = board.getEffectAt(Board.makeBoardLocation(4, 4));
            Assert.AreEqual(2, e.Count);

            riv = new SingleRiverTile();
            game.placeTileAtPosition(Board.makeBoardLocation(3, 4), Board.direction.DOWN, riv);
            e = board.getEffectAt(Board.makeBoardLocation(3, 4));
            Assert.AreEqual(2, e.Count);

            riv = new SingleRiverTile();
            game.placeTileAtPosition(Board.makeBoardLocation(3, 3), Board.direction.RIGHT, riv);
            e = board.getEffectAt(Board.makeBoardLocation(3, 3));
            Assert.AreEqual(2, e.Count);

        }

        [Test]
        public void TestSingleRiverCorrectEffect()
        {
            GameInfo game = new GameInfo();
            SingleRiverTile riv = new SingleRiverTile();

            game.placeTileAtPosition(Board.makeBoardLocation(1, 1), Board.direction.RIGHT, riv);
            Board board = game.getTileBoard();
            List<Effect> e = board.getEffectAt(Board.makeBoardLocation(1, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(1, 0), Board.direction.UP, Board.direction.UP, 0, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(1, 2), Board.direction.DOWN, Board.direction.DOWN, 0, 1));

            riv = new SingleRiverTile();
            game.placeTileAtPosition(Board.makeBoardLocation(2, 3), Board.direction.UP, riv);
            e = board.getEffectAt(Board.makeBoardLocation(2, 3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 3), Board.direction.RIGHT, Board.direction.RIGHT, 0, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(1, 3), Board.direction.LEFT, Board.direction.LEFT, 0, 1));
        }

        [Test]
        public void TestDoubleRiverEffects()
        {
            GameInfo game = new GameInfo();
            TwoRiversTile riv;
            Board board = game.getTileBoard();

            riv = new TwoRiversTile();
            game.placeTileAtPosition(Board.makeBoardLocation(4, 3), Board.direction.UP, riv);
            List<Effect> e = board.getEffectAt(Board.makeBoardLocation(4, 3));
            Assert.AreEqual(2, e.Count);

            riv = new TwoRiversTile();
            game.placeTileAtPosition(Board.makeBoardLocation(4, 4), Board.direction.LEFT, riv);
            e = board.getEffectAt(Board.makeBoardLocation(4, 4));
            Assert.AreEqual(2, e.Count);

            riv = new TwoRiversTile();
            game.placeTileAtPosition(Board.makeBoardLocation(3, 4), Board.direction.DOWN, riv);
            e = board.getEffectAt(Board.makeBoardLocation(3, 4));
            Assert.AreEqual(2, e.Count);

            riv = new TwoRiversTile();
            game.placeTileAtPosition(Board.makeBoardLocation(3, 3), Board.direction.RIGHT, riv);
            e = board.getEffectAt(Board.makeBoardLocation(3, 3));
            Assert.AreEqual(2, e.Count);

        }

        [Test]
        public void TestDoubleRiverEffectCorrect()
        {
            GameInfo game = new GameInfo();
            TwoRiversTile riv = new TwoRiversTile();

            game.placeTileAtPosition(Board.makeBoardLocation(1, 1), Board.direction.UP, riv);
            Board board = game.getTileBoard();
            List<Effect> e = board.getEffectAt(Board.makeBoardLocation(1, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(1, 2), Board.direction.RIGHT, Board.direction.DOWN, 0, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(1, 2), Board.direction.LEFT, Board.direction.DOWN, 0, 1));

            riv = new TwoRiversTile();
            game.placeTileAtPosition(Board.makeBoardLocation(2, 3), Board.direction.LEFT, riv);
            e = board.getEffectAt(Board.makeBoardLocation(2, 3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 3), Board.direction.UP, Board.direction.RIGHT, 0, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 3), Board.direction.DOWN, Board.direction.RIGHT, 0, 1));

            riv = new TwoRiversTile();
            game.placeTileAtPosition(Board.makeBoardLocation(2, 4), Board.direction.DOWN, riv);
            e = board.getEffectAt(Board.makeBoardLocation(2, 4));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 3), Board.direction.LEFT, Board.direction.UP, 0, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 3), Board.direction.RIGHT, Board.direction.UP, 0, 1));

            riv = new TwoRiversTile();
            game.placeTileAtPosition(Board.makeBoardLocation(3, 3), Board.direction.RIGHT, riv);
            e = board.getEffectAt(Board.makeBoardLocation(3, 3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 3), Board.direction.DOWN, Board.direction.LEFT, 0, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 3), Board.direction.UP, Board.direction.LEFT, 0, 1));
        }

        [Test]
        public void TestTripleRiverEffects()
        {
            GameInfo game = new GameInfo();
            ThreeRiversTile riv;
            Board board = game.getTileBoard();

            riv = new ThreeRiversTile();
            game.placeTileAtPosition(Board.makeBoardLocation(4, 3), Board.direction.UP, riv);
            List<Effect> e = board.getEffectAt(Board.makeBoardLocation(4, 3));
            Assert.AreEqual(3, e.Count);

            riv = new ThreeRiversTile();
            game.placeTileAtPosition(Board.makeBoardLocation(4, 4), Board.direction.LEFT, riv);
            e = board.getEffectAt(Board.makeBoardLocation(4, 4));
            Assert.AreEqual(3, e.Count);

            riv = new ThreeRiversTile();
            game.placeTileAtPosition(Board.makeBoardLocation(3, 4), Board.direction.DOWN, riv);
            e = board.getEffectAt(Board.makeBoardLocation(3, 4));
            Assert.AreEqual(3, e.Count);

            riv = new ThreeRiversTile();
            game.placeTileAtPosition(Board.makeBoardLocation(3, 3), Board.direction.RIGHT, riv);
            e = board.getEffectAt(Board.makeBoardLocation(3, 3));
            Assert.AreEqual(3, e.Count);

        }

        [Test]
        public void TestTripleRiverEffectsCorrect()
        {
            GameInfo game = new GameInfo();
            ThreeRiversTile riv = new ThreeRiversTile();

            game.placeTileAtPosition(Board.makeBoardLocation(1, 1), Board.direction.UP, riv);
            Board board = game.getTileBoard();
            List<Effect> e = board.getEffectAt(Board.makeBoardLocation(1, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(1, 2), Board.direction.RIGHT, Board.direction.DOWN, 0, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(1, 2), Board.direction.LEFT, Board.direction.DOWN, 0, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(1, 2), Board.direction.DOWN, Board.direction.DOWN, 0, 1));

            riv = new ThreeRiversTile();
            game.placeTileAtPosition(Board.makeBoardLocation(2, 3), Board.direction.LEFT, riv);
            e = board.getEffectAt(Board.makeBoardLocation(2, 3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 3), Board.direction.UP, Board.direction.RIGHT, 0, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 3), Board.direction.DOWN, Board.direction.RIGHT, 0, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3,3), Board.direction.RIGHT, Board.direction.RIGHT, 0, 1));

            riv = new ThreeRiversTile();
            game.placeTileAtPosition(Board.makeBoardLocation(2, 4), Board.direction.DOWN, riv);
            e = board.getEffectAt(Board.makeBoardLocation(2, 4));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 3), Board.direction.LEFT, Board.direction.UP, 0, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 3), Board.direction.RIGHT, Board.direction.UP, 0, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2,3), Board.direction.UP, Board.direction.UP, 0, 1));

            riv = new ThreeRiversTile();
            game.placeTileAtPosition(Board.makeBoardLocation(3, 3), Board.direction.RIGHT, riv);
            e = board.getEffectAt(Board.makeBoardLocation(3, 3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 3), Board.direction.DOWN, Board.direction.LEFT, 0, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 3), Board.direction.UP, Board.direction.LEFT, 0, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2,3), Board.direction.LEFT, Board.direction.LEFT, 0, 1));
        }



        [Test]
        public void TestLotusPondEffectPlacing()
        {
            GameInfo game = new GameInfo();
            LotusPondTile lot = new LotusPondTile();
            Board b = game.getTileBoard();

            game.placeTileAtPosition(Board.makeBoardLocation(4, 4), Board.direction.UP, lot);
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

            game.placeTileAtPosition(Board.makeBoardLocation(3, 3), Board.direction.UP, pond);
            Board board = game.getTileBoard();
            List<Effect> e = board.getEffectAt(Board.makeBoardLocation(3, 3));

            e = board.getEffectAt(Board.makeBoardLocation(3, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 3), Board.direction.LEFT, Board.direction.LEFT, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 3), Board.direction.RIGHT, Board.direction.RIGHT, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 3), Board.direction.DOWN, Board.direction.DOWN, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(3, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 2), Board.direction.LEFT, Board.direction.LEFT, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 2), Board.direction.RIGHT, Board.direction.RIGHT,2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 2), Board.direction.DOWN, Board.direction.DOWN, 2, 2));

            e = board.getEffectAt(Board.makeBoardLocation(2, 3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 3), Board.direction.UP, Board.direction.UP, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 3), Board.direction.DOWN, Board.direction.DOWN, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 3), Board.direction.RIGHT, Board.direction.RIGHT, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(1, 3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 3), Board.direction.DOWN, Board.direction.DOWN, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 3), Board.direction.UP, Board.direction.UP, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 3), Board.direction.RIGHT, Board.direction.RIGHT, 2, 2));

            e = board.getEffectAt(Board.makeBoardLocation(3, 4));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 3), Board.direction.LEFT, Board.direction.LEFT, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 3), Board.direction.RIGHT, Board.direction.RIGHT, 1,2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 3), Board.direction.UP, Board.direction.UP, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(3, 5));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 4), Board.direction.LEFT, Board.direction.LEFT, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 4), Board.direction.RIGHT, Board.direction.RIGHT, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 4), Board.direction.UP, Board.direction.UP, 2, 2));

            e = board.getEffectAt(Board.makeBoardLocation(4, 3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 3), Board.direction.UP, Board.direction.UP, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 3), Board.direction.DOWN, Board.direction.DOWN, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 3), Board.direction.LEFT, Board.direction.LEFT, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(5, 3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(4, 3), Board.direction.DOWN, Board.direction.DOWN, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(4, 3), Board.direction.UP, Board.direction.UP, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(4, 3), Board.direction.LEFT, Board.direction.LEFT, 2, 2));

        }

        [Test]
        public void TestLotusPondWrap()
        {

            GameInfo game = new GameInfo();
            LotusPondTile pond = new LotusPondTile();

            game.placeTileAtPosition(Board.makeBoardLocation(7, 0), Board.direction.UP, pond);
            Board board = game.getTileBoard();
            List<Effect> e = board.getEffectAt(Board.makeBoardLocation(7, 7));

            
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 0), Board.direction.LEFT, Board.direction.LEFT, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 0), Board.direction.RIGHT, Board.direction.RIGHT, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 0), Board.direction.DOWN, Board.direction.DOWN, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(7, 6));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7,7), Board.direction.LEFT, Board.direction.LEFT, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7,7), Board.direction.RIGHT, Board.direction.RIGHT, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7,7), Board.direction.DOWN, Board.direction.DOWN, 2, 2));

            e = board.getEffectAt(Board.makeBoardLocation(0, 0));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 0), Board.direction.UP, Board.direction.UP, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 0), Board.direction.DOWN, Board.direction.DOWN, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 0), Board.direction.LEFT, Board.direction.LEFT, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(1,0));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(0,0), Board.direction.DOWN, Board.direction.DOWN, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(0,0), Board.direction.UP, Board.direction.UP, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(0,0), Board.direction.LEFT, Board.direction.LEFT, 2, 2));

            e = board.getEffectAt(Board.makeBoardLocation(7,1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7,0), Board.direction.LEFT, Board.direction.LEFT, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7,0), Board.direction.RIGHT, Board.direction.RIGHT, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7,0), Board.direction.UP, Board.direction.UP, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(7,2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7,1), Board.direction.LEFT, Board.direction.LEFT, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7,1), Board.direction.RIGHT, Board.direction.RIGHT, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7,1), Board.direction.UP, Board.direction.UP, 2, 2));

            e = board.getEffectAt(Board.makeBoardLocation(6,0));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7,0), Board.direction.UP, Board.direction.UP, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7,0), Board.direction.DOWN, Board.direction.DOWN, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7,0), Board.direction.RIGHT, Board.direction.RIGHT, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(5,0));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(6,0), Board.direction.DOWN, Board.direction.DOWN, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(6,0), Board.direction.UP, Board.direction.UP, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(6,0), Board.direction.RIGHT, Board.direction.RIGHT, 2, 2));
        }

        [Test]
        public void TestStormEffectPlacing()
        {
            GameInfo game = new GameInfo();
            StormTile lot = new StormTile();
            Board b = game.getTileBoard();

            game.placeTileAtPosition(Board.makeBoardLocation(4, 4), Board.direction.UP, lot);
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

            game.placeTileAtPosition(Board.makeBoardLocation(3, 3), Board.direction.UP, str);
            Board board = game.getTileBoard();
            List<Effect> e = board.getEffectAt(Board.makeBoardLocation(3, 3));

            e = board.getEffectAt(Board.makeBoardLocation(3, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 1), Board.direction.LEFT, Board.direction.LEFT, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 1), Board.direction.RIGHT, Board.direction.RIGHT, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 1), Board.direction.UP, Board.direction.UP, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(3, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 0), Board.direction.LEFT, Board.direction.LEFT, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 0), Board.direction.RIGHT, Board.direction.RIGHT, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 0), Board.direction.UP, Board.direction.UP, 2, 2));

            e = board.getEffectAt(Board.makeBoardLocation(2, 3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(1, 3), Board.direction.UP, Board.direction.UP, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(1, 3), Board.direction.DOWN, Board.direction.DOWN, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(1, 3), Board.direction.LEFT, Board.direction.LEFT, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(1, 3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(0, 3), Board.direction.DOWN, Board.direction.DOWN, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(0, 3), Board.direction.UP, Board.direction.UP, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(0, 3), Board.direction.LEFT, Board.direction.LEFT, 2, 2));

            e = board.getEffectAt(Board.makeBoardLocation(3, 4));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 5), Board.direction.LEFT, Board.direction.LEFT, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 5), Board.direction.RIGHT, Board.direction.RIGHT, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 5), Board.direction.DOWN, Board.direction.DOWN, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(3, 5));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 6), Board.direction.LEFT, Board.direction.LEFT, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 6), Board.direction.RIGHT, Board.direction.RIGHT, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 6), Board.direction.DOWN, Board.direction.DOWN, 2, 2));

            e = board.getEffectAt(Board.makeBoardLocation(4, 3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(5, 3), Board.direction.UP, Board.direction.UP, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(5, 3), Board.direction.DOWN, Board.direction.DOWN, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(5, 3), Board.direction.RIGHT, Board.direction.RIGHT, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(5, 3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(6, 3), Board.direction.DOWN, Board.direction.DOWN, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(6, 3), Board.direction.UP, Board.direction.UP, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(6, 3), Board.direction.RIGHT, Board.direction.RIGHT, 2, 2));

        }

        [Test]
        public void TestStormWrap()
        {

            GameInfo game = new GameInfo();
            StormTile str = new StormTile();

            game.placeTileAtPosition(Board.makeBoardLocation(7, 0), Board.direction.UP, str);
            Board board = game.getTileBoard();
            List<Effect> e = board.getEffectAt(Board.makeBoardLocation(7, 7));


            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 6), Board.direction.LEFT, Board.direction.LEFT, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 6), Board.direction.RIGHT, Board.direction.RIGHT, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 6), Board.direction.UP, Board.direction.UP, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(7, 6));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 5), Board.direction.LEFT, Board.direction.LEFT, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 5), Board.direction.RIGHT, Board.direction.RIGHT, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 5), Board.direction.UP, Board.direction.UP, 2, 2));

            e = board.getEffectAt(Board.makeBoardLocation(0, 0));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(1, 0), Board.direction.UP, Board.direction.UP, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(1, 0), Board.direction.DOWN, Board.direction.DOWN, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(1, 0), Board.direction.RIGHT, Board.direction.RIGHT, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(1, 0));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 0), Board.direction.DOWN, Board.direction.DOWN, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 0), Board.direction.UP, Board.direction.UP, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 0), Board.direction.RIGHT, Board.direction.RIGHT, 2, 2));

            e = board.getEffectAt(Board.makeBoardLocation(7, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 2), Board.direction.LEFT, Board.direction.LEFT, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 2), Board.direction.RIGHT, Board.direction.RIGHT, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 2), Board.direction.DOWN, Board.direction.DOWN, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(7, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 3), Board.direction.LEFT, Board.direction.LEFT, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 3), Board.direction.RIGHT, Board.direction.RIGHT, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 3), Board.direction.DOWN, Board.direction.DOWN, 2, 2));

            e = board.getEffectAt(Board.makeBoardLocation(6, 0));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(5, 0), Board.direction.UP, Board.direction.UP, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(5, 0), Board.direction.DOWN, Board.direction.DOWN, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(5, 0), Board.direction.LEFT, Board.direction.LEFT, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(5, 0));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(4, 0), Board.direction.DOWN, Board.direction.DOWN, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(4, 0), Board.direction.UP, Board.direction.UP, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(4, 0), Board.direction.LEFT, Board.direction.LEFT, 2, 2));
        }

        [Test]
        public void TestLotusFlowerEffectPlacing()
        {
            GameInfo game = new GameInfo();
            LotusFlowerTile lot;
            Board b = game.getTileBoard();
            List<Effect> counter = new List<Effect>();

            lot = new LotusFlowerTile();
            game.placeTileAtPosition(Board.makeBoardLocation(4, 4), Board.direction.RIGHT, lot);
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(5, 4)));
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(6,4)));
            Assert.AreEqual(6, counter.Count);
            counter.Clear();

            lot = new LotusFlowerTile();
            game.placeTileAtPosition(Board.makeBoardLocation(3, 4), Board.direction.DOWN, lot);
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(3, 5)));
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(3, 6)));
            Assert.AreEqual(6, counter.Count);
            counter.Clear();

            lot = new LotusFlowerTile();
            game.placeTileAtPosition(Board.makeBoardLocation(4, 3), Board.direction.UP, lot);
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(4, 2)));
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(4, 1)));
            Assert.AreEqual(6, counter.Count);
            counter.Clear();

            lot = new LotusFlowerTile();
            game.placeTileAtPosition(Board.makeBoardLocation(3, 3), Board.direction.LEFT, lot);
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(2, 3)));
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(1, 3)));
            Assert.AreEqual(6, counter.Count);
            counter.Clear();

        }

        [Test]
        public void TestLotusFlowerCorrect()
        {
            GameInfo game = new GameInfo();
            LotusFlowerTile pond = new LotusFlowerTile();

            game.placeTileAtPosition(Board.makeBoardLocation(3, 3), Board.direction.UP, pond);
            Board board = game.getTileBoard();
            List<Effect> e = board.getEffectAt(Board.makeBoardLocation(3, 3));

            e = board.getEffectAt(Board.makeBoardLocation(3, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 3), Board.direction.LEFT, Board.direction.LEFT, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 3), Board.direction.RIGHT, Board.direction.RIGHT, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 3), Board.direction.DOWN, Board.direction.DOWN, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(3, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 2), Board.direction.LEFT, Board.direction.LEFT, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 2), Board.direction.RIGHT, Board.direction.RIGHT, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 2), Board.direction.DOWN, Board.direction.DOWN, 2, 2));

            game = new GameInfo();
            game.placeTileAtPosition(Board.makeBoardLocation(3, 3), Board.direction.LEFT, new LotusFlowerTile());
            board = game.getTileBoard();
            e = board.getEffectAt(Board.makeBoardLocation(2, 3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 3), Board.direction.UP, Board.direction.UP, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 3), Board.direction.DOWN, Board.direction.DOWN, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 3), Board.direction.RIGHT, Board.direction.RIGHT, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(1, 3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 3), Board.direction.DOWN, Board.direction.DOWN, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 3), Board.direction.UP, Board.direction.UP, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 3), Board.direction.RIGHT, Board.direction.RIGHT, 2, 2));

            game = new GameInfo();
            game.placeTileAtPosition(Board.makeBoardLocation(3, 3), Board.direction.DOWN, new LotusFlowerTile());
            board = game.getTileBoard();
            e = board.getEffectAt(Board.makeBoardLocation(3, 4));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 3), Board.direction.LEFT, Board.direction.LEFT, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 3), Board.direction.RIGHT, Board.direction.RIGHT, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 3), Board.direction.UP, Board.direction.UP, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(3, 5));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 4), Board.direction.LEFT, Board.direction.LEFT, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 4), Board.direction.RIGHT, Board.direction.RIGHT, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 4), Board.direction.UP, Board.direction.UP, 2, 2));

            game = new GameInfo();
            game.placeTileAtPosition(Board.makeBoardLocation(3, 3), Board.direction.RIGHT, new LotusFlowerTile());
            board = game.getTileBoard();
            e = board.getEffectAt(Board.makeBoardLocation(4, 3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 3), Board.direction.UP, Board.direction.UP, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 3), Board.direction.DOWN, Board.direction.DOWN, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 3), Board.direction.LEFT, Board.direction.LEFT, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(5, 3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(4, 3), Board.direction.DOWN, Board.direction.DOWN, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(4, 3), Board.direction.UP, Board.direction.UP, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(4, 3), Board.direction.LEFT, Board.direction.LEFT, 2, 2));

        }

        [Test]
        public void TestLotusFlowerWrap()
        {

            GameInfo game = new GameInfo();
            LotusFlowerTile pond = new LotusFlowerTile();

            game.placeTileAtPosition(Board.makeBoardLocation(7, 0), Board.direction.UP, pond);
            Board board = game.getTileBoard();
            List<Effect> e = board.getEffectAt(Board.makeBoardLocation(7, 7));


            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 0), Board.direction.LEFT, Board.direction.LEFT, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 0), Board.direction.RIGHT, Board.direction.RIGHT, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 0), Board.direction.DOWN, Board.direction.DOWN, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(7, 6));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 7), Board.direction.LEFT, Board.direction.LEFT, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 7), Board.direction.RIGHT, Board.direction.RIGHT, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 7), Board.direction.DOWN, Board.direction.DOWN, 2, 2));

            game = new GameInfo();
            game.placeTileAtPosition(Board.makeBoardLocation(7,0), Board.direction.RIGHT, new LotusFlowerTile());
            board = game.getTileBoard();
            e = board.getEffectAt(Board.makeBoardLocation(0, 0));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 0), Board.direction.UP, Board.direction.UP, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 0), Board.direction.DOWN, Board.direction.DOWN, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 0), Board.direction.LEFT, Board.direction.LEFT, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(1, 0));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(0, 0), Board.direction.DOWN, Board.direction.DOWN, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(0, 0), Board.direction.UP, Board.direction.UP, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(0, 0), Board.direction.LEFT, Board.direction.LEFT, 2, 2));

            game = new GameInfo();
            game.placeTileAtPosition(Board.makeBoardLocation(7,0), Board.direction.DOWN, new LotusFlowerTile());
            board = game.getTileBoard();
            e = board.getEffectAt(Board.makeBoardLocation(7, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 0), Board.direction.LEFT, Board.direction.LEFT, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 0), Board.direction.RIGHT, Board.direction.RIGHT, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 0), Board.direction.UP, Board.direction.UP, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(7, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 1), Board.direction.LEFT, Board.direction.LEFT, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 1), Board.direction.RIGHT, Board.direction.RIGHT, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 1), Board.direction.UP, Board.direction.UP, 2, 2));

            game = new GameInfo();
            game.placeTileAtPosition(Board.makeBoardLocation(7,0), Board.direction.LEFT, new LotusFlowerTile());
            board = game.getTileBoard();
            e = board.getEffectAt(Board.makeBoardLocation(6, 0));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 0), Board.direction.UP, Board.direction.UP, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 0), Board.direction.DOWN, Board.direction.DOWN, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 0), Board.direction.RIGHT, Board.direction.RIGHT, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(5, 0));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(6, 0), Board.direction.DOWN, Board.direction.DOWN, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(6, 0), Board.direction.UP, Board.direction.UP, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(6, 0), Board.direction.RIGHT, Board.direction.RIGHT, 2, 2));
        }

        [Test]
        public void TestWindCorrect()
        {
            GameInfo game = new GameInfo();
            WindTile pond = new WindTile();

            game.placeTileAtPosition(Board.makeBoardLocation(3, 3), Board.direction.UP, pond);
            Board board = game.getTileBoard();
            List<Effect> e = board.getEffectAt(Board.makeBoardLocation(3, 3));

            e = board.getEffectAt(Board.makeBoardLocation(4, 3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(5, 3), Board.direction.UP, Board.direction.UP, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(5, 3), Board.direction.RIGHT, Board.direction.RIGHT, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(5, 3), Board.direction.DOWN, Board.direction.DOWN, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(5, 3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(6, 3), Board.direction.UP, Board.direction.UP, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(6, 3), Board.direction.RIGHT, Board.direction.RIGHT, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(6, 3), Board.direction.DOWN, Board.direction.DOWN, 2, 2));

            game = new GameInfo();
            game.placeTileAtPosition(Board.makeBoardLocation(3, 3), Board.direction.RIGHT, new WindTile());
            board = game.getTileBoard();
            e = board.getEffectAt(Board.makeBoardLocation(3, 4));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 5), Board.direction.DOWN, Board.direction.DOWN, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 5), Board.direction.LEFT, Board.direction.LEFT, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 5), Board.direction.RIGHT, Board.direction.RIGHT, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(3, 5));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 6), Board.direction.DOWN, Board.direction.DOWN, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 6), Board.direction.LEFT, Board.direction.LEFT, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 6), Board.direction.RIGHT, Board.direction.RIGHT, 2, 2));

            game = new GameInfo();
            game.placeTileAtPosition(Board.makeBoardLocation(3, 3), Board.direction.DOWN, new WindTile());
            board = game.getTileBoard();
            e = board.getEffectAt(Board.makeBoardLocation(2, 3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(1, 3), Board.direction.DOWN, Board.direction.DOWN, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(1, 3), Board.direction.LEFT, Board.direction.LEFT, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(1, 3), Board.direction.UP, Board.direction.UP, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(1, 3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(0, 3), Board.direction.DOWN, Board.direction.DOWN, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(0, 3), Board.direction.LEFT, Board.direction.LEFT, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(0, 3), Board.direction.UP, Board.direction.UP, 2, 2));

            game = new GameInfo();
            game.placeTileAtPosition(Board.makeBoardLocation(3, 3), Board.direction.LEFT, new WindTile());
            board = game.getTileBoard();
            e = board.getEffectAt(Board.makeBoardLocation(3, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 1), Board.direction.UP, Board.direction.UP, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 1), Board.direction.RIGHT, Board.direction.RIGHT, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 1), Board.direction.LEFT, Board.direction.LEFT, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(3, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 0), Board.direction.RIGHT, Board.direction.RIGHT, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 0), Board.direction.UP, Board.direction.UP, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 0), Board.direction.LEFT, Board.direction.LEFT, 2, 2));

        }

        [Test]
        public void TestWindWrap()
        {

            GameInfo game = new GameInfo();
            WindTile pond = new WindTile();

            game.placeTileAtPosition(Board.makeBoardLocation(7, 0), Board.direction.LEFT, pond);
            Board board = game.getTileBoard();
            List<Effect> e = board.getEffectAt(Board.makeBoardLocation(7, 7));


            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 6), Board.direction.LEFT, Board.direction.LEFT, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 6), Board.direction.RIGHT, Board.direction.RIGHT, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 6), Board.direction.UP, Board.direction.UP, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(7, 6));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 5), Board.direction.LEFT, Board.direction.LEFT, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 5), Board.direction.RIGHT, Board.direction.RIGHT, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 5), Board.direction.UP, Board.direction.UP, 2, 2));

            game = new GameInfo();
            game.placeTileAtPosition(Board.makeBoardLocation(7, 0), Board.direction.UP, new WindTile());
            board = game.getTileBoard();
            e = board.getEffectAt(Board.makeBoardLocation(0, 0));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(1, 0), Board.direction.UP, Board.direction.UP, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(1, 0), Board.direction.DOWN, Board.direction.DOWN, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(1, 0), Board.direction.RIGHT, Board.direction.RIGHT, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(1, 0));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 0), Board.direction.DOWN, Board.direction.DOWN, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 0), Board.direction.UP, Board.direction.UP, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 0), Board.direction.RIGHT, Board.direction.RIGHT, 2, 2));

            game = new GameInfo();
            game.placeTileAtPosition(Board.makeBoardLocation(7, 0), Board.direction.RIGHT, new WindTile());
            board = game.getTileBoard();
            e = board.getEffectAt(Board.makeBoardLocation(7, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 2), Board.direction.LEFT, Board.direction.LEFT, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 2), Board.direction.RIGHT, Board.direction.RIGHT, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 2), Board.direction.DOWN, Board.direction.DOWN, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(7, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 3), Board.direction.LEFT, Board.direction.LEFT, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 3), Board.direction.RIGHT, Board.direction.RIGHT, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 3), Board.direction.DOWN, Board.direction.DOWN, 2, 2));

            game = new GameInfo();
            game.placeTileAtPosition(Board.makeBoardLocation(7, 0), Board.direction.DOWN, new WindTile());
            board = game.getTileBoard();
            e = board.getEffectAt(Board.makeBoardLocation(6, 0));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(5, 0), Board.direction.UP, Board.direction.UP, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(5, 0), Board.direction.DOWN, Board.direction.DOWN, 1, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(5, 0), Board.direction.LEFT, Board.direction.LEFT, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(5, 0));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(4, 0), Board.direction.DOWN, Board.direction.DOWN, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(4, 0), Board.direction.UP, Board.direction.UP, 2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(4, 0), Board.direction.LEFT, Board.direction.LEFT, 2, 2));
        }

        [Test]
        public void TestWindEffectPlacing()
        {
            GameInfo game = new GameInfo();
            WindTile lot;
            Board b = game.getTileBoard();
            List<Effect> counter = new List<Effect>();

            lot = new WindTile();
            game.placeTileAtPosition(Board.makeBoardLocation(4, 4), Board.direction.UP, lot);
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(5, 4)));
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(6, 4)));
            Assert.AreEqual(6, counter.Count);
            counter.Clear();

            lot = new WindTile();
            game.placeTileAtPosition(Board.makeBoardLocation(3, 4), Board.direction.RIGHT, lot);
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(3, 5)));
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(3, 6)));
            Assert.AreEqual(6, counter.Count);
            counter.Clear();

            lot = new WindTile();
            game.placeTileAtPosition(Board.makeBoardLocation(4, 3), Board.direction.LEFT, lot);
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(4, 2)));
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(4, 1)));
            Assert.AreEqual(6, counter.Count);
            counter.Clear();

            lot = new WindTile();
            game.placeTileAtPosition(Board.makeBoardLocation(3, 3), Board.direction.DOWN, lot);
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
            game.placeTileAtPosition(Board.makeBoardLocation(3, 3), Board.direction.UP, watch);
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(2, 3)));
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(3, 2)));
            Assert.AreEqual(2, counter.Count);
            counter.Clear();

            watch = new WatchfireTile();
            game.placeTileAtPosition(Board.makeBoardLocation(4, 3), Board.direction.RIGHT, watch);
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(4, 2)));
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(5, 3)));
            Assert.AreEqual(2, counter.Count);
            counter.Clear();

            watch = new WatchfireTile();
            game.placeTileAtPosition(Board.makeBoardLocation(4, 4), Board.direction.DOWN, watch);
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(4, 5)));
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(5, 4)));
            Assert.AreEqual(2, counter.Count);
            counter.Clear();

            watch = new WatchfireTile();
            game.placeTileAtPosition(Board.makeBoardLocation(3, 4), Board.direction.LEFT, watch);
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(3, 5)));
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(2, 4)));
            Assert.AreEqual(2, counter.Count);
            counter.Clear();

        }

        [Test]
        public void TestWatchfireCorrect()
        {
            GameInfo game = new GameInfo();
            WatchfireTile sam = new WatchfireTile();

            game.placeTileAtPosition(Board.makeBoardLocation(1, 1), Board.direction.UP, sam);
            Board board = game.getTileBoard();
            List<Effect> e = board.getEffectAt(Board.makeBoardLocation(0, 1));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(1,0), Board.direction.UP, Board.direction.RIGHT, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(1, 0));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(0, 1), Board.direction.LEFT, Board.direction.DOWN, 1,2));


            sam = new WatchfireTile();
            game.placeTileAtPosition(Board.makeBoardLocation(2, 3), Board.direction.RIGHT, sam);
            e = board.getEffectAt(Board.makeBoardLocation(2, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 3), Board.direction.RIGHT, Board.direction.DOWN, 1, 2));
            

            e = board.getEffectAt(Board.makeBoardLocation(3,3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 2), Board.direction.UP, Board.direction.LEFT, 1,2));

            sam = new WatchfireTile();
            game.placeTileAtPosition(Board.makeBoardLocation(2, 4), Board.direction.DOWN, sam);
            e = board.getEffectAt(Board.makeBoardLocation(3, 4));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2,5), Board.direction.DOWN, Board.direction.LEFT, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(2, 5));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3,4), Board.direction.RIGHT, Board.direction.UP, 1, 2));

            sam = new WatchfireTile();
            game.placeTileAtPosition(Board.makeBoardLocation(5, 5), Board.direction.LEFT, sam);
            e = board.getEffectAt(Board.makeBoardLocation(5, 6));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(4,5), Board.direction.LEFT, Board.direction.UP, 1, 2));

            e = board.getEffectAt(Board.makeBoardLocation(4, 5));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(5,6), Board.direction.DOWN, Board.direction.RIGHT, 1, 2));
        }

        [Test]
        public void TestWatchFireWrap()
        {
            GameInfo game;
            Board board;
            List<Effect> e;
            WatchfireTile tile;
            Board.location loc;

            game = new GameInfo();
            board = game.getTileBoard();
            tile = new WatchfireTile();
            loc = Board.makeBoardLocation(0, 0);
            game.placeTileAtPosition(loc, Board.direction.UP,tile);
            e = board.getEffectAt(Board.makeBoardLocation(7,0));
            Assert.True(TestTiles.checkEffectListHas(e,Board.makeBoardLocation(0,7),Board.direction.UP,Board.direction.RIGHT,1,2));
            e= board.getEffectAt(Board.makeBoardLocation(0,7));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 0), Board.direction.LEFT, Board.direction.DOWN, 1, 2));

            game = new GameInfo();
            board = game.getTileBoard();
            tile = new WatchfireTile();
            loc = Board.makeBoardLocation(7, 0);
            game.placeTileAtPosition(loc, Board.direction.RIGHT, tile);
            e = board.getEffectAt(Board.makeBoardLocation(7, 7));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(0, 0), Board.direction.RIGHT, Board.direction.DOWN, 1, 2));
            e = board.getEffectAt(Board.makeBoardLocation(0, 0));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 7), Board.direction.UP, Board.direction.LEFT, 1, 2));

            game = new GameInfo();
            board = game.getTileBoard();
            tile = new WatchfireTile();
            loc = Board.makeBoardLocation(0, 7);
            game.placeTileAtPosition(loc, Board.direction.LEFT, tile);
            e = board.getEffectAt(Board.makeBoardLocation(0, 0));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 7), Board.direction.LEFT, Board.direction.UP, 1, 2));
            e = board.getEffectAt(Board.makeBoardLocation(7, 7));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(0, 0), Board.direction.DOWN, Board.direction.RIGHT, 1, 2));

            game = new GameInfo();
            board = game.getTileBoard();
            tile = new WatchfireTile();
            loc = Board.makeBoardLocation(7, 7);
            game.placeTileAtPosition(loc, Board.direction.DOWN, tile);
            e = board.getEffectAt(Board.makeBoardLocation(7, 0));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(0, 7), Board.direction.RIGHT, Board.direction.UP, 1, 2));
            e = board.getEffectAt(Board.makeBoardLocation(0, 7));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(7, 0), Board.direction.DOWN, Board.direction.LEFT, 1, 2));

        }

        [Test]
        public void TestWildFireEffectsPlacing()
        {
            GameInfo game = new GameInfo();
            WildfireTile watch;
            Board b = game.getTileBoard();
            List<Effect> counter = new List<Effect>();

            watch = new WildfireTile();
            game.placeTileAtPosition(Board.makeBoardLocation(3, 3), Board.direction.UP, watch);
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(2, 3)));
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(4, 3)));
            Assert.AreEqual(2, counter.Count);
            counter.Clear();

            watch = new WildfireTile();
            game.placeTileAtPosition(Board.makeBoardLocation(5, 3), Board.direction.RIGHT, watch);
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(5, 4)));
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(5, 2)));
            Assert.AreEqual(2, counter.Count);
            counter.Clear();

            watch = new WildfireTile();
            game.placeTileAtPosition(Board.makeBoardLocation(3, 4), Board.direction.DOWN, watch);
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(2, 4)));
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(4, 4)));
            Assert.AreEqual(2, counter.Count);
            counter.Clear();

            watch = new WildfireTile();
            game.placeTileAtPosition(Board.makeBoardLocation(6, 3), Board.direction.LEFT, watch);
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(6, 2)));
            counter.AddRange(b.getEffectAt(Board.makeBoardLocation(6, 4)));
            Assert.AreEqual(2, counter.Count);
            counter.Clear();

        }

        [Test]
        public void TestWildFireCorrect()
        {
            GameInfo game;
            Board.location loc;
            Board board;
            List<Effect> e;
            WildfireTile tile;

            game = new GameInfo();
            board = game.getTileBoard();
            tile = new WildfireTile();
            loc = Board.makeBoardLocation(3, 3);
            game.placeTileAtPosition(loc, Board.direction.UP, tile);
            e = board.getEffectAt(Board.makeBoardLocation(2, 3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(4, 3), Board.direction.UP, Board.direction.DOWN, 1, 2));
            e = board.getEffectAt(Board.makeBoardLocation(4, 3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2, 3), Board.direction.UP, Board.direction.DOWN, 1, 2));

            game = new GameInfo();
            board = game.getTileBoard();
            tile = new WildfireTile();
            loc = Board.makeBoardLocation(3, 3);
            game.placeTileAtPosition(loc, Board.direction.RIGHT, tile);
            e = board.getEffectAt(Board.makeBoardLocation(3, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 4), Board.direction.RIGHT, Board.direction.LEFT, 1, 2));
            e = board.getEffectAt(Board.makeBoardLocation(3, 4));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3, 2), Board.direction.RIGHT, Board.direction.LEFT, 1, 2));

            game = new GameInfo();
            board = game.getTileBoard();
            tile = new WildfireTile();
            loc = Board.makeBoardLocation(3, 3);
            game.placeTileAtPosition(loc, Board.direction.DOWN, tile);
            e = board.getEffectAt(Board.makeBoardLocation(2, 3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(4,3), Board.direction.DOWN, Board.direction.UP, 1, 2));
            e = board.getEffectAt(Board.makeBoardLocation(4, 3));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(2,3), Board.direction.DOWN, Board.direction.UP, 1, 2));

            game = new GameInfo();
            board = game.getTileBoard();
            tile = new WildfireTile();
            loc = Board.makeBoardLocation(3, 3);
            game.placeTileAtPosition(loc, Board.direction.LEFT, tile);
            e = board.getEffectAt(Board.makeBoardLocation(3, 2));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3,4), Board.direction.LEFT, Board.direction.RIGHT, 1, 2));
            e = board.getEffectAt(Board.makeBoardLocation(3, 4));
            Assert.True(TestTiles.checkEffectListHas(e, Board.makeBoardLocation(3,2), Board.direction.LEFT, Board.direction.RIGHT, 1, 2));



        }

    }
}
