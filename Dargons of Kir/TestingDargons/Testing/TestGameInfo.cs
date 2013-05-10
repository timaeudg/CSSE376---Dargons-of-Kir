using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Dargons_of_Kir;
using Dargons_of_Kir.Tiles;



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

        /*
        [Test]
        public void testGameInfoDragonsNullAtStart(){
            GameInfo game = new GameInfo();
            LinkedList<Dragon> dragons = game.getDragons();
            foreach (Dragon drag in dragons){
                Assert.Null(drag);
            }
        }
        */

       

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

            foreach (Tile t in pile)
            {
                Assert.NotNull(t);
                Assert.NotNull(t.getPicture());
            }
            Assert.True(64 == pile.Count);
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

            game.setPlayersAndTents(pList);
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
            game.makeDragonsAndSetPositions();
            List<Dragon> drags = game.getDragons();
            bool enteredLoop = false;

            foreach (Dragon d in drags)
            {
                Assert.NotNull(d);
                Assert.NotNull(d.getCurrentPosition());
                Assert.NotNull(d.orientation);
                Assert.NotNull(d.getDragonID());
                enteredLoop = true;
            }
            Assert.True(enteredLoop);
        }

        [Test]
        public void testPlaceTileAtPosition()
        {
            Tile toPlace = new DragonsLairTile();
            GameInfo game = new GameInfo();
            Assert.Null(game.getTileBoard().getTileAt(3, 3));
            Board.location loc = new Board.location();
            loc.x =3;
            loc.y=3;
            game.placeTileAtPosition(loc, Board.orientation.LEFT, toPlace);
            Assert.AreSame(toPlace, game.getTileBoard().getTileAt(3, 3));
            Assert.AreEqual(Board.orientation.LEFT, game.getTileBoard().getTileAt(3, 3).orientation);

        }

        [Test]
        public void testCanPlace()
        {
            GameInfo game = new GameInfo();
            Player p1 = new Player(game);
            Player p2 = new Player(game);
            List<Player> pList = new List<Player>();
            pList.Add(p1);
            pList.Add(p2);
            game.setPlayersAndTents(pList);
            Board.location loc = Board.makeBoardLocation(5, 6);
            Assert.True(game.canPlace(loc));

            Player next = game.getNextPlayer();
            Tile toPlay = next.takeTileFromHand(0);
            game.placeTileAtPosition(loc, Board.orientation.DOWN, toPlay);
            Assert.AreSame(toPlay, game.getTileBoard().getTileAt(5, 6));
            Assert.False(game.canPlace(loc));

            game.makeDragonsAndSetPositions();
            Assert.False(game.canPlace(Board.makeBoardLocation(5, 5)));


        }

        [Test]
        public void testSetPlayersAndTents()
        {
            GameInfo game = new GameInfo();
            Player p1 = new Player(game);
            Player p2 = new Player(game);
            List<Player> pList = new List<Player>();
            pList.Add(p1);
            pList.Add(p2);
            game.setPlayersAndTents(pList);

        }

        [Test]
        public void testCannotPlaceTilesOnWarTents()
        {
            GameInfo game = new GameInfo();
            Player p1 = new Player(game);
            Player p2 = new Player(game);
            List<Player> pList = new List<Player>();
            pList.Add(p1);
            pList.Add(p2);
            game.setPlayersAndTents(pList);
            Assert.False(game.canPlace(Board.makeBoardLocation(0, 0)));
            Assert.False(game.canPlace(Board.makeBoardLocation(7, 7)));
        }

        [Test]
        public void testMoveDragons()
        {
            GameInfo game = new GameInfo();

            Assert.AreEqual(Board.makeBoardLocation(2, 2), game.getDragons()[0].getCurrentPosition());
            Assert.AreEqual(Board.makeBoardLocation(5, 2), game.getDragons()[1].getCurrentPosition());
            Assert.AreEqual(Board.makeBoardLocation(2, 5), game.getDragons()[2].getCurrentPosition());
            Assert.AreEqual(Board.makeBoardLocation(5, 5), game.getDragons()[3].getCurrentPosition());


            game.moveDragons();

            Assert.AreEqual(Board.makeBoardLocation(2, 3), game.getDragons()[0].getCurrentPosition());
            Assert.AreEqual(Board.makeBoardLocation(4, 2), game.getDragons()[1].getCurrentPosition());
            Assert.AreEqual(Board.makeBoardLocation(3, 5), game.getDragons()[2].getCurrentPosition());
            Assert.AreEqual(Board.makeBoardLocation(5, 4), game.getDragons()[3].getCurrentPosition());


        }

        [Test]
        public void testEndGame()
        {
            GameInfo game = new GameInfo();
            game.endGame(1);
            Assert.AreEqual(1, game.getPlayerWon());
            game.endGame(2);
            Assert.AreEqual(2, game.getPlayerWon());

        }

        [Test]
        public void testGameEnding()
        {
            GameInfo game = new GameInfo();
            Player p1 = new Player(game);
            Player p2 = new Player(game);
            List<Player> list = new List<Player>();

            list.Add(p1);
            list.Add(p2);
            game.setPlayersAndTents(list);

            List<Dragon> drags = game.getDragons();
            drags.Add(new Dragon(0, Board.makeBoardLocation(6, 7), Board.orientation.RIGHT));

            game.moveDragons();
            Assert.AreEqual(1, game.getPlayerWon());

            game = new GameInfo();
            p1 = new Player(game);
            p2 = new Player(game);
            list = new List<Player>();
            list.Add(p1); list.Add(p2);
            game.setPlayersAndTents(list);
            drags = game.getDragons();
            drags.Add(new Dragon(0, Board.makeBoardLocation(0, 1), Board.orientation.UP));
            game.moveDragons();
            Assert.AreEqual(2, game.getPlayerWon());


            game = new GameInfo();
            p1 = new Player(game);
            p2 = new Player(game);
            list = new List<Player>();
            list.Add(p1); list.Add(p2);
            game.setPlayersAndTents(list);
            drags = game.getDragons();
            drags.Add(new Dragon(0, Board.makeBoardLocation(0, 1), Board.orientation.UP));
            drags.Add(new Dragon(1, Board.makeBoardLocation(6, 7), Board.orientation.RIGHT));
            game.moveDragons();
            Assert.AreEqual(3, game.getPlayerWon());
            

        }


        [Test]
        public void testNewGame()
        {
            GameInfo game = new GameInfo();
            Player p1 = new Player(game);
            Player p2 = new Player(game);
            List<Player> list = new List<Player>();

            list.Add(p1);
            list.Add(p2);

            game.setPlayersAndTents(list);

            List<Dragon> drags = game.getDragons();
            drags.Add(new Dragon(0, Board.makeBoardLocation(6, 7), Board.orientation.RIGHT));

            game.placeTileAtPosition(Board.makeBoardLocation(3, 4), Board.orientation.LEFT, game.getNextPlayer().takeTileFromHand(0));
            game.makeNewGame();
            Assert.AreEqual(4, game.getDragons().Count);
            Assert.AreEqual(64, game.getTilePile().Count);
            Assert.AreEqual(-1, game.getPlayerWon());


        }

        [Test]
        public static void testDragonTilePlace()
        {
            GameInfo game = new GameInfo();
            game.makeDragonsAndSetPositions();
            DragonBreathTile breath = new DragonBreathTile();

            Assert.True(GameInfo.dragonTilePlace(breath, 2, 2, game));
            Assert.False(GameInfo.dragonTilePlace(new MonkTile(), 5, 5, game));

        }


    }
    
}
