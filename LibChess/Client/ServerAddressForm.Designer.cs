namespace Client
{
    partial class ServerAddressForm
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
            this.ServerAddressOK = new System.Windows.Forms.Button();
            this.ServerAddressBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ServerAddressOK
            // 
            this.ServerAddressOK.Location = new System.Drawing.Point(205, 38);
            this.ServerAddressOK.Name = "ServerAddressOK";
            this.ServerAddressOK.Size = new System.Drawing.Size(75, 23);
            this.ServerAddressOK.TabIndex = 0;
            this.ServerAddressOK.Text = "OK";
            this.ServerAddressOK.UseVisualStyleBackColor = true;
            this.ServerAddressOK.Click += new System.EventHandler(this.ServerAddressOk_Click);
            // 
            // ServerAddressBox
            // 
            this.ServerAddressBox.Location = new System.Drawing.Point(12, 12);
            this.ServerAddressBox.Name = "ServerAddressBox";
            this.ServerAddressBox.Size = new System.Drawing.Size(268, 20);
            this.ServerAddressBox.TabIndex = 1;
            this.ServerAddressBox.Text = "127.0.0.1";
            // 
            // ServerAddressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 73);
            this.ControlBox = false;
            this.Controls.Add(this.ServerAddressBox);
            this.Controls.Add(this.ServerAddressOK);
            this.Name = "ServerAddressForm";
            this.Text = "Enter server address";
            this.Load += new System.EventHandler(this.ServerAddressForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ServerAddressOK;
        private System.Windows.Forms.TextBox ServerAddressBox;

        public string Address
        {
            get { return ServerAddressBox.Text; }
        }
    }
}