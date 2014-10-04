namespace Client
{
    partial class GameWindow
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
            this.QuitButton = new System.Windows.Forms.Button();
            this.GamePanel = new System.Windows.Forms.Panel();
            this.RestartButton = new System.Windows.Forms.Button();
            this.LpPawnPanelBlack = new System.Windows.Forms.FlowLayoutPanel();
            this.BannerPanel = new System.Windows.Forms.Panel();
            this.LpRoyalPanelBlack = new System.Windows.Forms.FlowLayoutPanel();
            this.LpPawnPanelWhite = new System.Windows.Forms.FlowLayoutPanel();
            this.LpRoyalPanelWhite = new System.Windows.Forms.FlowLayoutPanel();
            this.BlackPlayerName = new System.Windows.Forms.Label();
            this.WhitePlayerName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ChatInputBox = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SendButton = new System.Windows.Forms.Button();
            this.ChatWindow = new RichEdit50();
            this.SuspendLayout();
            // 
            // QuitButton
            // 
            this.QuitButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.QuitButton.Font = new System.Drawing.Font("Sylfaen", 9.209303F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuitButton.Location = new System.Drawing.Point(959, 658);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(75, 26);
            this.QuitButton.TabIndex = 0;
            this.QuitButton.Text = "Quit";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // GamePanel
            // 
            this.GamePanel.AutoSize = true;
            this.GamePanel.BackgroundImage = global::Client.Properties.Resources.CBR;
            this.GamePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GamePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GamePanel.Location = new System.Drawing.Point(220, 80);
            this.GamePanel.Name = "GamePanel";
            this.GamePanel.Size = new System.Drawing.Size(600, 599);
            this.GamePanel.TabIndex = 1;
            this.GamePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.GamePanel_Paint);
            // 
            // RestartButton
            // 
            this.RestartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RestartButton.Font = new System.Drawing.Font("Sylfaen", 9.209303F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RestartButton.Location = new System.Drawing.Point(878, 658);
            this.RestartButton.Name = "RestartButton";
            this.RestartButton.Size = new System.Drawing.Size(75, 26);
            this.RestartButton.TabIndex = 2;
            this.RestartButton.Text = "Restart";
            this.RestartButton.UseVisualStyleBackColor = true;
            this.RestartButton.Click += new System.EventHandler(this.RestartButton_Click);
            // 
            // LpPawnPanelBlack
            // 
            this.LpPawnPanelBlack.BackColor = System.Drawing.Color.Transparent;
            this.LpPawnPanelBlack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LpPawnPanelBlack.Location = new System.Drawing.Point(826, 107);
            this.LpPawnPanelBlack.Name = "LpPawnPanelBlack";
            this.LpPawnPanelBlack.Size = new System.Drawing.Size(221, 51);
            this.LpPawnPanelBlack.TabIndex = 3;
            this.LpPawnPanelBlack.Paint += new System.Windows.Forms.PaintEventHandler(this.LpPawnPanelBlack_Paint);
            // 
            // BannerPanel
            // 
            this.BannerPanel.AutoSize = true;
            this.BannerPanel.BackColor = System.Drawing.Color.Transparent;
            this.BannerPanel.BackgroundImage = global::Client.Properties.Resources.Head;
            this.BannerPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BannerPanel.Location = new System.Drawing.Point(266, -7);
            this.BannerPanel.Margin = new System.Windows.Forms.Padding(1);
            this.BannerPanel.Name = "BannerPanel";
            this.BannerPanel.Size = new System.Drawing.Size(515, 114);
            this.BannerPanel.TabIndex = 5;
            this.BannerPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.BannerPanel_Paint);
            // 
            // LpRoyalPanelBlack
            // 
            this.LpRoyalPanelBlack.BackColor = System.Drawing.Color.Transparent;
            this.LpRoyalPanelBlack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LpRoyalPanelBlack.Location = new System.Drawing.Point(826, 164);
            this.LpRoyalPanelBlack.Name = "LpRoyalPanelBlack";
            this.LpRoyalPanelBlack.Size = new System.Drawing.Size(221, 51);
            this.LpRoyalPanelBlack.TabIndex = 4;
            this.LpRoyalPanelBlack.Paint += new System.Windows.Forms.PaintEventHandler(this.LpRoyalPanelBlack_Paint);
            // 
            // LpPawnPanelWhite
            // 
            this.LpPawnPanelWhite.BackColor = System.Drawing.Color.Transparent;
            this.LpPawnPanelWhite.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LpPawnPanelWhite.Location = new System.Drawing.Point(826, 524);
            this.LpPawnPanelWhite.Name = "LpPawnPanelWhite";
            this.LpPawnPanelWhite.Size = new System.Drawing.Size(221, 51);
            this.LpPawnPanelWhite.TabIndex = 5;
            this.LpPawnPanelWhite.Paint += new System.Windows.Forms.PaintEventHandler(this.LpPawnPanelWhite_Paint);
            // 
            // LpRoyalPanelWhite
            // 
            this.LpRoyalPanelWhite.BackColor = System.Drawing.Color.Transparent;
            this.LpRoyalPanelWhite.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LpRoyalPanelWhite.Location = new System.Drawing.Point(826, 581);
            this.LpRoyalPanelWhite.Name = "LpRoyalPanelWhite";
            this.LpRoyalPanelWhite.Size = new System.Drawing.Size(221, 51);
            this.LpRoyalPanelWhite.TabIndex = 6;
            this.LpRoyalPanelWhite.Paint += new System.Windows.Forms.PaintEventHandler(this.LpRoyalPanelWhite_Paint);
            // 
            // BlackPlayerName
            // 
            this.BlackPlayerName.AutoSize = true;
            this.BlackPlayerName.Location = new System.Drawing.Point(826, 80);
            this.BlackPlayerName.Name = "BlackPlayerName";
            this.BlackPlayerName.Size = new System.Drawing.Size(0, 13);
            this.BlackPlayerName.TabIndex = 8;
            // 
            // WhitePlayerName
            // 
            this.WhitePlayerName.AutoSize = true;
            this.WhitePlayerName.Location = new System.Drawing.Point(826, 498);
            this.WhitePlayerName.Name = "WhitePlayerName";
            this.WhitePlayerName.Size = new System.Drawing.Size(0, 13);
            this.WhitePlayerName.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Sylfaen", 10.04651F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(27, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 18);
            this.label3.TabIndex = 10;
            this.label3.Text = "Chat Log";
            // 
            // ChatInputBox
            // 
            this.ChatInputBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ChatInputBox.Font = new System.Drawing.Font("Sylfaen", 9.209303F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChatInputBox.Location = new System.Drawing.Point(27, 656);
            this.ChatInputBox.Name = "ChatInputBox";
            this.ChatInputBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.ChatInputBox.Size = new System.Drawing.Size(174, 23);
            this.ChatInputBox.TabIndex = 11;
            this.ChatInputBox.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Sylfaen", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(24, 635);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(181, 14);
            this.label4.TabIndex = 12;
            this.label4.Text = "Write and push \"enter\" to send";
            // 
            // SendButton
            // 
            this.SendButton.Font = new System.Drawing.Font("Sylfaen", 9.209303F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendButton.Location = new System.Drawing.Point(27, 685);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(0, 0);
            this.SendButton.TabIndex = 13;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // ChatWindow
            // 
            this.ChatWindow.BackColor = System.Drawing.SystemColors.WindowText;
            this.ChatWindow.CausesValidation = false;
            this.ChatWindow.DetectUrls = false;
            this.ChatWindow.Font = new System.Drawing.Font("Sylfaen", 9.209303F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChatWindow.ForeColor = System.Drawing.Color.White;
            this.ChatWindow.Location = new System.Drawing.Point(27, 107);
            this.ChatWindow.Name = "ChatWindow";
            this.ChatWindow.ReadOnly = true;
            this.ChatWindow.Size = new System.Drawing.Size(174, 525);
            this.ChatWindow.TabIndex = 14;
            this.ChatWindow.Text = "";
            this.ChatWindow.TextChanged += new System.EventHandler(this.ChatWindow_TextChanged_1);
            // 
            // GameWindow
            // 
            this.AcceptButton = this.SendButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Client.Properties.Resources.BG;
            this.ClientSize = new System.Drawing.Size(1072, 696);
            this.Controls.Add(this.ChatWindow);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ChatInputBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.WhitePlayerName);
            this.Controls.Add(this.BlackPlayerName);
            this.Controls.Add(this.LpRoyalPanelWhite);
            this.Controls.Add(this.LpPawnPanelWhite);
            this.Controls.Add(this.LpRoyalPanelBlack);
            this.Controls.Add(this.LpPawnPanelBlack);
            this.Controls.Add(this.RestartButton);
            this.Controls.Add(this.GamePanel);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.BannerPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "GameWindow";
            this.Text = "Chess: Playing Game";
            this.Load += new System.EventHandler(this.GameWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.Panel GamePanel;
        private System.Windows.Forms.Button RestartButton;
        private System.Windows.Forms.FlowLayoutPanel LpPawnPanelBlack;
        private System.Windows.Forms.Panel BannerPanel;
        private System.Windows.Forms.FlowLayoutPanel LpRoyalPanelBlack;
        private System.Windows.Forms.FlowLayoutPanel LpPawnPanelWhite;
        private System.Windows.Forms.FlowLayoutPanel LpRoyalPanelWhite;
        private System.Windows.Forms.Label BlackPlayerName;
        private System.Windows.Forms.Label WhitePlayerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox ChatInputBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button SendButton;
        private RichEdit50 ChatWindow;

    }
}