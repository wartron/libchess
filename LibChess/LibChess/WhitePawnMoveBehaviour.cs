using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibChess
{
    public class WhitePawnMoveBehaviour : MoveBehaviour
    {
        public override List<Square> GetAccessibleSquares(bool CheckChess)
        {
            int i;
            if(CheckChess) i = 3;
            else i = 1;

            List<Square> accessibleSquares = new List<Square>();
            while (i <= 4)
            {
                Square square = piece.Square;
                bool attackCase = false;
                switch (i)
                {
                    case 1: if (!piece.Moved && board[square.X, square.Y - 1].Piece == null) square = board[square.X, square.Y - 2]; break; //alt first move
                    case 2: square = board[square.X, square.Y - 1]; break; //all moves
                    case 3: square = board[square.X - 1, square.Y - 1]; attackCase = true; break;//nw
                    case 4: square = board[square.X + 1, square.Y - 1]; attackCase = true; break; //ne
                    default: square = null; break;
                }

                if (attackCase && CheckSquare(square, CheckChess) == 'e') accessibleSquares.Add(square);
                else if (!attackCase && CheckSquare(square, CheckChess) == 'f') accessibleSquares.Add(square);

                i++;
            }
            return accessibleSquares;
        }
    }
}
