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
                    boardPictures[i, j].Image = Image.FromFile("..\\..\\..\\..\\images\\monk.JPG");
                    boardPictures[i, j].Location = new System.Drawing.Point(3 + 200 * i, 3 + 200 * j);
                    boardPictures[i, j].Name = "cell" + i.ToString() + j.ToString();
                    boardPictures[i, j].Size = new System.Drawing.Size(200, 200);
                    boardPictures[i, j].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    boardPictures[i, j].TabIndex = 0;
                    boardPictures[i, j].TabStop = false;
                    this.GameGrid.Controls.Add(boardPictures[i,j], i, j);
                    ((System.ComponentModel.ISupportInitialize)(boardPictures[i, j])).EndInit();

                }
            }

        }



        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void pictureBox1_DragLeave(object sender, EventArgs e)
        {
            Console.Write("Herp teh Derp\n");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            selected = ((PictureBox)sender).Image;
        }

        private void pictureBox1_DragOver(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.FileDrop)) {
                 e.Effect = DragDropEffects.Copy;
        }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void pictureBox5_DragDrop(object sender, DragEventArgs e)
        {
            Panel dest = (Panel)sender;
            Console.Write("Dropped");
            dest.BackColor =((Panel) e.Data.GetData(typeof(Panel))).BackColor;
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            Console.Write("STring");

        }

        private void tableLayoutPanel1_MouseDoubleClick(object sender, MouseEventArgs e)
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

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

    }

  
}
