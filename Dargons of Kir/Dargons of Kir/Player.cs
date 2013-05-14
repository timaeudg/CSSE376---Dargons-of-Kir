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
        private Tile[] tiles = new Tile[4];
        private GameInfo gameInfo;
        public int PlayerID;
        private static int IDSEED=0;
        private static Random randGenerator = new Random();


        public Player(GameInfo game)
        {
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
            

            List<Tile> pile = this.gameInfo.getTilePile();
            for (int i = 0; i < 4; i++)
            {
                if (tiles[i] == null)
                {
                    Tile toRemove = pile[randGenerator.Next(0, pile.Count-1)];
                    pile.Remove(toRemove);
                    tiles[i] = toRemove;
                    break;
                }
            }

        }

        public Tile takeTileFromHand(int index)
        {
            Tile toReturn = tiles[index];
            tiles[index] = null;
            drawTile();
            return toReturn;
        }

        public Tile[] getHand()
        {
            return this.tiles;
        }

    }
}