namespace Dargons_of_Kir
{
    partial class GameScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GameGrid = new System.Windows.Forms.TableLayoutPanel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.PlayerHand = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // GameGrid
            // 
            this.GameGrid.AllowDrop = true;
            this.GameGrid.BackColor = System.Drawing.SystemColors.Control;
            this.GameGrid.ColumnCount = 8;
            this.GameGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.GameGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.GameGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.GameGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.GameGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.GameGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.GameGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.GameGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.GameGrid.Location = new System.Drawing.Point(12, 12);
            this.GameGrid.MaximumSize = new System.Drawing.Size(800, 800);
            this.GameGrid.MinimumSize = new System.Drawing.Size(800, 800);
            this.GameGrid.Name = "GameGrid";
            this.GameGrid.RowCount = 8;
            this.GameGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.GameGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.GameGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.GameGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.GameGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.GameGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.GameGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.GameGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.GameGrid.Size = new System.Drawing.Size(800, 800);
            this.GameGrid.TabIndex = 0;
            this.GameGrid.DragDrop += new System.Windows.Forms.DragEventHandler(this.pictureBox1_DragOver);
            this.GameGrid.DragEnter += new System.Windows.Forms.DragEventHandler(this.pictureBox1_DragOver);
            this.GameGrid.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            this.GameGrid.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tableLayoutPanel1_MouseDoubleClick);
            // 
            // PlayerHand
            // 
            this.PlayerHand.AllowDrop = true;
            this.PlayerHand.BackColor = System.Drawing.SystemColors.ControlDark;
            this.PlayerHand.ColumnCount = 1;
            this.PlayerHand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PlayerHand.ForeColor = System.Drawing.Color.OrangeRed;
            this.PlayerHand.Location = new System.Drawing.Point(818, 12);
            this.PlayerHand.MaximumSize = new System.Drawing.Size(200, 800);
            this.PlayerHand.MinimumSize = new System.Drawing.Size(200, 800);
            this.PlayerHand.Name = "PlayerHand";
            this.PlayerHand.RowCount = 8;
            this.PlayerHand.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.PlayerHand.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.PlayerHand.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.PlayerHand.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.PlayerHand.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.PlayerHand.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.PlayerHand.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.PlayerHand.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.PlayerHand.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.PlayerHand.Size = new System.Drawing.Size(200, 800);
            this.PlayerHand.TabIndex = 0;
            this.PlayerHand.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // GameScreen
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 827);
            this.Controls.Add(this.PlayerHand);
            this.Controls.Add(this.GameGrid);
            this.Name = "GameScreen";
            this.Text = "Dargons of Kir";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.pictureBox1_DragOver);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel GameGrid;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TableLayoutPanel PlayerHand;

    }
}

