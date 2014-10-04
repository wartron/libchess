using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibChess
{
    public class Square
    {
        private readonly int x;
        private readonly int y;
        private Piece piece;
        private readonly Board board;

        public Square(int X, int Y, Board Board)
        {
            x = X;
            y = Y;
            board = Board;
        }

        public Piece Piece
        {
            set { piece = value; }
            get { return piece; }
        }

        public Board Board
        {
            get { return board; }
        }
        
        public int X
        {
            get { return x; }
        }

        public int Y
        {
            get { return y; }
        }
    }
}
