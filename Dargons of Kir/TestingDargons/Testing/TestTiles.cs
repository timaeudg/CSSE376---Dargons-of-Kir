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
            Assert.NotNull(tile);
        }
        [Test]
        public void TestInitTwoRivers()
        {
            TwoRiversTile tile = new TwoRiversTile();
            Assert.NotNull(tile);
        }
        [Test]
        public void TestInitThreeRivers()
        {
            ThreeRiversTile tile = new ThreeRiversTile();
            Assert.NotNull(tile);
        }
        [Test]
        public void TestInitSamurai()
        {
            SamuraiTile tile = new SamuraiTile();
            Assert.NotNull(tile);
        }
        [Test]
        public void TestInitRonin()
        {
            RoninTile tile = new RoninTile();
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
            WatchfireTile tile = new WatchfireTile();
            Assert.NotNull(tile);
        }
        [Test]
        public void TestInitWildfire()
        {
            WildfireTile tile = new WildfireTile();
            Assert.NotNull(tile);
        }
        [Test]
        public void TestInitLotusFlower()
        {
            LotusFlowerTile tile = new LotusFlowerTile();
            Assert.NotNull(tile);
        }
        [Test]
        public void TestInitLotusPond()
        {
            LotusPondTile tile = new LotusPondTile();
            Assert.NotNull(tile);
        }
        [Test]
        public void TestInitWind()
        {
            WindTile tile = new WindTile();
            Assert.NotNull(tile);
        }
        [Test]
        public void TestInitStorm()
        {
            StormTile tile = new StormTile();
            Assert.NotNull(tile);
        }
        [Test]
        public void TestInitDragonsLair()
        {
            DragonsLairTile tile = new DragonsLairTile();
            Assert.NotNull(tile);
        }
        [Test]
        public void TestInitDragonBreath()
        {
            DragonBreathTile tile = new DragonBreathTile();
            Assert.NotNull(tile);
        }
        [Test]
        public void TestInitWarTent()
        {
            Player player = new Player();
            WarTentTile tile = new WarTentTile();
            Assert.NotNull(tile);
        }
    }
}
