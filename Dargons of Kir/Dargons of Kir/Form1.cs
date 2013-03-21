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
    public partial class Form1 : Form
    {

        Image pic = null;
        
        public Form1()
        {
            InitializeComponent();
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
            pic = ((PictureBox)sender).Image;
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
           ((PictureBox) sender).Image = pic;
        }

        private void setPicture(object sender, MouseEventArgs e)
        {
            ((PictureBox)sender).Image = pic;
        }

        private void rotatePicture(object sender, MouseEventArgs e)
        {
            Image temp = ((PictureBox)sender).Image;
            temp.RotateFlip(RotateFlipType.Rotate90FlipNone);
            ((PictureBox)sender).Image = temp;
        }

    }

  
}
