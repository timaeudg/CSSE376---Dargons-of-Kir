﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dargons_of_Kir;
using NUnit.Framework;

namespace TestingDargons
{
    [TestFixture]
    class TestWarTent
    {

        [Test]
        public void TestInitWarTent()
        {
            GameInfo game = new GameInfo();
            Player player = new Player(game);
            Board.location loc = new Board.location();
            loc.x = 0;
            loc.y = 0;
            WarTentTile tile = new WarTentTile(player, loc);
            Assert.NotNull(tile);
            Assert.IsFalse(WarTentTile.Drawable);
            Assert.IsTrue(Tile.Drawable);
        }

        [Test]
        public void TestGetPic()
        {
            GameInfo game = new GameInfo();
            Player player = new Player(game);
            Board.location loc = new Board.location();
            loc.x = 0;
            loc.y = 0;
            WarTentTile tile = new WarTentTile(player, loc);
            Assert.NotNull(WarTentTile.getPic());
            //Ensure both red and blue tiles generate images
            tile = new WarTentTile(player, loc);
            Assert.NotNull(WarTentTile.getPic());
        }

        [Test]
        public void TestCallback()
        {
            GameInfo game = new GameInfo();
            Player player = new Player(game);
            Board.location loc = new Board.location();
            loc.x = 0;
            loc.y = 0;
            WarTentTile tile = new WarTentTile(player, loc);
  
            Assert.IsTrue(tile.callback()); //This will always take effect
        }

        [Test]
        public void TestWartentCallback()
        {
            Tile wartent = new WarTentTile();
            Assert.True(wartent.callback());
        }

    }
}
