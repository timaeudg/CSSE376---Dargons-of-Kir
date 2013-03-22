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
        public Player(GameInfo game)
        {
            this.gameInfo = game;
            this.drawTile();
            this.drawTile();
            this.drawTile();
            this.drawTile();
        }

        public void drawTile()
        {
            // tiles.Add(pile.draw());
            // this will be fixed when devon tells me what frack is storing our tiles.

            List<Tile> pile = this.gameInfo.getTilePile();
            Random generator = new Random();
            for (int i = 0; i < 4; i++)
            {
                if (tiles[i] == null)
                {
                    Tile toRemove = pile[generator.Next(0, pile.Count)];
                    pile.Remove(toRemove);
                    tiles[i] = toRemove;
                    break;
                }
            }

        }

    }
}