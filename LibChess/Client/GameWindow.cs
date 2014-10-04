using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibChess;

namespace Client
{
    public partial class GameWindow : Form
    {
        private Game game;
        private Client client;
        private List<Image> imagelist = new List<Image>();
        private List<Piece> WhiteLost = new List<Piece>();
        private List<Piece> BlackLost = new List<Piece>();
        private PictureBox[,] boxes = new PictureBox[8,8];
        private Piece selectedPiece;
        private Color highlightColor = Color.FromArgb(129, 213, 176);
        private Color highlightColor2 = Color.FromArgb(71, 140, 109);

        public GameWindow(Client Client, Game Game)
        {
            
            InitializeComponent();
            game = Game;
            client = Client;
            //Visa usernames på spelbrädet
            WhitePlayerName.Text = Game.Players[0].Username + " " + "has lost:";
            BlackPlayerName.Text = Game.Players[1].Username + " " + "has lost:";
            BlackPlayerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            WhitePlayerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            BlackPlayerName.Font = new System.Drawing.Font("Sylfaen", 10.04651F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            WhitePlayerName.Font = new System.Drawing.Font("Sylfaen", 10.04651F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            BlackPlayerName.Size = new System.Drawing.Size(83, 18);
            WhitePlayerName.Size = new System.Drawing.Size(83, 18);
            BlackPlayerName.TabIndex = 8;
            WhitePlayerName.TabIndex = 8;
            BlackPlayerName.Location = new System.Drawing.Point(945, 80);
            WhitePlayerName.Location = new System.Drawing.Point(945, 498);
            BlackPlayerName.AutoSize = true;
            WhitePlayerName.AutoSize = true;
            WhitePlayerName.BackColor = Color.Transparent;
            BlackPlayerName.BackColor = Color.Transparent;
            WhitePlayerName.ForeColor = Color.White;
            BlackPlayerName.ForeColor = Color.White;
            WhitePlayerName.Invalidate();
            BlackPlayerName.Invalidate();
            WhitePlayerName.Update();
            BlackPlayerName.Update();
            foreach (Square s in Game.Board.Squares)
            {
                PictureBox box = new PictureBox();
                box.Parent = GamePanel;
                SetBoxColor(box, s, Color.Silver, Color.DimGray);
                box.BackgroundImageLayout = ImageLayout.Center;
                if (s.Piece != null) box.BackgroundImage = s.Piece.Appearance.Image;
                box.Bounds = new Rectangle(s.X * 60, s.Y * 60, 60, 60);
                box.Tag = s;
                box.MouseEnter += new EventHandler(BoxHover);
                box.MouseLeave += new EventHandler(BoxLeave);
                box.Click += new EventHandler(BoxClicked);
                boxes[s.X - 1, s.Y - 1] = box;
            }
            this.Show();
            ChatInputBox.Focus();
         }

        private void SetBoxColor(PictureBox box, Square s, Color Light, Color Dark)
        {
            if (s.X % 2 == 0 && s.Y % 2 == 0) box.BackColor = Light;
            else if (s.X % 2 != 0 && s.Y % 2 == 0) box.BackColor = Dark;
            else if (s.X % 2 != 0 && s.Y != 0) box.BackColor = Light;
            else box.BackColor = Dark;
        }

        private void BoxHover(Object Sender, EventArgs Args)
        {
            if (!game.isTurn(client.Player)) return;
            Square Square = (Square)((PictureBox)Sender).Tag;
            if (selectedPiece == null && Square != null && Square.Piece != null && Square.Piece.Player == client.Player)
            {
                HighLightSquares(Square.Piece);
            }
        }

        private void BoxLeave(Object Sender, EventArgs Args)
        {
            Square Square = (Square)((PictureBox)Sender).Tag;
            if (selectedPiece == null && Square != null && Square.Piece != null && Square.Piece.Player == client.Player)
            {
                UpdateSquare(Square);
            }
        }

        private void BoxClicked(Object Sender, EventArgs Args)
        {
            if (!game.isTurn(client.Player)) return;
            Square Square = (Square)((PictureBox)Sender).Tag;
            if (selectedPiece != null && Square != null)
            {
                if (selectedPiece == Square.Piece)
                {
                    selectedPiece = null;
                }
                else if (Square.Piece != null && Square.Piece.Player == client.Player)
                {
                    UpdateSquare(selectedPiece.Square);
                    selectedPiece = Square.Piece;
                    HighLightSquares(selectedPiece);
                }
                else if(!selectedPiece.GetAccessibleSquares().Contains(Square))
                {
                    UpdateSquare(selectedPiece.Square);
                    selectedPiece = null;
                }
                else
                {
                    client.Connection.MovePiece(selectedPiece, Square);
                    selectedPiece = null;
                }
            }
            else if (Square.Piece != null && Square.Piece.Player == client.Player)
            {
                selectedPiece = Square.Piece;
                HighLightSquares(selectedPiece);
            }
        }

        public void UpdateSquare(Square Square)
        {
            List<Square> squares = new List<Square> { Square };
            if(Square.Piece != null) squares.AddRange(Square.Piece.GetAccessibleSquares());
            UpdateSquares(squares);
        }

        public void UpdateSquares(List<Square> Squares)
        {
            foreach (Square s in Squares)
            {
                PictureBox box = boxes[s.X - 1, s.Y - 1];
                SetBoxColor(box, s, Color.Silver, Color.DimGray);
                if (s.Piece != null) box.BackgroundImage = s.Piece.Appearance.Image;
                else if (box.BackgroundImage != null) box.BackgroundImage = null;
                box.Invalidate();
            }
        }

        private void HighLightSquares(Piece Piece)
        {
            foreach (Square s in Piece.GetAccessibleSquares())
            {
                if (game.ChessTestTurn(Piece, s)) SetBoxColor(boxes[s.X - 1, s.Y - 1], s, highlightColor, highlightColor2);
            }
            SetBoxColor(boxes[Piece.Square.X - 1, Piece.Square.Y - 1], Piece.Square, highlightColor, highlightColor2);
        } 

        public Game Game
        {
            get { return game; }
            set { game = value; }
        }

        private void GameWindow_Load(object sender, EventArgs e)
        {
            
            
        }

        public void Draw()
        {
            GamePanel.Invalidate();
        }

        private void GamePanel_Paint(object sender, PaintEventArgs e)
        {
           /* Rectangle[] r = new Rectangle[32];
            int i = 0;
            int ggr = 1;
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    r[i] = new Rectangle(x * 120 + ggr * 60, y * 60 + 60, 60, 60);
                    ggr ^= 3;
                    i++;
                }
            }
            int xx = 474 / 14; int yy = 1095 / 19;
            e.Graphics.FillRectangle(Brushes.Silver, new Rectangle(60, 60, 480, 480));
            e.Graphics.FillRectangles(Brushes.DimGray, r);

            foreach (Player player in Game.Players)
            {
                foreach (Piece p in player.Pieces)
                {
                    e.Graphics.DrawImage(p.Appearance.Image, new Rectangle(p.Square.X * 60 + (60 - xx) / 2, p.Square.Y * 60 + (60 - yy) / 2, xx, yy));
                }
            }*/
        }

        public void update() //lägg till förlorade pjäser på listan som strängar
        {
            LpPawnPanelBlack.Invalidate();
            LpRoyalPanelBlack.Invalidate();
            LpPawnPanelWhite.Invalidate();
            LpRoyalPanelWhite.Invalidate();
        }
        private void RestartButton_Click(object sender, EventArgs e)
        {
            this.Close();
            //new game
        }
                
        private void QuitButton_Click(object sender, EventArgs e)
        {
            DialogResult quitGame = MessageBox.Show("Are you sure you want to quit?", "Quit", MessageBoxButtons.YesNo);
            if (quitGame == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                return;
            }
        }

        private void BannerPanel_Paint(object sender, PaintEventArgs e)
        {

        }
               
        private void ChatInputBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            string z = client.Player.Username + ": " + ChatInputBox.Text;
            ChatInputBox.Clear();
            client.Connection.SendText(z);
        }

        public void updateChat(string message)
        {
            ChatWindow.SelectionStart = ChatWindow.Text.Length;
            ChatWindow.ScrollToCaret();
            ChatWindow.AppendText(message + "\n");
            ChatWindow.Update();
            ChatWindow.Invalidate();
            
        }

        private void ChatWindow_TextChanged(object sender, EventArgs e)
        {

        }

        private void ChatWindow_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void eventLog1_EntryWritten(object sender, System.Diagnostics.EntryWrittenEventArgs e)
        {

        }

        private void LpPawnPanelBlack_Paint(object sender, PaintEventArgs e)
        {
            int place = 1;
            foreach (Piece p in Game.Players[1].LostPieces) {
                if (p.Appearance.GetType().ToString().Equals("LibChess.BlackPawnAppearance"))
                {
                    e.Graphics.DrawImage(p.Appearance.Image,new Rectangle(place, 1, 22, 43));
                    place += 23;
                }
            }
        }

        private void LpPawnPanelWhite_Paint(object sender, PaintEventArgs e)
        {
            int place = 1;
            foreach (Piece p in Game.Players[0].LostPieces)
            {
                if (p.Appearance.GetType().ToString().Equals("LibChess.WhitePawnAppearance"))
                {
                    e.Graphics.DrawImage(p.Appearance.Image, new Rectangle(place, 1, 22, 43));
                    place += 23;
                }
            }
        }

        private void LpRoyalPanelBlack_Paint(object sender, PaintEventArgs e)
        {
            int place = 1;
            foreach (Piece p in Game.Players[1].LostPieces)
            {
                if (p.Appearance.GetType().ToString().Equals("LibChess.BlackRookAppearance"))
                {
                    e.Graphics.DrawImage(p.Appearance.Image, new Rectangle(place, 1, 22, 43));
                    place += 23;
                }
                else if (p.Appearance.GetType().ToString().Equals("LibChess.BlackKnightAppearance"))
                {
                    e.Graphics.DrawImage(p.Appearance.Image, new Rectangle(place, 1, 22, 43));
                    place += 23;
                }
                else if (p.Appearance.GetType().ToString().Equals("LibChess.BlackBishopAppearance"))
                {
                    e.Graphics.DrawImage(p.Appearance.Image, new Rectangle(place, 1, 22, 43));
                    place += 23;
                }
                else if (p.Appearance.GetType().ToString().Equals("LibChess.BlackQueenAppearance"))
                {
                    e.Graphics.DrawImage(p.Appearance.Image, new Rectangle(place, 1, 22, 43));
                    place += 23;
                }
                else if (p.Appearance.GetType().ToString().Equals("LibChess.BlackKingAppearance"))
                {
                    e.Graphics.DrawImage(p.Appearance.Image, new Rectangle(place, 1, 22, 43));
                    place += 23;
                }
            }
        }

        private void LpRoyalPanelWhite_Paint(object sender, PaintEventArgs e)
        {
            int place = 1;
            foreach (Piece p in Game.Players[0].LostPieces)
            {
                if (p.Appearance.GetType().ToString().Equals("LibChess.WhiteRookAppearance"))
                {
                    e.Graphics.DrawImage(p.Appearance.Image, new Rectangle(place, 1, 22, 43));
                    place += 23;
                }
                else if (p.Appearance.GetType().ToString().Equals("LibChess.WhiteKnightAppearance"))
                {
                    e.Graphics.DrawImage(p.Appearance.Image, new Rectangle(place, 1, 22, 43));
                    place += 23;
                }
                else if (p.Appearance.GetType().ToString().Equals("LibChess.WhiteBishopAppearance"))
                {
                    e.Graphics.DrawImage(p.Appearance.Image, new Rectangle(place, 1, 22, 43));
                    place += 23;
                }
                else if (p.Appearance.GetType().ToString().Equals("LibChess.WhiteQueenAppearance"))
                {
                    e.Graphics.DrawImage(p.Appearance.Image, new Rectangle(place, 1, 22, 43));
                    place += 23;
                }
                else if (p.Appearance.GetType().ToString().Equals("LibChess.WhiteKingAppearance"))
                {
                    e.Graphics.DrawImage(p.Appearance.Image, new Rectangle(place, 1, 22, 43));
                    place += 23;
                }
            }
        }
    }
}
