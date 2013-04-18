using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dargons_of_Kir
{
    public static class MainRunner
    {

        public static GameInfo game;
        public static Player p1;
        public static Player p2;
        public static GameScreen screen;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainRunner.createGame();
            MainRunner.createPlayers();
            MainRunner.addPlayersToGame();
            MainRunner.makeScreen();
            Application.Run(screen);
        }

        public static void createGame()
        {
            game = new GameInfo();

        }

        public static void createPlayers()
        {
            p1 = new Player(game);
            p2 = new Player(game);
        }

        public static void addPlayersToGame()
        {
            List<Player> pList = new List<Player>();
            pList.Add(p1);
            pList.Add(p2);
            game.setPlayersAndTents(pList);
        }


        public static void makeScreen()
        {
            screen = new GameScreen(game);

        }

    }
}
