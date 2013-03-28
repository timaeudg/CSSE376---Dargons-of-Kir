using System;
using NUnit.Framework;
using Dargons_of_Kir;
using Dargons_of_Kir.Tiles;

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
        public void TestInitWarTent()
        {
            GameInfo game = new GameInfo();
            Player player = new Player(game);
            WarTentTile tile = new WarTentTile(player);
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
    }
}
