using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;



namespace Dargons_of_Kir
{
     
    
    public class GameInfo
    {
        private List<Tile> pileOfTiles;
        private Board tileBoard;
        private List<Dragon> dragons;
        private List<Player> players;
        private Player currentPlayerTurn;

        public GameInfo()
        {
            this.pileOfTiles = new List<Tile>();
            this.tileBoard = new Board();
            this.dragons = new List<Dragon>();
            this.makePile();
            this.players = new List<Player>();
            this.currentPlayerTurn = null;
            this.makeDragonsAndSetPositions();
        }

        public List<Tile> getTilePile()
        {
            return this.pileOfTiles;
        }

        public List<Dragon> getDragons()
        {
            return this.dragons;
        }

        public Board getTileBoard()
        {
            return this.tileBoard;
        }

        public List<Type> makePile(){
            List<Type> types = new List<Type>();
            int counter = 0;
            foreach (Type c in Assembly.GetAssembly(typeof(Tile)).GetTypes().Where(myType => myType.IsClass && myType.IsSubclassOf(typeof(Tile))))
            {
                    types.Add(c);
                    for (int k = 0; k < 4; k++)
                    {
                        Tile tmp = (Tile)Activator.CreateInstance(c, null);
                        if (tmp.getDrawable())
                        {
                            pileOfTiles.Add(tmp);
                            counter++;
                        }
                    }
                    counter++;
            }
           return types;
        }

        public void setPlayerList(List<Player> plyrs)
        {
            this.players = plyrs;
            WarTentTile tent = new WarTentTile(this.players[0], Board.makeBoardLocation(0,0));
            this.placeTileAtPosition(Board.makeBoardLocation(0, 0), Board.orientation.UP, tent);
            tent = new WarTentTile(this.players[1], Board.makeBoardLocation(7, 7));
            this.placeTileAtPosition(Board.makeBoardLocation(7, 7), Board.orientation.UP, tent);
        }

        public void setPlayersAndTents(List<Player> players)
        {
            this.setPlayerList(players);
            Board.location loc = new Board.location();
            loc.x=0;
            loc.y=0;
            tileBoard.addPiece(new WarTentTile(players[0], loc));
            loc = new Board.location();
            loc.x = 7;
            loc.y = 7;
            tileBoard.addPiece(new WarTentTile(players[1], loc));
        }

        public Player getNextPlayer()
        {
            Player toReturn;
            
            if(this.currentPlayerTurn == null){
                toReturn = this.players[0];
                this.currentPlayerTurn = this.players[0];
            }
            else{
                toReturn = this.players[(this.players.IndexOf(this.currentPlayerTurn)+1)%(this.players.Count)];
                this.currentPlayerTurn = toReturn;
            }


            return toReturn;
        }


        public void makeDragonsAndSetPositions()
        {
            Board.location loc = new Board.location();
            loc.x = 2;
            loc.y = 2;
            Dragon dragTopLeft = new Dragon(0, loc, Board.orientation.DOWN);
            loc = new Board.location();
            loc.x = 5;
            loc.y = 2;
            Dragon dragTopRight = new Dragon(1, loc, Board.orientation.LEFT);
            loc = new Board.location();
            loc.x = 2;
            loc.y = 5;
            Dragon dragBotLeft = new Dragon(2, loc, Board.orientation.RIGHT);
            loc = new Board.location();
            loc.x = 5;
            loc.y = 5;
            Dragon dragBotRight = new Dragon(3, loc, Board.orientation.UP);

            this.dragons.Add(dragTopLeft);
            this.dragons.Add(dragTopRight);
            this.dragons.Add(dragBotLeft);
            this.dragons.Add(dragBotRight);
     


        }

        public bool canPlace(Board.location loc){
            if (this.tileBoard.getTileAt(loc.x, loc.y) == null)
            {
                return true;

            }
            else
            {
                return false;
            }

        }

        public void placeTileAtPosition(Board.location place, Board.orientation orient, Tile tile)
        {
            tile.place(place, orient);
            this.tileBoard.addPiece(tile);
            tile.placeEffects(this.tileBoard);

        }

        public bool destroyTileAt(Board.location loc)
        {
            if (!canPlace(loc))
            {
                this.tileBoard.destroyTileAt(loc.x, loc.y);
                return true;
            }
            else
            {
                return false;
            }

        }

        public void moveDragons()
        {
           List<Tile> toDelete = new List<Tile>();
           for (int i = 0; i < this.dragons.Count; i++ )
           {
               toDelete.AddRange(dragons[i].move(tileBoard));
           }
            foreach (Tile t in toDelete)
            {
                destroyTileAt(t.location);
            }
        }
    }
}
