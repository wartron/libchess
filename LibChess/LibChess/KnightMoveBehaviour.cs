using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace LibChess
{
    public class KnightMoveBehaviour : MoveBehaviour
    {
        public override List<Square> GetAccessibleSquares(bool CheckChess)
        {
            List<Square> accessibleSquares = new List<Square>();
            for (int i = 1; i <= 8; i++) // Åtta olika riktningar
            {
                Square square = piece.Square;
                switch (i)
                {
                    case 1: square = board[square.X - 2, square.Y + 1]; break; //vänster2 ned1
                    case 2: square = board[square.X - 2, square.Y - 1]; break; //vänster2 upp1
                    case 3: square = board[square.X - 1, square.Y + 2]; break; //vänster1 ned2
                    case 4: square = board[square.X - 1, square.Y - 2]; break; //vänster1 upp2
                    case 5: square = board[square.X + 2, square.Y + 1]; break; //höger2 ned1
                    case 6: square = board[square.X + 2, square.Y - 1]; break; //höger2 upp1
                    case 7: square = board[square.X + 1, square.Y + 2]; break; //höger1 ned2
                    case 8: square = board[square.X + 1, square.Y - 2]; break; //höger1 upp2
                }
                switch (CheckSquare(square, CheckChess)) // se MoveBehaviour för vad bokstäverna betyder
                {
                    case 'f': accessibleSquares.Add(square); break;
                    case 'e': accessibleSquares.Add(square); square = null; break;
                    case 'b': square = null; break;
                    case 'x': square = null; break;
                }
            }
            return accessibleSquares;
        }
    }
}
