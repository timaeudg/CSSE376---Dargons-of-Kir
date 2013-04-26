using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dargons_of_Kir
{
    public class Player
    {
        public Tile[] hand { get; private set; }
        private GameInfo gameInfo;
        public int PlayerID;
        private static int IDSEED=0;
        private static Random randGenerator = new Random();


        public Player(GameInfo game)
        {
            this.hand = new Tile[4];
            this.gameInfo = game;
            for (int i = 0; i < 4; i++)
            {
                this.drawTile();
            }
            this.PlayerID = IDSEED;
            IDSEED++;
        }

        public bool Equals(Player ply)
        {
            return ply.PlayerID == this.PlayerID;
        }

        public void drawTile()
        {
            List<Tile> pile = this.gameInfo.drawPile;
            for (int i = 0; i < 4; i++)
            {
                if (hand[i] == null)
                {
                    Tile toRemove = pile[randGenerator.Next(0, pile.Count-1)];
                    pile.Remove(toRemove);
                    hand[i] = toRemove;
                    break;
                }
            }

        }
    }
}