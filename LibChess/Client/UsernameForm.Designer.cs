namespace Client
{
    partial class UsernameForm
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
            this.UsernameBox = new System.Windows.Forms.TextBox();
            this.UsernameOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UsernameBox
            // 
            this.UsernameBox.Location = new System.Drawing.Point(12, 19);
            this.UsernameBox.Name = "UsernameBox";
            this.UsernameBox.Size = new System.Drawing.Size(232, 20);
            this.UsernameBox.TabIndex = 0;
            // 
            // UsernameOK
            // 
            this.UsernameOK.Location = new System.Drawing.Point(169, 45);
            this.UsernameOK.Name = "UsernameOK";
            this.UsernameOK.Size = new System.Drawing.Size(75, 23);
            this.UsernameOK.TabIndex = 1;
            this.UsernameOK.Text = "OK";
            this.UsernameOK.UseVisualStyleBackColor = true;
            this.UsernameOK.Click += new System.EventHandler(this.usernameOk_Click);
            // 
            // UsernameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 80);
            this.ControlBox = false;
            this.Controls.Add(this.UsernameOK);
            this.Controls.Add(this.UsernameBox);
            this.Name = "UsernameForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Enter Username";
            this.Load += new System.EventHandler(this.UsernameForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UsernameBox;
        private System.Windows.Forms.Button UsernameOK;

        public string Username
        {
            get { return UsernameBox.Text; }
        }
    }
}