using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibChess
{
    public class Game
    {
        private readonly List<Player> players;
        private readonly Board board;
        private Player turn;

        public Game(List<Player> Players)
        {
            if(Players.Count == 2) players = Players;
            else Console.WriteLine("Two, and only two, players are required!");
            try { foreach (Player player in players) player.Game = this; }
            catch (Exception e) { }
            turn = players[0];
            board = new Board();
            PieceFactory.InitBoard(Players[0], Players[1], board);
        }

        public List<Player> Players
        {
            get { return players; }
        }

        public bool isTurn(Player player)
        {
            if (turn == player) return true;
            else return false;
        }

        public void nextTurn()
        {
            if (turn == players[0]) turn = players[1];
            else turn = players[0];
        }

        public Player Turn
        {
            get { return turn; }
        }

        public Board Board
        {
            get { return board; }
        }

        public bool ChessTestTurn(Piece Piece, Square s)
        {
            bool retval = true;
            KingMoveBehaviour kmv = (KingMoveBehaviour)Piece.Player.King.MoveBehaviours.First();
            Piece newSquarePiece = s.Piece; //the piece on the square which to move to
            Square newSquarePieceSquare = null; //the square which the piece is currently on
            Square oldSquare = Piece.Square;
            if (s.Piece != null)
            {
                newSquarePieceSquare = s.Piece.Square;
                newSquarePiece.Player.Pieces.Remove(newSquarePiece);
            }
            s.Piece = Piece;
            Piece.Square.Piece = null;
            s.Piece.Square = s;
            if (kmv.CheckChess()) retval = false;
            s.Piece = newSquarePiece;
            Piece.Square = oldSquare;
            Piece.Square.Piece = Piece;
            if (s.Piece != null)
            {
                s.Piece.Square = newSquarePieceSquare;
                newSquarePiece.Player.Pieces.Add(newSquarePiece);
            }

            return retval;
        }
    }
}
