using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace LibChess
{
    public static class PieceFactory
    {
        public static void InitBoard(Player p,Player p2, Board b)
        {
            //White pieces
            NewWhiteRook(p, b[1, 8]);
            NewWhiteKnight(p, b[2, 8]);
            NewWhiteBishop(p, b[3, 8]);
            NewWhiteQueen(p, b[4, 8]);
            NewWhiteKing(p, b[5, 8]);
            NewWhiteBishop(p, b[6, 8]);
            NewWhiteKnight(p, b[7, 8]);
            NewWhiteRook(p, b[8, 8]);
            for (int i = 1; i <= 8; i++) NewWhitePawn(p, b[i, 7]);

            //Black pieces
            NewBlackRook(p2, b[1, 1]);
            NewBlackKnight(p2, b[2, 1]);
            NewBlackBishop(p2, b[3, 1]);            
            NewBlackQueen(p2, b[4, 1]);
            NewBlackKing(p2, b[5, 1]);
            NewBlackBishop(p2, b[6, 1]);
            NewBlackKnight(p2, b[7, 1]);
            NewBlackRook(p2, b[8, 1]);
            for(int i = 1; i <= 8; i++) NewBlackPawn(p2, b[i, 2]);
        }

        static public Piece NewWhiteBishop(Player Player, Square Square)
        {
            return new Piece(Player, Square, new List<MoveBehaviour>() { new BishopMoveBehaviour() }, new WhiteBishopAppearance());
        }

        static public Piece NewBlackBishop(Player Player, Square Square)
        {
            return new Piece(Player, Square, new List<MoveBehaviour>() { new BishopMoveBehaviour() }, new BlackBishopAppearance());
        }

        static public Piece NewWhiteRook(Player Player, Square Square)
        {
            return new Piece(Player, Square, new List<MoveBehaviour>() { new RookMoveBehaviour() }, new WhiteRookAppearance());
        }

        static public Piece NewBlackRook(Player Player, Square Square)
        {
            return new Piece(Player, Square, new List<MoveBehaviour>() { new RookMoveBehaviour() }, new BlackRookAppearance());
        }

        static public Piece NewBlackKnight(Player Player, Square Square)
        {
            return new Piece(Player, Square, new List<MoveBehaviour>() { new KnightMoveBehaviour() }, new BlackKnightAppearance());
        }

        static public Piece NewWhiteKnight(Player Player, Square Square)
        {
            return new Piece(Player, Square, new List<MoveBehaviour>() { new KnightMoveBehaviour() }, new WhiteKnightAppearance());
        }

        static public Piece NewBlackKing(Player Player, Square Square)
        {
            Piece k = new Piece(Player, Square, new List<MoveBehaviour>() { new KingMoveBehaviour() }, new BlackKingAppearance());
            Player.King = k;
            return k;
        }

        static public Piece NewWhiteKing(Player Player, Square Square)
        {
            Piece k = new Piece(Player, Square, new List<MoveBehaviour>() { new KingMoveBehaviour() }, new WhiteKingAppearance());
            Player.King = k;
            return k;
        }

        static public Piece NewWhitePawn(Player Player, Square Square)
        {
            return new Piece(Player, Square, new List<MoveBehaviour>() { new WhitePawnMoveBehaviour() }, new WhitePawnAppearance());
        }

        static public Piece NewBlackPawn(Player Player, Square Square)
        {
            return new Piece(Player, Square, new List<MoveBehaviour>() { new BlackPawnMoveBehaviour() }, new BlackPawnAppearance());
        }

        static public Piece NewWhiteQueen(Player Player, Square Square)
        {
            return new Piece(Player, Square, new List<MoveBehaviour>() { new BishopMoveBehaviour(), new RookMoveBehaviour() }, new WhiteQueenAppearance());
        }

        static public Piece NewBlackQueen(Player Player, Square Square)
        {
            return new Piece(Player, Square, new List<MoveBehaviour>() { new BishopMoveBehaviour(), new RookMoveBehaviour() }, new BlackQueenAppearance());
        }

        static public void ConvertToQueen(Piece Piece)
        {
            Piece.MoveBehaviours = new List<MoveBehaviour>() { new BishopMoveBehaviour(), new RookMoveBehaviour() };
            foreach (MoveBehaviour m in Piece.MoveBehaviours) m.Piece = Piece;
            if (Piece.Appearance.ToString().Contains("White")) Piece.Appearance = new WhiteQueenAppearance();
            else Piece.Appearance = new BlackQueenAppearance();
        }

        static public void ConvertToBishop(Piece Piece)
        {
            Piece.MoveBehaviours = new List<MoveBehaviour>() { new BishopMoveBehaviour() };
            foreach (MoveBehaviour m in Piece.MoveBehaviours) m.Piece = Piece;
            if (Piece.Appearance.ToString().Contains("White")) Piece.Appearance = new WhiteBishopAppearance();
            else Piece.Appearance = new BlackBishopAppearance();
        }

        static public void ConvertToRook(Piece Piece)
        {
            Piece.MoveBehaviours = new List<MoveBehaviour>() { new RookMoveBehaviour() };
            foreach (MoveBehaviour m in Piece.MoveBehaviours) m.Piece = Piece;
            if (Piece.Appearance.ToString().Contains("White")) Piece.Appearance = new WhiteRookAppearance();
            else Piece.Appearance = new BlackRookAppearance();
        }

        static public void ConvertToKnight(Piece Piece)
        {
            Piece.MoveBehaviours = new List<MoveBehaviour>() { new KnightMoveBehaviour() };
            foreach (MoveBehaviour m in Piece.MoveBehaviours) m.Piece = Piece;
            if (Piece.Appearance.ToString().Contains("White")) Piece.Appearance = new WhiteKnightAppearance();
            else Piece.Appearance = new BlackKnightAppearance();
        }
    }
}
