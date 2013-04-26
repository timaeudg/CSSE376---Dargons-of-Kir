﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dargons_of_Kir
{
    public partial class GameScreen : Form
    {
        private int turn = 0;
        private PictureBox[,] boardPictures = new PictureBox[8,8];
        private PictureBox[] handPictures = new PictureBox[4];
        private GameInfo game;
        private Tile selected;
        private int selectedIndex;
        private Player currentPlayer;
        private bool placed = false;
        private Image checkMark = Image.FromFile("..\\..\\..\\..\\images\\checkMark.png");

        public GameScreen(GameInfo newGame):this()
        {
            this.game = newGame;
            currentPlayer = game.getNextPlayer();
            for (int i = 0; i < 4; i++) handPictures[i].Image = currentPlayer.hand[i].picture;
            List<Dragon> allDragons = game.dragons;
            foreach (Dragon dragon in allDragons)
            {
                boardPictures[dragon.position.x, dragon.position.y].Image = dragon.image;
            }

            Board board = game.board;
            boardPictures[0, 0].Image = board[0, 0].tile.picture;
            boardPictures[7, 7].Image = board[7, 7].tile.picture;

        }

        public GameScreen()
        {
            InitializeComponent();
            for (int i = 0; i < boardPictures.GetLength(0); i++)
            {
                for (int j = 0; j < boardPictures.GetLength(1); j++)
                {
                    boardPictures[i, j] = new PictureBox();
                    ((System.ComponentModel.ISupportInitialize)(boardPictures[i,j])).BeginInit();
                    boardPictures[i, j].Dock = System.Windows.Forms.DockStyle.Fill;
                    boardPictures[i, j].Image = Image.FromFile("..\\..\\..\\..\\images\\back.JPG");
                    boardPictures[i, j].Location = new System.Drawing.Point(3*(i+1) + 100 * i, 3*(j+1) + 100 * j);
                    boardPictures[i, j].Name = "cell" + i.ToString() + j.ToString();
                    boardPictures[i, j].Size = new System.Drawing.Size(100, 100);
                    boardPictures[i, j].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    boardPictures[i, j].TabIndex = 0;
                    boardPictures[i, j].TabStop = false;
                    boardPictures[i, j].MouseClick += new MouseEventHandler(setPicture);
                    boardPictures[i, j].MouseDown += new MouseEventHandler(rotatePicture);
                    this.GameGrid.Controls.Add(boardPictures[i,j], i, j);
                    ((System.ComponentModel.ISupportInitialize)(boardPictures[i, j])).EndInit();
                }
            }

            for (int i = 0; i < handPictures.Length; i++)
            {
                handPictures[i] = new PictureBox();
                ((System.ComponentModel.ISupportInitialize)(handPictures[i])).BeginInit();
                handPictures[i].Dock = System.Windows.Forms.DockStyle.Fill;
                handPictures[i].Image = Image.FromFile("..\\..\\..\\..\\images\\monk.JPG");
                handPictures[i].Location = new System.Drawing.Point(1, 1 * (i + 1) + 200 * i);
                handPictures[i].Name = "cell" + i.ToString();
                handPictures[i].Size = new System.Drawing.Size(200, 200);
                handPictures[i].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                handPictures[i].TabIndex = 0;
                handPictures[i].TabStop = false;
                handPictures[i].MouseClick += new MouseEventHandler(hand_tile_click);
                this.PlayerHand.Controls.Add(handPictures[i]);
                ((System.ComponentModel.ISupportInitialize)(handPictures[i])).EndInit();
            }
            
        }

        private void hand_tile_click(object sender, EventArgs e)
        {
            if (((PictureBox)sender).Image == checkMark && !placed) 
            {
                ((PictureBox)sender).Image = selected.picture;
                selected = null;
                return;
            }
            if (((PictureBox)sender).Image == checkMark && placed)
            {
                //if(game.canPlace(selected.location))
                if(placed)
                {
                    game.placeTileAtPosition(selected.location, selected.orientation, selected);
                    placed = false;
                    selected = null;
                    ((PictureBox)sender).Image = null;
                    currentPlayer.hand[selectedIndex] = null;
                    selectedIndex = 0;
                    currentPlayer = game.getNextPlayer();
                    for (int i = 0; i < 4; i++) handPictures[i].Image = currentPlayer.hand[i].picture;
                    turn = (turn + 1) % 3;
                    if (turn == 2)
                    {
                        this.dragonTurn();
                    }
                    return;
                }
            }
            if (selected != null) return;

            for (int i = 0; i < 4; i++)
            {
                if (((PictureBox)sender).Image == handPictures[i].Image)
                {
                    selected = currentPlayer.hand[i];
                    selectedIndex = i;
                }
            }
            ((PictureBox)sender).Image = checkMark;
            placed = false;
        }

        private void dragonTurn()
        {
            List<Dragon> allDragons = game.dragons;
            
            foreach (Dragon dragon in allDragons)
            {

                boardPictures[dragon.position.x, dragon.position.y].Image = Image.FromFile("..\\..\\..\\..\\images\\back.JPG");
            }

            game.moveDragons();
            allDragons = game.dragons;

            foreach (Dragon dragon in allDragons)
            {
                boardPictures[dragon.position.x, dragon.position.y].Image = dragon.image;

            }

            this.turn = (this.turn + 1) % 3;
        }

        private void setPicture(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Left) return;

            if (!placed)
            {
                if (selected == null) return;
                Board.location loc = new Board.location(GameGrid.GetColumn((PictureBox)sender),GameGrid.GetRow((PictureBox)sender));
                Tile toPlay = selected;
                if (game.canPlace(loc) || GameInfo.dragonTilePlace(selected, GameGrid.GetColumn((PictureBox)sender), GameGrid.GetRow((PictureBox)sender), this.game))
                {
                    ((PictureBox)sender).Image = selected.picture;
                    selected.location = new Board.location(GameGrid.GetColumn((PictureBox)sender),GameGrid.GetRow((PictureBox)sender));
                    placed = !placed;
                }
               
            }
            else
            {
                if (GameGrid.GetColumn((PictureBox)sender) == selected.location.x &&
                GameGrid.GetRow((PictureBox)sender) == selected.location.y)
                {
                    ((PictureBox)sender).Image = Image.FromFile("..\\..\\..\\..\\images\\back.jpg");
                    placed = !placed;
                }
            }
        }

        private void rotatePicture(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Right) return;
            if (selected != null)
            {
                if (GameGrid.GetColumn((PictureBox)sender) == selected.location.x &&
                    GameGrid.GetRow((PictureBox)sender) == selected.location.y)
                {
                    Image temp = ((PictureBox)sender).Image;
                    temp.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    selected.orientation = ((selected.orientation + 1) > Board.direction.DOWN) ? (selected.orientation - 3) : (selected.orientation + 1);
                    ((PictureBox)sender).Image = temp;
                }
            }
        }

        private void load_hand(Tile[] tiles)
        {
            for (int i = 0; i < 4; i++)
            {
                handPictures[i].Image = tiles[i].picture;
            }
        }

        public static bool promptForNewGame(int playerWon)
        {
            DialogResult result;

            if (playerWon == 1)
            {
                result = MessageBox.Show("Player 1 has won! Would you like to start a new game?",
            "Game Over, Player 1 Wins",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Exclamation,
            MessageBoxDefaultButton.Button1);
            }
            else if (playerWon == 2)
            {
                result = MessageBox.Show("Player 2 has won! Would you like to start a new game?",
            "Game Over, Player 2 Wins",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Exclamation,
            MessageBoxDefaultButton.Button1);

            }
            else
            {
                result = MessageBox.Show("There was a tie?! Would you like to start a new game?",
            "Game Over, DRAW!!!",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Exclamation,
            MessageBoxDefaultButton.Button1);
            }

            if (result == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void resetScreen()
        {

            for (int i = 0; i < boardPictures.GetLength(0); i++)
            {
                for (int j = 0; j < boardPictures.GetLength(1); j++)
                {
                    if (game.board[i, j].tile == null)
                    {
                        boardPictures[i, j].Image = Image.FromFile("..\\..\\..\\..\\images\\back.JPG");
                    }
                    else{
                        boardPictures[i, j].Image = game.board[i, j].tile.picture;
                    }
                }
            }

            for (int i = 0; i < 4; i++) handPictures[i].Image = currentPlayer.hand[i].picture;

        }

        public void clearCell(Board.location loc)
        {
            boardPictures[loc.x, loc.y].Image = Image.FromFile("..\\..\\..\\..\\images\\back.JPG");
        }

    }

  
}
