using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LibChess;

namespace Client
{
    public class Client : Form
    {

        private Player player = new Player();
        private GameWindow gameWindow;
        private ListBox playerList;
        private Button sendRequestButton;
        private Label opponentsLabel;
        private Panel opponentsPanel;
        private Panel replaysPanel;
        private Label replaysLabel;
        private ListBox replaysList;
        private Button startReplaysButton;
        private Button signOutButton;
        private Panel signInPanel;
        private Label signInLabel;
        private Button sendPasswordButton;
        private TextBox emailTextbox;
        private TextBox emailRegisterTextBox;
        private TextBox passwordTextbox;
        private Label emailLabel;
        private Label passwordLabel;
        private Label registerLabel;
        private Label loginEmailLabel;
        private Button signInButton;
        private PictureBox pictureBox1;
        private Label label1;
        private Label welcomeLabel;
        private Connection connection;

        private Client()
        {
            InitializeComponent();
            this.SetStyle(
              ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.DoubleBuffer, true);
            connection = new Connection(this);

        }

        public Player Player
        {
            get { return player; }
        }

        public ListBox PlayerList
        {
            get { return playerList; }
        }

        public TextBox EmailTextbox
        {
            get { return emailTextbox; }
        }

        public Connection Connection
        {
            get { return connection; }
        }

        public GameWindow GameWindow
        {
            get { return gameWindow; }
            set { gameWindow = value; }
        }

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Client());
        }

        private void InitializeComponent()
        {
            this.playerList = new System.Windows.Forms.ListBox();
            this.sendRequestButton = new System.Windows.Forms.Button();
            this.opponentsLabel = new System.Windows.Forms.Label();
            this.replaysPanel = new System.Windows.Forms.Panel();
            this.startReplaysButton = new System.Windows.Forms.Button();
            this.replaysLabel = new System.Windows.Forms.Label();
            this.replaysList = new System.Windows.Forms.ListBox();
            this.signInPanel = new System.Windows.Forms.Panel();
            this.signInLabel = new System.Windows.Forms.Label();
            this.sendPasswordButton = new System.Windows.Forms.Button();
            this.emailTextbox = new System.Windows.Forms.TextBox();
            this.emailRegisterTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextbox = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.registerLabel = new System.Windows.Forms.Label();
            this.loginEmailLabel = new System.Windows.Forms.Label();
            this.signInButton = new System.Windows.Forms.Button();
            this.opponentsPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.signOutButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.replaysPanel.SuspendLayout();
            this.signInPanel.SuspendLayout();
            this.opponentsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // playerList
            // 
            this.playerList.BackColor = System.Drawing.SystemColors.Control;
            this.playerList.FormattingEnabled = true;
            this.playerList.Location = new System.Drawing.Point(28, 48);
            this.playerList.Name = "playerList";
            this.playerList.Size = new System.Drawing.Size(191, 212);
            this.playerList.TabIndex = 0;
            // 
            // sendRequestButton
            // 
            this.sendRequestButton.BackColor = System.Drawing.SystemColors.Control;
            this.sendRequestButton.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendRequestButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.sendRequestButton.Location = new System.Drawing.Point(137, 278);
            this.sendRequestButton.Name = "sendRequestButton";
            this.sendRequestButton.Size = new System.Drawing.Size(82, 23);
            this.sendRequestButton.TabIndex = 1;
            this.sendRequestButton.Text = "Invite";
            this.sendRequestButton.UseVisualStyleBackColor = false;
            this.sendRequestButton.Click += new System.EventHandler(this.sendRequestButton_Click);
            // 
            // opponentsLabel
            // 
            this.opponentsLabel.AutoSize = true;
            this.opponentsLabel.BackColor = System.Drawing.Color.Transparent;
            this.opponentsLabel.CausesValidation = false;
            this.opponentsLabel.Font = new System.Drawing.Font("Sylfaen", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opponentsLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.opponentsLabel.Location = new System.Drawing.Point(25, 29);
            this.opponentsLabel.Name = "opponentsLabel";
            this.opponentsLabel.Size = new System.Drawing.Size(179, 18);
            this.opponentsLabel.TabIndex = 2;
            this.opponentsLabel.Text = "AVAILABLE OPPONENTS";
            this.opponentsLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // replaysPanel
            // 
            this.replaysPanel.BackColor = System.Drawing.Color.Transparent;
            this.replaysPanel.Controls.Add(this.startReplaysButton);
            this.replaysPanel.Controls.Add(this.replaysLabel);
            this.replaysPanel.Controls.Add(this.replaysList);
            this.replaysPanel.Location = new System.Drawing.Point(506, 116);
            this.replaysPanel.Name = "replaysPanel";
            this.replaysPanel.Size = new System.Drawing.Size(222, 300);
            this.replaysPanel.TabIndex = 16;
            this.replaysPanel.Visible = false;
            // 
            // startReplaysButton
            // 
            this.startReplaysButton.BackColor = System.Drawing.SystemColors.Control;
            this.startReplaysButton.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startReplaysButton.Location = new System.Drawing.Point(118, 265);
            this.startReplaysButton.Name = "startReplaysButton";
            this.startReplaysButton.Size = new System.Drawing.Size(82, 23);
            this.startReplaysButton.TabIndex = 3;
            this.startReplaysButton.Text = "Start Replay";
            this.startReplaysButton.UseVisualStyleBackColor = false;
            // 
            // replaysLabel
            // 
            this.replaysLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.replaysLabel.AutoSize = true;
            this.replaysLabel.BackColor = System.Drawing.Color.Transparent;
            this.replaysLabel.CausesValidation = false;
            this.replaysLabel.Font = new System.Drawing.Font("Sylfaen", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.replaysLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.replaysLabel.Location = new System.Drawing.Point(79, 29);
            this.replaysLabel.Name = "replaysLabel";
            this.replaysLabel.Size = new System.Drawing.Size(70, 18);
            this.replaysLabel.TabIndex = 6;
            this.replaysLabel.Text = "REPLAYS";
            this.replaysLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // replaysList
            // 
            this.replaysList.FormattingEnabled = true;
            this.replaysList.Location = new System.Drawing.Point(23, 61);
            this.replaysList.Name = "replaysList";
            this.replaysList.Size = new System.Drawing.Size(177, 199);
            this.replaysList.TabIndex = 1;
            // 
            // signInPanel
            // 
            this.signInPanel.BackColor = System.Drawing.Color.Transparent;
            this.signInPanel.Controls.Add(this.signInLabel);
            this.signInPanel.Controls.Add(this.sendPasswordButton);
            this.signInPanel.Controls.Add(this.emailTextbox);
            this.signInPanel.Controls.Add(this.emailRegisterTextBox);
            this.signInPanel.Controls.Add(this.passwordTextbox);
            this.signInPanel.Controls.Add(this.emailLabel);
            this.signInPanel.Controls.Add(this.passwordLabel);
            this.signInPanel.Controls.Add(this.registerLabel);
            this.signInPanel.Controls.Add(this.loginEmailLabel);
            this.signInPanel.Controls.Add(this.signInButton);
            this.signInPanel.Location = new System.Drawing.Point(504, 116);
            this.signInPanel.Name = "signInPanel";
            this.signInPanel.Size = new System.Drawing.Size(221, 301);
            this.signInPanel.TabIndex = 15;
            // 
            // signInLabel
            // 
            this.signInLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.signInLabel.AutoSize = true;
            this.signInLabel.BackColor = System.Drawing.Color.Transparent;
            this.signInLabel.CausesValidation = false;
            this.signInLabel.Font = new System.Drawing.Font("Sylfaen", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signInLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.signInLabel.Location = new System.Drawing.Point(81, 29);
            this.signInLabel.Name = "signInLabel";
            this.signInLabel.Size = new System.Drawing.Size(63, 18);
            this.signInLabel.TabIndex = 5;
            this.signInLabel.Text = "SIGN IN";
            this.signInLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // sendPasswordButton
            // 
            this.sendPasswordButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sendPasswordButton.BackColor = System.Drawing.SystemColors.Control;
            this.sendPasswordButton.Font = new System.Drawing.Font("Sylfaen", 9.209303F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendPasswordButton.Location = new System.Drawing.Point(118, 275);
            this.sendPasswordButton.Name = "sendPasswordButton";
            this.sendPasswordButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.sendPasswordButton.Size = new System.Drawing.Size(100, 23);
            this.sendPasswordButton.TabIndex = 13;
            this.sendPasswordButton.Text = "Send password";
            this.sendPasswordButton.UseCompatibleTextRendering = true;
            this.sendPasswordButton.UseVisualStyleBackColor = false;
            this.sendPasswordButton.Click += new System.EventHandler(this.sendPasswordButton_Click);
            // 
            // emailTextbox
            // 
            this.emailTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.emailTextbox.Location = new System.Drawing.Point(11, 97);
            this.emailTextbox.Name = "emailTextbox";
            this.emailTextbox.Size = new System.Drawing.Size(207, 20);
            this.emailTextbox.TabIndex = 3;
            // 
            // emailRegisterTextBox
            // 
            this.emailRegisterTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.emailRegisterTextBox.Location = new System.Drawing.Point(11, 249);
            this.emailRegisterTextBox.Name = "emailRegisterTextBox";
            this.emailRegisterTextBox.Size = new System.Drawing.Size(207, 20);
            this.emailRegisterTextBox.TabIndex = 12;
            // 
            // passwordTextbox
            // 
            this.passwordTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordTextbox.Location = new System.Drawing.Point(11, 137);
            this.passwordTextbox.Name = "passwordTextbox";
            this.passwordTextbox.Size = new System.Drawing.Size(100, 20);
            this.passwordTextbox.TabIndex = 4;
            // 
            // emailLabel
            // 
            this.emailLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.emailLabel.AutoSize = true;
            this.emailLabel.BackColor = System.Drawing.Color.Transparent;
            this.emailLabel.CausesValidation = false;
            this.emailLabel.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.emailLabel.Location = new System.Drawing.Point(8, 227);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(40, 16);
            this.emailLabel.TabIndex = 11;
            this.emailLabel.Text = "Email";
            this.emailLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // passwordLabel
            // 
            this.passwordLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.BackColor = System.Drawing.Color.Transparent;
            this.passwordLabel.CausesValidation = false;
            this.passwordLabel.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.passwordLabel.Location = new System.Drawing.Point(8, 120);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(62, 16);
            this.passwordLabel.TabIndex = 7;
            this.passwordLabel.Text = "Password";
            this.passwordLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // registerLabel
            // 
            this.registerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.registerLabel.AutoSize = true;
            this.registerLabel.BackColor = System.Drawing.Color.Transparent;
            this.registerLabel.CausesValidation = false;
            this.registerLabel.Font = new System.Drawing.Font("Sylfaen", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.registerLabel.Location = new System.Drawing.Point(71, 210);
            this.registerLabel.Name = "registerLabel";
            this.registerLabel.Size = new System.Drawing.Size(76, 18);
            this.registerLabel.TabIndex = 10;
            this.registerLabel.Text = "REGISTER";
            this.registerLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // loginEmailLabel
            // 
            this.loginEmailLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loginEmailLabel.AutoSize = true;
            this.loginEmailLabel.BackColor = System.Drawing.Color.Transparent;
            this.loginEmailLabel.CausesValidation = false;
            this.loginEmailLabel.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginEmailLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.loginEmailLabel.Location = new System.Drawing.Point(8, 80);
            this.loginEmailLabel.Name = "loginEmailLabel";
            this.loginEmailLabel.Size = new System.Drawing.Size(40, 16);
            this.loginEmailLabel.TabIndex = 8;
            this.loginEmailLabel.Text = "Email";
            this.loginEmailLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // signInButton
            // 
            this.signInButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.signInButton.BackColor = System.Drawing.SystemColors.Control;
            this.signInButton.Font = new System.Drawing.Font("Sylfaen", 9.209303F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signInButton.Location = new System.Drawing.Point(149, 137);
            this.signInButton.Name = "signInButton";
            this.signInButton.Size = new System.Drawing.Size(75, 23);
            this.signInButton.TabIndex = 9;
            this.signInButton.Text = "Sign in";
            this.signInButton.UseVisualStyleBackColor = false;
            this.signInButton.Click += new System.EventHandler(this.signInButton_Click);
            // 
            // opponentsPanel
            // 
            this.opponentsPanel.BackColor = System.Drawing.Color.Transparent;
            this.opponentsPanel.Controls.Add(this.label1);
            this.opponentsPanel.Controls.Add(this.signOutButton);
            this.opponentsPanel.Controls.Add(this.playerList);
            this.opponentsPanel.Controls.Add(this.sendRequestButton);
            this.opponentsPanel.Controls.Add(this.opponentsLabel);
            this.opponentsPanel.Enabled = false;
            this.opponentsPanel.Location = new System.Drawing.Point(95, 115);
            this.opponentsPanel.Name = "opponentsPanel";
            this.opponentsPanel.Size = new System.Drawing.Size(235, 301);
            this.opponentsPanel.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.CausesValidation = false;
            this.label1.Font = new System.Drawing.Font("Sylfaen", 8.372093F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(25, 262);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Choose opponent and push invite";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // signOutButton
            // 
            this.signOutButton.BackColor = System.Drawing.SystemColors.Control;
            this.signOutButton.Font = new System.Drawing.Font("Sylfaen", 9.209303F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signOutButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.signOutButton.Location = new System.Drawing.Point(28, 279);
            this.signOutButton.Name = "signOutButton";
            this.signOutButton.Size = new System.Drawing.Size(69, 23);
            this.signOutButton.TabIndex = 3;
            this.signOutButton.Text = "Sign out";
            this.signOutButton.UseVisualStyleBackColor = false;
            this.signOutButton.Visible = false;
            this.signOutButton.Click += new System.EventHandler(this.signOutButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Client.Properties.Resources.Head;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(768, 97);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.BackColor = System.Drawing.Color.Transparent;
            this.welcomeLabel.Font = new System.Drawing.Font("Sylfaen", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.welcomeLabel.Location = new System.Drawing.Point(364, 130);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(0, 19);
            this.welcomeLabel.TabIndex = 18;
            // 
            // Client
            // 
            this.AcceptButton = this.signInButton;
            this.BackgroundImage = global::Client.Properties.Resources.BG;
            this.ClientSize = new System.Drawing.Size(792, 473);
            this.Controls.Add(this.welcomeLabel);
            this.Controls.Add(this.signInPanel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.replaysPanel);
            this.Controls.Add(this.opponentsPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Client";
            this.Text = "Chess: Lobby";
            this.Load += new System.EventHandler(this.Client_Load);
            this.replaysPanel.ResumeLayout(false);
            this.replaysPanel.PerformLayout();
            this.signInPanel.ResumeLayout(false);
            this.signInPanel.PerformLayout();
            this.opponentsPanel.ResumeLayout(false);
            this.opponentsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Client_Load(object sender, EventArgs e)
        {
            /*UsernameForm usernameForm = new UsernameForm();
            usernameForm.ShowDialog();
            connection.SendUsername(usernameForm.Username);*/
        }

        private void sendRequestButton_Click(object sender, EventArgs e)
        {
            connection.SendRequest((string)playerList.SelectedItem);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gameWindow.Show();
        }

        public void enterPage1()
        {
            PlayerList.Items.Clear();
            emailTextbox.Clear();
            opponentsPanel.Enabled = false;
            signInPanel.Visible = true;
            replaysPanel.Visible = false;
            signOutButton.Visible = false;
            player.Username = null;
            welcomeLabel.Text = null;
            emailTextbox.Focus();
        }

        public void enterPage2()
        {
            opponentsPanel.Enabled = true;
            signInPanel.Visible = false;
            replaysPanel.Visible = true;
            signOutButton.Visible = true;
            if (emailTextbox.Text.Contains("@"))
            {
                welcomeLabel.Text = "Welcome " + player.Username.Remove(player.Username.LastIndexOf("@")) + "!";
            }
            else
            {
                welcomeLabel.Text = "Welcome " + player.Username + "!";
            }
        }

        private void signInButton_Click(object sender, EventArgs e)
        {
            if (emailTextbox.Text.Length == 0)
            {
                MessageBox.Show(" You must enter your email adress.");
            }
            else
            {
                connection.SendLogin(emailTextbox.Text, passwordTextbox.Text);
            }
        }

        private void signOutButton_Click(object sender, EventArgs e)
        {
            connection.SendLogout();
            enterPage1();
        }

        private void sendPasswordButton_Click(object sender, EventArgs e)
        {
            new Register("", emailRegisterTextBox.Text).Send();
        }
    }
}
