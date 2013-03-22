using System;
using NUnit.Framework;
using Dargons_of_Kir;

namespace TestingDargons.Testing
{
    [TestFixture]
    public class TestTiles
    {
        [Test]
        public void TestInitSingleRiver()
        {
            MonkTile tile = new SingleRiverTile();
            Assert.NotNull(tile);
        }
        [Test]
        public void TestInitTwoRivers()
        {
            MonkTile tile = new TwoRiversTile();
            Assert.NotNull(tile);
        }
        [Test]
        public void TestInitThreeRivers()
        {
            MonkTile tile = new ThreeRiversTile();
            Assert.NotNull(tile);
        }
        [Test]
        public void TestInitSamurai()
        {
            MonkTile tile = new SamuraiTile();
            Assert.NotNull(tile);
        }
        [Test]
        public void TestInitRonin()
        {
            MonkTile tile = new RoninTile();
            Assert.NotNull(tile);
        }
        [Test]
        public void TestInitMonk()
        {
            MonkTile tile = new MonkTile();
            Assert.NotNull(tile);
        }
        [Test]
        public void TestInitWatchfire()
        {
            MonkTile tile = new WatchfireTile();
            Assert.NotNull(tile);
        }
        [Test]
        public void TestInitWildfire()
        {
            MonkTile tile = new MonkTile();
            Assert.NotNull(tile);
        }
        [Test]
        public void TestInitLotusFlower()
        {
            MonkTile tile = new LotusFlowerTile();
            Assert.NotNull(tile);
        }
        [Test]
        public void TestInitLotusPond()
        {
            MonkTile tile = new LotusPondTile();
            Assert.NotNull(tile);
        }
        [Test]
        public void TestInitWind()
        {
            MonkTile tile = new WindTile();
            Assert.NotNull(tile);
        }
        [Test]
        public void TestInitStorm()
        {
            MonkTile tile = new StormTile();
            Assert.NotNull(tile);
        }
        [Test]
        public void TestInitDragonsLair()
        {
            MonkTile tile = new DragonsLairTile();
            Assert.NotNull(tile);
        }
        [Test]
        public void TestInitDragonBreath()
        {
            MonkTile tile = new DragonBreathTile();
            Assert.NotNull(tile);
        }
    }
}
