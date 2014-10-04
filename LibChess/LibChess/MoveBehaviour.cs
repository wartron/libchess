using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibChess
{
    abstract public class MoveBehaviour
    {
        protected Piece piece;
        protected Board board;

        public Piece Piece
        {
            set { piece = value; board = piece.Square.Board; }
        }

        protected char CheckSquare(Square Square)
        {
            return CheckSquare(Square, false);
        }

        protected char CheckSquare(Square Square, bool CheckChess)
        {
            if (Square != null)
            {
                if (!CheckChess && piece == piece.Player.King && piece.Player.Opponent.King.GetAccessibleSquares(true).Contains(Square)) return 'b'; // this is a king and the square is in range of opponents king
                else if (Square.Piece == null) return 'f'; // free square
                else if (!CheckChess && (Square.Piece.Player.King == Square.Piece ||
                    Square.Piece.Player.Opponent.King == Square.Piece)) return 'b'; //busy by king
                else if (Square.Piece.Player != piece.Player) return 'e'; // busy by other player
                else return 'b'; // busy by friendly
            }
            return 'x'; //not a square
        }

        abstract public List<Square> GetAccessibleSquares(bool CheckChess);

        public List<Square> GetAccessibleSquares()
        {
            return GetAccessibleSquares(false);
        }
    }
}
