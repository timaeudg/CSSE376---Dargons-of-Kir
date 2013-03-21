using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Dargons_of_Kir;



namespace TestingDargons
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

        [Test]
        public void testGameInfoGetPile()
        {
            GameInfo game = new GameInfo();
            Assert.NotNull(game.getTilePile());

        }

        [Test]
        public void testGameInfoDragons()
        {
            GameInfo game = new GameInfo();
            Assert.NotNull(game.getDragons());
        }

        [Test]
        public void testGameInfoTileBoard()
        {
            GameInfo game = new GameInfo();
            Assert.NotNull(game.getTileBoard());
        }

        [Test]
        public void testGameInfoTileBoardClearAtStart()
        {
            GameInfo game = new GameInfo();
            Tile[,] board = game.getTileBoard();
            for (int k = 0; k < 8; k++)
            {
                for (int i = 0; i < 8; i++)
                {
                    Assert.Null(board[k, i]);
                }
            }
        }

        [Test]
        public void testGameInfoDragonsNullAtStart(){
            GameInfo game = new GameInfo();
            LinkedList<Dragon> dragons = game.getDragons();
            foreach (Dragon drag in dragons){
                Assert.Null(drag);
            }
        }

        [Test]
        public void testGameInfoPileNullAtStart()
        {
            GameInfo game = new GameInfo();
            List<Tile> pile = game.getTilePile();
            foreach (Tile t in pile)
            {
                Assert.Null(t);
            }
        }

    }
    
}
