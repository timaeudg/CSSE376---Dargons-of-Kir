using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Dargons_of_Kir.Tiles;



namespace Dargons_of_Kir
{
     
    
    public class GameInfo
    {
        public List<Tile> drawPile {get; private set;}
        public Board board { get; private set; }
        public List<Dragon> dragons { get; private set; }
        public List<Player> players { get; private set; }
        public Player currentPlayer { get; private set; }
        private int winningPlayer = -1;

        public GameInfo()
        {
            this.drawPile = new List<Tile>();
            this.board = new Board();
            this.dragons = new List<Dragon>();
            this.makePile();
            this.players = new List<Player>();
            this.currentPlayer = null;
            this.makeDragonsAndSetPositions();
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
                            drawPile.Add(tmp);
                            counter++;
                        }
                    }
                    counter++;
            }
           return types;
        }

        public void setPlayersAndTents(List<Player> players)
        {
            this.players = players;
            board.addTile(new WarTentTile(players[0], new Board.location(0, 0)));
            board.addTile(new WarTentTile(players[1], new Board.location(7, 7)));
        }

        public Player getNextPlayer()
        {
            Player toReturn;
            
            if(this.currentPlayer == null){
                toReturn = this.players[0];
                this.currentPlayer = this.players[0];
            }
            else{
                toReturn = this.players[(this.players.IndexOf(this.currentPlayer)+1)%(this.players.Count)];
                this.currentPlayer = toReturn;
            }


            return toReturn;
        }


        public void makeDragonsAndSetPositions()
        {
            Board.location loc = new Board.location(2,2);
            Dragon dragTopLeft = new Dragon(0, loc, Board.direction.DOWN);
            loc = new Board.location(5,2);
            Dragon dragTopRight = new Dragon(1, loc, Board.direction.LEFT);
            loc = new Board.location(2,5);
            Dragon dragBotLeft = new Dragon(2, loc, Board.direction.RIGHT);
            loc = new Board.location(5,5);
            Dragon dragBotRight = new Dragon(3, loc, Board.direction.UP);

            this.dragons.Add(dragTopLeft);
            this.dragons.Add(dragTopRight);
            this.dragons.Add(dragBotLeft);
            this.dragons.Add(dragBotRight);
        }

        public bool canPlace(Board.location loc){
            if (this.board[loc].tile == null)
            {
                foreach (Dragon d in this.dragons)
                {
                    if (loc.x == d.position.x && loc.y == d.position.y)
                    {
                        return false;
                    }
                }
                return true;

            }
            else
            {
                return false;
            }

        }

        public void placeTileAtPosition(Board.location place, Board.direction orient, Tile tile)
        {
            if (winningPlayer < 0)
            {
                tile.place(place, orient);
                this.board.addTile(tile);
                tile.placeEffects(this.board);
            }

        }

        public void moveDragons()
        {
            if (this.winningPlayer < 0)
            {
                List<Tile> toDelete = new List<Tile>();
                bool p1Win = false;
                bool p2Win = false;
                foreach (Dragon d in this.dragons)
                {
                         if (this.board[d.position].tile != null)
                        {
                            Tile dragonTile = this.board[d.position].tile;
                            if (dragonTile.GetType() == typeof(DragonsLairTile))
                            {
                                toDelete.Add(dragonTile);
                            }
                            else
                            {
                                List<Tile> dragonDestroy = new List<Tile>();
                                Board.location dragonLoc = d.position;
                                List<Board.location> locsToDestroy = new List<Board.location>();
                                locsToDestroy.Add(new Board.location(dragonLoc.x - 1, dragonLoc.y));
                                locsToDestroy.Add(new Board.location(dragonLoc.x + 1, dragonLoc.y));
                                locsToDestroy.Add(new Board.location(dragonLoc.x, dragonLoc.y - 1));
                                locsToDestroy.Add(new Board.location(dragonLoc.x, dragonLoc.y + 1));
                                foreach (Board.location l in locsToDestroy)
                                {
                                    dragonDestroy.Add(this.board[l].tile);
                                }
                                foreach (Tile t in dragonDestroy)
                                {
                                    if (t != null)
                                    {
                                        this.board.destroyTile(t.location);
                                        if (MainRunner.screen != null)
                                        {
                                            MainRunner.screen.clearCell(t.location);
                                        }
                                    }
                                }
                                toDelete.AddRange(d.move(board));
                            }


                        }
                        else{
                            toDelete.AddRange(d.move(board));
                        }
                }
                foreach (Tile t in toDelete)
                {
                    if (this.board[0, 0].tile == t)
                    {
                        p2Win = true;
                    }
                    if (this.board[7, 7].tile == t)
                    {
                        p1Win = true;
                    }
                    board.destroyTile(t.location);
                    if (MainRunner.screen != null)
                    {
                        MainRunner.screen.clearCell(t.location);
                    }
                }

                if (p2Win && p1Win)
                {
                    this.endGame(3);
                }
                else if (p2Win)
                {
                    this.endGame(2);
                }
                else if (p1Win)
                {
                    this.endGame(1);
                }
            }

        }

        public void endGame(int p)
        {
            this.winningPlayer = p;
            if (MainRunner.screen != null)
            {
                if (GameScreen.promptForNewGame(this.winningPlayer))
                {
                    this.makeNewGame();
                }
            }
        }

        public void makeNewGame()
        {
            this.winningPlayer = -1;
            this.board = new Board();
            this.drawPile = new List<Tile>();
            this.dragons = new List<Dragon>();
            this.makePile();
            this.setPlayersAndTents(this.players);
            this.makeDragonsAndSetPositions();
            GameScreen screen = MainRunner.screen;
            if (screen != null)
            {
                screen.resetScreen();
            }
        }

        public static bool dragonTilePlace(Tile selected, int p1, int p2, GameInfo game)
        {
            
            Type tile = selected.GetType();
            Board.location loc =  new Board.location(p1, p2);
            if (tile == typeof(DragonBreathTile) || tile == typeof(DragonsLairTile))
            {
                foreach (Dragon d in game.dragons)
                {
                    if (d.position.Equals(loc))
                    {
                        return true;
                    }

                }

            }


            return false;
        }
    }
}
