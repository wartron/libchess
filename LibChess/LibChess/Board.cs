using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibChess
{
    public class Board
    {
        private readonly List<Square> squares = new List<Square>();
        private bool updated = true;

        public Board()
        {
            for(int x = 1; x <= 8; x++)
            {
                for (int y = 1; y <= 8; y++)
                {
                    squares.Add(new Square(x,y,this));
                }
            }
        }

        public List<Square> Squares
        {
            get { return squares; }
        }

        public bool Updated
        {
            get { return updated; }
            set { updated = value; }    
        }

        public Square this[int X, int Y]
        {
            get
            {
                foreach (Square square in squares)
                {
                    if(square.X == X && square.Y == Y) return square;
                }
                return null;
            }
        }
    }
}
