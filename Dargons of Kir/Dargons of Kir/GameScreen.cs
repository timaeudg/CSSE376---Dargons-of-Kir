using System;
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

        private Image selected;
        private PictureBox[,] boardPictures = new PictureBox[8,8];
        private PictureBox[] handPictures = new PictureBox[4];
        private GameInfo game;

        public GameScreen(GameInfo newGame):this()
        {
            this.game = newGame;

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
                    this.GameGrid.Controls.Add(boardPictures[i,j], i, j);
                    ((System.ComponentModel.ISupportInitialize)(boardPictures[i, j])).EndInit();

                }
            }

            for (int i = 0; i < handPictures.Length; i++)
            {
                handPictures[i] = new PictureBox();
                ((System.ComponentModel.ISupportInitialize)(handPictures[i])).BeginInit();
                handPictures[i].Dock = System.Windows.Forms.DockStyle.Fill;
                handPictures[i].Image = Image.FromFile("..\\..\\..\\..\\images\\back.JPG");
                handPictures[i].Location = new System.Drawing.Point(1, 1 * (i + 1) + 200 * i);
                handPictures[i].Name = "cell" + i.ToString();
                handPictures[i].Size = new System.Drawing.Size(200, 200);
                handPictures[i].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                handPictures[i].TabIndex = 0;
                handPictures[i].TabStop = false;
                this.PlayerHand.Controls.Add(handPictures[i]);
                ((System.ComponentModel.ISupportInitialize)(handPictures[i])).EndInit();
            }

        }

        private void hand_tile_click(object sender, EventArgs e)
        {
            selected = ((PictureBox)sender).Image;
        }

        private void cell_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           ((PictureBox) sender).Image = selected;
        }

        private void setPicture(object sender, MouseEventArgs e)
        {
            ((PictureBox)sender).Image = selected;
        }

        private void rotatePicture(object sender, MouseEventArgs e)
        {
            Image temp = ((PictureBox)sender).Image;
            temp.RotateFlip(RotateFlipType.Rotate90FlipNone);
            ((PictureBox)sender).Image = temp;
        }

    }

  
}
