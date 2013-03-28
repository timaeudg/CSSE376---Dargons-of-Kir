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
        private LinkedList<Dragon> dragons;
        private List<Player> players;
        private List<WarTentTile> tents;
        private Player currentPlayerTurn;

        public GameInfo()
        {
            this.pileOfTiles = new List<Tile>();
            this.tileBoard = new Board();
            this.dragons = new LinkedList<Dragon>();
            this.makePile();
            this.players = new List<Player>();
            this.currentPlayerTurn = null;
        }

        public List<Tile> getTilePile()
        {
            return this.pileOfTiles;
        }

        public LinkedList<Dragon> getDragons()
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
            foreach(Type c in Assembly.GetAssembly(typeof(Tile)).GetTypes().Where(myType=> myType.IsClass && myType.IsSubclassOf(typeof(Tile)))){
                types.Add(c);
                for(int k = 0; k<4; k++){
                    pileOfTiles.Add((Tile)Activator.CreateInstance(c,null));
                    counter++;
                }
                counter++;
            }
           return types;
        }

        public void setPlayerList(List<Player> plyrs)
        {
            this.players = plyrs;
        }

        public void setPlayersAndTents(List<Player> players)
        {
            this.setPlayerList(players);
            Board.location loc = new Board.location();
            loc.x=0;
            loc.y=0;
            WarTentTile tent = new WarTentTile(players[0], loc);
            this.tents.Add(tent);
            loc = new Board.location();
            loc.x = 7;
            loc.y = 7;
            tent = new WarTentTile(players[1], loc);
            this.tents.Add(tent);
            
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

            this.dragons.AddLast(dragTopLeft);
            this.dragons.AddLast(dragTopRight);
            this.dragons.AddLast(dragBotLeft);
            this.dragons.AddLast(dragBotRight);


        }


    }
}
