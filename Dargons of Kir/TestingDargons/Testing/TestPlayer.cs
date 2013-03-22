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
    class TestPlayer
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
        public void playerCanRemoveTile()
        {
            Player player = new Player(game);
            Tile[] oldHand = (Tile[])player.getHand().Clone();
            player.takeTileFromHand(0);
            Tile[] hand = player.getHand();
            Assert.AreNotEqual(oldHand,hand);


        }

        [Test]
        public void playerCanRemoveThenRedrawHand()
        {
            Player player = new Player(game);
            for (int k = 0; k < 4; k++)
            {
                player.takeTileFromHand(k);
                player.drawTile();
            }
            for (int k = 0; k < 4; k++)
            {
                Assert.NotNull(player.getHand()[k]);
                Assert.NotNull(player.getHand()[k].getPicture());
            }
            Assert.AreEqual(48, game.getTilePile().Count);
        }

        [Test]
        public void twoPlayersInOneGame()
        {
            GameInfo twoGame = new GameInfo();
            Player player1 = new Player(twoGame);
            Player player2 = new Player(twoGame);

            Assert.AreEqual(48, twoGame.getTilePile().Count);
        }

    }
}
