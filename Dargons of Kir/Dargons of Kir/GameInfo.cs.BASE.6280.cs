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
                    Object[] args = new Object[1];
                    args[0] = counter;
                    pileOfTiles.Add((Tile)Activator.CreateInstance(c,args));
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

    }
}
