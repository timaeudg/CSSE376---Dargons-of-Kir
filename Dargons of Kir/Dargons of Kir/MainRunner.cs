using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dargons_of_Kir
{
    static class MainRunner
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            GameInfo game = new GameInfo();
            Player playerOne = new Player(game);
            Player playerTwo = new Player(game);
            List<Player> playerList = new List<Player>();
            playerList.Add(playerOne);
            playerList.Add(playerTwo);
            game.setPlayerList(playerList);
            GameScreen windowToRun = new GameScreen(game);
            Application.Run(new GameScreen());
        }
    }
}
