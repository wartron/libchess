using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibChess
{
    public class Piece
    {
        private Player player;
        private Square square;
        private bool moved = false;
        private bool secondTurn = false;
        private List<MoveBehaviour> moveBehaviours;
        private Appearance appearance;

        public Piece(Player Player, Square Square, List<MoveBehaviour> MoveBehaviours, Appearance Appearance)
        {
            player = Player;
            Player.Pieces.Add(this);
            square = Square;
            square.Piece = this;
            moveBehaviours = MoveBehaviours;
            appearance = Appearance;
            foreach (MoveBehaviour moveBehaviour in moveBehaviours) moveBehaviour.Piece = this;
        }

        public List<Square> GetAccessibleSquares()
        {
            return GetAccessibleSquares(false);
        }

        public List<Square> GetAccessibleSquares(bool AttackOnly)
        {
            List<Square> squares = new List<Square>();
            foreach (MoveBehaviour moveBehaviour in moveBehaviours)
            {
                squares.AddRange(moveBehaviour.GetAccessibleSquares(AttackOnly));
            }
            return squares;
        }

        public Appearance Appearance
        {
            set { appearance = value; }
            get { return appearance; }
        }

        public Player Player
        {
            get { return player; }
        }

        public Square Square
        {
            get { return square; }
            set { square = value; }
        }

        public List<MoveBehaviour> MoveBehaviours
        {
            get { return moveBehaviours; }
            set
            {
                moveBehaviours = value;
            }
        }

        public bool SecondTurn
        {
            get { return secondTurn; }
        }

        public bool Moved
        {
            get { return moved; }
            set
            {
                if (!moved)
                {
                    moved = value;
                    secondTurn = true;
                }
                else if (secondTurn)
                {
                    secondTurn = false;
                }
            }
        }
    }
}
