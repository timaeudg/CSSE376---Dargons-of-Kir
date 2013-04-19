using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Dargons_of_Kir;
using Dargons_of_Kir.Tiles;
using System.Drawing;

namespace TestingDargons.Testing
{
    [TestFixture]
    class TestDragon
    {
        [Test]
        public void testList()
        {
            List<Dargons_of_Kir.Dragon.trueposition> list = new List<Dargons_of_Kir.Dragon.trueposition>();
            Board.location loc = new Board.location();
            loc.x = 4;
            loc.y = 4;
            Dragon drag = new Dragon(0, loc, Board.orientation.DOWN);
            Dragon.trueposition position = new Dragon.trueposition(drag.currentPosition, drag.orientation);
            Dragon.trueposition position2 = new Dragon.trueposition(drag.currentPosition, drag.orientation);
            list.Add(position);
            Assert.IsTrue(position2.alreadyVisited(list));

        }

        [Test]
        public void testMakingDragons(){
            Board.location loc = new Board.location();
            Dragon drag = new Dragon(0, loc, 0);
            Assert.NotNull(drag);
        }

        [Test]
        public void testGetDragonID()
        {
            Dragon drag;
            Board.location loc = new Board.location();
            for (int i = 0; i < 1000; i++)
            {
                drag = new Dragon(i, loc, 0);
                Assert.True(i==drag.getDragonID());
            }
        }

        [Test]
        public void testGetOrientation()
        {
            Dragon drag;
            Board.location loc = new Board.location();
            drag  = new Dragon(0,loc,Board.orientation.DOWN);
            Assert.True(Board.orientation.DOWN == drag.orientation);

        }


        [Test]
        public void testPreviousTileID()
        {
            Board.location loc = new Board.location();
            Dragon drag = new Dragon(0,loc, Board.orientation.LEFT);
            Tile tester = new MonkTile();
            drag.setPreviousTile(tester.getID());
            Assert.True(drag.getPreviousTile() == tester.getID());

        }

        [Test]
        public void testGetCurrentPosition()
        {
            Board.location loc = new Board.location();
            loc.x = 4;
            loc.y = -4;
            Dragon drag = new Dragon(0, loc, Board.orientation.RIGHT);
            Board.location dragLoc = drag.getCurrentPosition();
            Assert.True((dragLoc.x == loc.x) && (dragLoc.y == loc.y));

        }


        [Test]
        public void testSetOrientation()
        {
            Board.location loc = new Board.location();

            loc.x = 6;
            loc.y = 6;
            Dragon drag = new Dragon(0, loc, Board.orientation.RIGHT);
            Assert.AreEqual(drag.orientation, Board.orientation.RIGHT);
            drag.orientation = (Board.orientation.LEFT);
            Assert.AreEqual(drag.orientation, Board.orientation.LEFT);


        }

        [Test]
        public void testDragonMovement()
        {
            Board board = new Board();
            Board.location loc = new Board.location();
            loc.x = 4;
            loc.y = 4;
            Dragon drag = new Dragon(0, loc, Board.orientation.UP);
            Assert.AreEqual(drag.getCurrentPosition(), loc);
            drag.move(board);
            loc = new Board.location();
            loc.x = 4;
            loc.y = 3;
            Assert.AreEqual(drag.getCurrentPosition(), loc);
            drag.orientation = (Board.orientation.LEFT);
            drag.move(board);
            loc.x = 3;
            Assert.AreEqual(drag.getCurrentPosition(), loc);

        }

        [Test]
        public void testDragonWraparound()
        {
            Board board = new Board();
            Board.location loc = new Board.location();
            loc.x = 7;
            loc.y = 0;
            Dragon drag = new Dragon(0, loc, Board.orientation.RIGHT);
            drag.move(board);
            Board.location check = new Board.location();
            check.x = 0;
            check.y = 0;
            Assert.AreEqual(drag.getCurrentPosition(), check);

            drag.orientation = Board.orientation.UP;
            drag.move(board);
            check.y = 7;
            Assert.AreEqual(drag.getCurrentPosition(), check);

            drag.orientation = Board.orientation.DOWN;
            drag.move(board);
            check.y = 0;
            Assert.AreEqual(drag.getCurrentPosition(), check);
            drag.orientation = Board.orientation.LEFT;
            drag.move(board);
            check.x = 7;
            Assert.AreEqual(drag.getCurrentPosition(), check);

        }

        [Test]
        //Test that dragons both move and will rotate because of an effect.
        public void testDragonsFollowEffects()
        {
            Board board = new Board();
            Dragon dragon = new Dragon(0, Board.makeBoardLocation(4, 4), Board.orientation.LEFT);
            Effect eff = new Effect(Board.makeBoardLocation(2, 4), Board.orientation.LEFT, Board.orientation.UP, 0, 0, null);
            board.getBoard()[3, 4].getEffectList().Add(eff);
            dragon.move(board);
            Assert.AreEqual(2, dragon.getCurrentPosition().x);
            Assert.AreEqual(4, dragon.getCurrentPosition().y);
            Assert.AreEqual(Board.orientation.UP, dragon.orientation);

        }

        [Test]
        public void testDragonsChainEffects()
        {
            Board board = new Board();
            Dragon dragon = new Dragon(0, Board.makeBoardLocation(4, 4), Board.orientation.LEFT);
            Effect eff = new Effect(Board.makeBoardLocation(2, 4), Board.orientation.LEFT, Board.orientation.UP, 0, 0, null);
            board.getBoard()[3, 4].getEffectList().Add(eff);
            eff = new Effect(Board.makeBoardLocation(2, 3), Board.orientation.UP, Board.orientation.UP, 0, 0, null);
            board.getBoard()[2, 4].getEffectList().Add(eff);
            dragon.move(board);
            Assert.AreEqual(2, dragon.getCurrentPosition().x);
            Assert.AreEqual(3, dragon.getCurrentPosition().y);
            Assert.AreEqual(Board.orientation.UP, dragon.orientation);
        }

        [Test]
        public void testDragonsRemoveTilesAfterEffect()
        {
            Board board = new Board();
            Dragon dragon = new Dragon(0, Board.makeBoardLocation(4, 4), Board.orientation.LEFT);
            Effect eff = new Effect(Board.makeBoardLocation(2, 4), Board.orientation.LEFT, Board.orientation.UP, 0, 0, null);
            Tile tile = new SingleRiverTile();
            board.getBoard()[2, 4].tile = tile;
            board.getBoard()[3, 4].getEffectList().Add(eff);
            Assert.AreEqual(tile, dragon.move(board)[0]);
        }

        [Test]
        public void testDragonsRemoveTilesDuringEffects()
        {
            Board board = new Board();
            Dragon dragon = new Dragon(0, Board.makeBoardLocation(4, 4), Board.orientation.LEFT);
            Effect eff = new Effect(Board.makeBoardLocation(2, 4), Board.orientation.LEFT, Board.orientation.UP, 0, 0, null);
            board.getBoard()[3, 4].getEffectList().Add(eff);
            eff = new Effect(Board.makeBoardLocation(2, 3), Board.orientation.UP, Board.orientation.UP, 0, 0, null);
            board.getBoard()[2, 4].getEffectList().Add(eff);
            Tile tile = new SingleRiverTile();
            //tile.setOrientation(Board.orientation.
            board.getBoard()[2, 4].tile = tile;
            Assert.AreEqual(tile, dragon.move(board)[0]);
        }

        [Test]
        public void testDragonsRemoveTiles()
        {
            GameInfo game = new GameInfo();
            List<Dragon> drags = game.getDragons();
            Dragon dragon = new Dragon(0, Board.makeBoardLocation(4, 4), Board.orientation.LEFT);
            drags.Add(dragon);

            Tile tile = new SingleRiverTile();
            game.placeTileAtPosition(Board.makeBoardLocation(3, 4), Board.orientation.LEFT, tile);
            
            Assert.AreEqual(tile, dragon.move(game.getTileBoard())[0]);
        }

        [Test]
        public void testDragonsIgnoreTiles()
        {
            Board board = new Board();
            Dragon dragon = new Dragon(0, Board.makeBoardLocation(4, 4), Board.orientation.LEFT);
            Tile tile = new WindTile();
            tile.location = Board.makeBoardLocation(3, 3);
            tile.orientation = Board.orientation.RIGHT;
            tile.placeEffects(board);
            board.getBoard()[3, 3].tile = tile;
            dragon.move(board);
            Assert.AreEqual(Board.makeBoardLocation(3,5),dragon.currentPosition);
        }


        [Test]
        public void testDragonImage()
        {
            Board.location loc = new Board.location();
            loc.x = 7;
            loc.y = 0;
            Dragon drag = new Dragon(0, loc, Board.orientation.RIGHT);
            drag.setImage(Image.FromFile("..\\..\\..\\..\\images\\reddragon.JPG"));
            Assert.IsNotNull(drag.image);
        }
    }
}
