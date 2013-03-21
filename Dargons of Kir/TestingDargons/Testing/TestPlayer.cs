using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dargons_of_Kir;

namespace TestingDargons
{
    [TestFixture]
    public class TestPlayer
    {
        private GameInfo game = new GameInfo();
        [Test]
        public void playersAreCreatable()
        {
            Player player = new Player(game);
            Assert.NotNull(player);
        }
        [Test]
        public void playersAreThemSelves()
        {
            Player player1 = new Player(game);
            Player player2 = new Player(game);
            Assert.AreEqual(player1, player1);
            Assert.AreEqual(player2, player2);
            Assert.AreNotEqual(player1, player2);
        }
        [Test]
        public void playerDrawTileDoesNotError()
        {
            Player player = new Player(game);
            player.drawTile();
        }
        [Test]
        public void playerTakeTurns()
        {
            Player player = new Player(game);
            try
            {
                player.takeTurn();
            }
            catch (NotImplementedException e)
            {
                Assert.IsTrue(true);
            }
        }

    }
}
