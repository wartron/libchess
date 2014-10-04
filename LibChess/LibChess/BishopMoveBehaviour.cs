using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibChess
{
    public class BishopMoveBehaviour : MoveBehaviour
    {
        public override List<Square> GetAccessibleSquares(bool CheckChess)
        {
            List<Square> accessibleSquares = new List<Square>();
            for (int i = 1; i <= 4; i++)
            {
                for (Square square = piece.Square; square != null;)
                {
                    switch (i)
                    {
                        case 1: square = board[square.X - 1, square.Y - 1]; break; //nw
                        case 2: square = board[square.X + 1, square.Y - 1]; break; //ne
                        case 3: square = board[square.X - 1, square.Y + 1]; break; //sw
                        case 4: square = board[square.X + 1, square.Y + 1]; break; //se
                        default: square = null; break;
                    }

                    switch (CheckSquare(square, CheckChess)) // se MoveBehaviour för vad bokstväerna betyder
                    {
                        case 'f': accessibleSquares.Add(square); break;
                        case 'e': accessibleSquares.Add(square); square = null; break;
                        case 'b': square = null; break;
                        case 'x': square = null; break;
                    }
                }
            }
            return accessibleSquares;
        }
    }
}
