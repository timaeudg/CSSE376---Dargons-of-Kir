using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dargons_of_Kir;
using NUnit.Framework;
using System.Windows;

namespace TestingDargons.Testing
{
    [TestFixture]
    class TestMainRunner
    {
        [Test]
        public void TestMakingGame()
        {
            MainRunner.createGame();
            GameInfo game = MainRunner.game;
            Assert.NotNull(game);

        }

        [Test]
        public void TestMakingPlayers()
        {
            MainRunner.createPlayers();
            Assert.NotNull(MainRunner.p1);
            Assert.NotNull(MainRunner.p2);

        }

        [Test]
        public void TestAddingPlayersToGame()
        {
            MainRunner.createGame();
            MainRunner.createPlayers();
            MainRunner.addPlayersToGame();
            GameInfo game = MainRunner.game;

            Assert.NotNull(game.getNextPlayer());
            Assert.NotNull(game.getNextPlayer());
        }

        [Test]
        public void TestMakingGameScreen()
        {

            MainRunner.createGame();
            MainRunner.createPlayers();
            MainRunner.addPlayersToGame();
            MainRunner.makeScreen();
            Assert.NotNull(MainRunner.screen);

        }

        [Test]
        public void TestRunningMain()
        {
            MainRunner.screen = null;
            MainRunner.Main();
            Assert.NotNull(MainRunner.game);
            Assert.NotNull(MainRunner.p2);
            Assert.NotNull(MainRunner.p1);
            Assert.NotNull(MainRunner.screen);
        }


    }
}
