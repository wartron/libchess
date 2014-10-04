using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibChess
{
    public class Player
    {
        private string username;
        private Game game;
        private Piece king;
        private List<Piece> pieces = new List<Piece>();
        private List<Piece> lostPieces = new List<Piece>();

        public Player(string Username)
        {
            username = Username;
        }

        public Player() { }

        public Piece King
        {
            set { king = value; }
            get { return king; }
        }

        public Player Opponent
        {
            get
            {
                foreach (Player p in game.Players)
                {
                    if (p != null && p != this) return p;
                }
                return null;
            }
        }

        public Game Game
        {
            set { if(value.Players.Contains(this)) game = value; }
            get { return game; }
        }

        public string Username
        {
            set { username = value; }
            get { return username; }
        }

        public List<Piece> Pieces
        {
            set { pieces = value; }
            get { return pieces; }
        }

        public List<Piece> LostPieces
        {
            set { lostPieces = value; }
            get { return lostPieces; }
        }
    }
}
