﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Dargons_of_Kir.Tiles;
using System.IO;



namespace Dargons_of_Kir
{
     
    
    public class GameInfo
    {
        private List<Tile> pileOfTiles;
        private Board tileBoard;
        private List<Dragon> dragons;
        private List<Player> players;
        private Player currentPlayerTurn;
        private int playerWon = -1;

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

        /*
         * Creates the pile of tiles according
         * to which tiles exist and then add them to 
         * the pile. Uses reflection
         */ 
        public List<Type> makePile(){
            List<Type> types = new List<Type>();
            int counter = 0;
            //uses reflection to look at the assembly, then check to see if they should be made, and make the tiles
            foreach (Type c in Assembly.GetAssembly(typeof(Tile)).GetTypes().Where(myType => myType.IsClass && myType.IsSubclassOf(typeof(Tile))))
            {
                    types.Add(c);
                    for (int k = 0; k < 4; k++)
                    {
                        if (c != typeof(JSONTile))
                        {
                            Tile tmp = (Tile)Activator.CreateInstance(c, null);
                            if (tmp.getDrawable())
                            {
                                pileOfTiles.Add(tmp);
                                counter++;
                            }
                        }
                    }
                    counter++;
            }

            //gets all the JSON files from the directory and creates tiles for them
            string[] jsonFiles = Directory.GetFiles("..\\..\\..\\..\\JSON Tiles", "*.json")
                                     .Select(path => Path.GetFileName(path))
                                     .ToArray();

            foreach (string file in jsonFiles)
            {
                for (int k = 0; k < 4; k++)
                {
                    pileOfTiles.Add(new JSONTile(file));
                }
            }


           return types;
        }

        /*
         * sets a list of players to the list of the current players
         */ 
        private void setPlayerList(List<Player> plyrs)
        {
            this.players = plyrs;
            WarTentTile tent = new WarTentTile(this.players[0], Board.makeBoardLocation(0,0));
            this.placeTileAtPosition(Board.makeBoardLocation(0, 0), Board.orientation.UP, tent);
            tent = new WarTentTile(this.players[1], Board.makeBoardLocation(7, 7));
            this.placeTileAtPosition(Board.makeBoardLocation(7, 7), Board.orientation.UP, tent);
        }

        /*
         * add the players and make the tents for them
         */ 
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

        //Makes all the dragons and sets where they should be at the start
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

        //Checks to see if a tile can be placed at the location
        public bool canPlace(Board.location loc){
            if (this.tileBoard.getTileAt(loc.x, loc.y) == null)
            {
                foreach (Dragon d in this.dragons)
                {
                    if (loc.x == d.currentPosition.x && loc.y == d.currentPosition.y)
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

        //Places a tile at the given position
        public void placeTileAtPosition(Board.location place, Board.orientation orient, Tile tile)
        {
            if (playerWon < 0)
            {
                tile.place(place, orient);
                this.tileBoard.addPiece(tile);
                tile.placeEffects(this.tileBoard);
            }

        }

        public bool destroyTileAt(Board.location loc)
        {
            if (this.tileBoard.getTileAt(loc.x, loc.y) != null)
            {
                this.tileBoard.destroyTileAt(loc.x, loc.y);
                return true;
            }
            else
            {
                return false;
            }

        }

        /*
         * Moves all the dragons and then removes all the tiles
         * that they report should be destroyed. Then checks to see
         * if a player has lost, if so it attempts to get a response from the players accordingly.
         */ 
        public void moveDragons()
        {
            if (this.playerWon < 0)
            {
                List<Tile> toDelete = new List<Tile>();
                bool p1Win = false;
                bool p2Win = false;
                foreach (Dragon d in this.dragons)
                {
                         if (this.tileBoard.getTileAt(d.getCurrentPosition().x, d.getCurrentPosition().y) != null)
                        {
                            Tile dragonTile = this.tileBoard.getTileAt(d.getCurrentPosition().x, d.getCurrentPosition().y);
                            if (dragonTile.GetType() == typeof(DragonsLairTile))
                            {
                                toDelete.Add(dragonTile);
                            }
                            else
                            {
                                List<Tile> dragonDestroy = new List<Tile>();
                                Board.location dragonLoc = d.getCurrentPosition();
                                List<Board.location> locsToDestroy = new List<Board.location>();
                                locsToDestroy.Add(Board.makeBoardLocation(dragonLoc.x - 1, dragonLoc.y));
                                locsToDestroy.Add(Board.makeBoardLocation(dragonLoc.x + 1, dragonLoc.y));
                                locsToDestroy.Add(Board.makeBoardLocation(dragonLoc.x, dragonLoc.y - 1));
                                locsToDestroy.Add(Board.makeBoardLocation(dragonLoc.x, dragonLoc.y + 1));
                                foreach (Board.location l in locsToDestroy)
                                {
                                    dragonDestroy.Add(this.tileBoard.getTileAt(l.x, l.y));
                                }
                                foreach (Tile t in dragonDestroy)
                                {
                                    if (t != null)
                                    {
                                        this.destroyTileAt(t.location);
                                        if (MainRunner.getScreen() != null)
                                        {
                                            MainRunner.getScreen().clearCell(t.location);
                                        }
                                    }
                                }
                                toDelete.AddRange(d.move(tileBoard));
                            }


                        }
                        else{
                            toDelete.AddRange(d.move(tileBoard));
                        }
                }
                foreach (Tile t in toDelete)
                {
                    if (this.tileBoard.getTileAt(0, 0) == t)
                    {
                        p2Win = true;
                    }
                    if (this.tileBoard.getTileAt(7, 7) == t)
                    {
                        p1Win = true;
                    }
                    destroyTileAt(t.location);
                    if (MainRunner.getScreen() != null)
                    {
                        MainRunner.getScreen().clearCell(t.location);
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

        public int getPlayerWon(){
        return this.playerWon;
        }


        public void endGame(int p)
        {
            this.playerWon = p;
            if (MainRunner.getScreen() != null)
            {
                if (GameScreen.promptForNewGame(this.playerWon))
                {
                    this.makeNewGame();
                }
            }
        }
        //Resets all of the game info for a new game.
        public void makeNewGame()
        {
            this.playerWon = -1;
            this.tileBoard = new Board();
            this.pileOfTiles = new List<Tile>();
            this.dragons = new List<Dragon>();
            this.makePile();
            this.setPlayersAndTents(this.players);
            this.makeDragonsAndSetPositions();
            GameScreen screen = MainRunner.getScreen();
            if (screen != null)
            {
                screen.resetScreen();
            }
        }


        public static bool dragonTilePlace(Tile selected, int p1, int p2, GameInfo game)
        {
            
            Type tile = selected.GetType();
            Board.location loc = Board.makeBoardLocation(p1, p2);
            if (tile == typeof(DragonBreathTile) || tile == typeof(DragonsLairTile))
            {
                foreach (Dragon d in game.getDragons())
                {
                    if (d.getCurrentPosition().Equals(loc))
                    {
                        return true;
                    }

                }

            }


            return false;
        }
    }
}
