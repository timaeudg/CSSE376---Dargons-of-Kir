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
            Board board = game.getTileBoard();
            for (int k = 0; k < 8; k++)
            {
                for (int i = 0; i < 8; i++)
                {
                    Assert.Null(board.getBoard()[k,i].tile);
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
        public void testMakePile()
        {
            GameInfo game = new GameInfo();       
            Assert.NotNull(game.getTilePile());
            
        }

        [Test]
        public void testMakePileStarting()
        {
            GameInfo game = new GameInfo();
            List<Tile> pile = game.getTilePile();

            int ID = 0;

            foreach (Tile t in pile)
            {
                Assert.NotNull(t);
                Assert.NotNull(t.getPicture());
            }
            Assert.True(56 == pile.Count);
        }

        [Test]
        public void uniqueTileIDs()
        {
            GameInfo game = new GameInfo();
            List<Tile> pile = game.getTilePile();
            Assert.That(pile, Is.Unique);
        }

        [Test]
        public void testGetNextPlayer()
        {
            GameInfo game = new GameInfo();
            Player p1 = new Player(game);
            Player p2 = new Player(game);
            Player p3 = new Player(game);

            List<Player> pList = new List<Player>();
            pList.Add(p1);
            pList.Add(p2);
            pList.Add(p3);

            game.setPlayerList(pList);
            Player pTest;
            for (int k = 0; k < 100; k++)
            {
                pTest = game.getNextPlayer();
                Assert.AreEqual(p1, pTest);

                pTest = game.getNextPlayer();
                Assert.AreEqual(p2, pTest);

                pTest = game.getNextPlayer();
                Assert.AreEqual(p3, pTest);
            }

        }

        [Test]
        public void testMakeAndSetDragons()
        {
            GameInfo game = new GameInfo();

            LinkedList<Dragon> drags = game.getDragons();
            bool enteredLoop = false;

            foreach (Dragon d in drags)
            {
                Assert.NotNull(d);
                Assert.NotNull(d.getCurrentPosition());
                Assert.NotNull(d.getOrientation());
                Assert.NotNull(d.getDragonID());
                enteredLoop = true;
            }
            Assert.True(enteredLoop);
        }


    }
    
}
