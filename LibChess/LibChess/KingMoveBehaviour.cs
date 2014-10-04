using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace LibChess
{
    public class KingMoveBehaviour : MoveBehaviour
    {
        public override List<Square> GetAccessibleSquares(bool CheckChess)
        {
            List<Square> accessibleSquares = new List<Square>();

            for (int i = 1; i <= 8; i++) // Åtta olika riktningar
            {
                Square square = piece.Square;
                switch (i)
                {
                    case 1: square = board[square.X - 1, square.Y]; break; //vänster
                    case 2: square = board[square.X + 1, square.Y]; break; //höger
                    case 3: square = board[square.X, square.Y - 1]; break; //upp
                    case 4: square = board[square.X, square.Y + 1]; break; //ned
                    case 5: square = board[square.X - 1, square.Y - 1]; break; //nw
                    case 6: square = board[square.X + 1, square.Y - 1]; break; //ne
                    case 7: square = board[square.X - 1, square.Y + 1]; break; //sw
                    case 8: square = board[square.X + 1, square.Y + 1]; break; //se
                        
                }
                switch (CheckSquare(square, CheckChess)) // se MoveBehaviour för vad bokstäverna betyder
                {
                    case 'f': accessibleSquares.Add(square); break;
                    case 'e': accessibleSquares.Add(square); square = null; break;
                    case 'b': square = null; break;
                    case 'x': square = null; break;
                }
            }

            if(Towers(6, 7, board[8, piece.Square.Y].Piece)) accessibleSquares.Add(board[7, piece.Square.Y]);
            if(Towers(2, 4, board[1, piece.Square.Y].Piece)) accessibleSquares.Add(board[2, piece.Square.Y]);

            return accessibleSquares;
        }

        private bool Towers(int Index, int End, Piece Rook)
        {
            bool retval = true;
            if (piece != null && Rook != null && !piece.Moved && !Rook.Moved)
            { 
                while (Index <= End)
                {
                    Square s = board[Index, piece.Square.Y];
                    
                    if(s.Piece != null)
                    {
                        retval = false;
                        break;
                    }
                    else if (s.Piece == null && !piece.Player.Game.ChessTestTurn(piece, s))
                    {
                        retval = false;
                        break;
                    }

                    Index++;
                }
            }
            else retval = false;
            return retval;
        }

        public bool CheckChess() //Kollar om kungen står i schack
        {
            foreach (Piece p in piece.Player.Opponent.Pieces)
            {
                if (p.GetAccessibleSquares(true).Contains(piece.Square)) return true;
            }
            return false;
        }
    }
}
