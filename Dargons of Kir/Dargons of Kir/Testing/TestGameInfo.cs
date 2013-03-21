using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;



namespace Dargons_of_Kir.Test
{
    [TestFixture]
    class TestGameInfo
    {
        [Test]
        public void testGameInfoCreate()
        {
            GameInfo game = new GameInfo();
            Assert.NotNull(game);
        }

    }
    /*
    [TestFixture]
    class TestPlayer
    {
        [Test]
        public void playersAreCreatable()
        {
            Player player = new Player();
            Assert.NotNull(player);
        }
        [Test]
        public void playersAreThemSelves()
        {
            Player player1 = new Player();
            Player player2 = new Player();
            Assert.AreEqual(player1, player1);
            Assert.AreEqual(player2, player2);
            Assert.AreNotEqual(player1, player2);
        }
        [Test]
        public void playerDrawTileDoesNotError()
        {
            Player player = new Player();
            player.drawTile();
        }
        [Test]
        public void playerTakeTurns()
        {
            Player player = new Player();
            try
            {
                player.takeTurn();
            }
            catch (NotImplementedException e)
            {
                Assert.IsTrue(true);
            }
        }

    }*/
}
