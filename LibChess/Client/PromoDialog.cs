using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    class PromoDialog : Form
    {
        private RadioButton KnightButton;
        private RadioButton BishopButton;
        private RadioButton RookButton;
        private RadioButton QueenButton;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Button OkButton;
        private Label label1;
        private PictureBox pictureBox4;

        public PromoDialog()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.KnightButton = new System.Windows.Forms.RadioButton();
            this.BishopButton = new System.Windows.Forms.RadioButton();
            this.RookButton = new System.Windows.Forms.RadioButton();
            this.QueenButton = new System.Windows.Forms.RadioButton();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // KnightButton
            // 
            this.KnightButton.AutoSize = true;
            this.KnightButton.BackColor = System.Drawing.Color.Transparent;
            this.KnightButton.ForeColor = System.Drawing.Color.Transparent;
            this.KnightButton.Location = new System.Drawing.Point(10, 102);
            this.KnightButton.Name = "KnightButton";
            this.KnightButton.Size = new System.Drawing.Size(55, 17);
            this.KnightButton.TabIndex = 0;
            this.KnightButton.Text = "Knight";
            this.KnightButton.UseVisualStyleBackColor = false;
            // 
            // BishopButton
            // 
            this.BishopButton.AutoSize = true;
            this.BishopButton.BackColor = System.Drawing.Color.Transparent;
            this.BishopButton.ForeColor = System.Drawing.Color.Transparent;
            this.BishopButton.Location = new System.Drawing.Point(99, 102);
            this.BishopButton.Name = "BishopButton";
            this.BishopButton.Size = new System.Drawing.Size(57, 17);
            this.BishopButton.TabIndex = 1;
            this.BishopButton.Text = "Bishop";
            this.BishopButton.UseVisualStyleBackColor = false;
            // 
            // RookButton
            // 
            this.RookButton.AutoSize = true;
            this.RookButton.BackColor = System.Drawing.Color.Transparent;
            this.RookButton.ForeColor = System.Drawing.Color.Transparent;
            this.RookButton.Location = new System.Drawing.Point(192, 102);
            this.RookButton.Name = "RookButton";
            this.RookButton.Size = new System.Drawing.Size(51, 17);
            this.RookButton.TabIndex = 2;
            this.RookButton.Text = "Rook";
            this.RookButton.UseVisualStyleBackColor = false;
            // 
            // QueenButton
            // 
            this.QueenButton.AutoSize = true;
            this.QueenButton.BackColor = System.Drawing.Color.Transparent;
            this.QueenButton.Checked = true;
            this.QueenButton.ForeColor = System.Drawing.Color.Transparent;
            this.QueenButton.Location = new System.Drawing.Point(285, 102);
            this.QueenButton.Name = "QueenButton";
            this.QueenButton.Size = new System.Drawing.Size(57, 17);
            this.QueenButton.TabIndex = 3;
            this.QueenButton.TabStop = true;
            this.QueenButton.Text = "Queen";
            this.QueenButton.UseVisualStyleBackColor = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = global::Client.Properties.Resources.BQ;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox4.Location = new System.Drawing.Point(285, 46);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(55, 50);
            this.pictureBox4.TabIndex = 7;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::Client.Properties.Resources.BR;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox3.Location = new System.Drawing.Point(188, 46);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(55, 50);
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::Client.Properties.Resources.BB;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Location = new System.Drawing.Point(101, 46);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(55, 50);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Client.Properties.Resources.BH;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(10, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(55, 50);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(101, 125);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(142, 23);
            this.OkButton.TabIndex = 8;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(7, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Choose a new piece!";
            // 
            // PromoDialog
            // 
            this.BackgroundImage = global::Client.Properties.Resources.BG;
            this.ClientSize = new System.Drawing.Size(352, 158);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.QueenButton);
            this.Controls.Add(this.RookButton);
            this.Controls.Add(this.BishopButton);
            this.Controls.Add(this.KnightButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PromoDialog";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (this.BishopButton.Checked == true || this.KnightButton.Checked == true || this.QueenButton.Checked == true || this.RookButton.Checked == true)
            {
                this.Hide();
            }
        }

        public RadioButton Knightbutton
        {
            get { return KnightButton; }
        }
        public RadioButton Bishopbutton
        {
            get { return BishopButton; }
        }
        public RadioButton Rookbutton
        {
            get { return RookButton; }
        }
        public RadioButton Queenbutton
        {
            get { return QueenButton; }
        }
    }
}
