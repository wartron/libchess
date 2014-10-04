using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibChess;

namespace Server
{
    static class Command
    {
        public static string Parse(string Message, Connection Connection)
        {
            string answer = null;

            char command;
            if (Message != null) command = Message[0];
            else command = 'e';

            if (Connection.Player.Username == null && command != 'u') return null;

            string parameters = Message.Substring(1, Message.Length - 1);

            switch(command)
            {
                case 'u':
                    {// logga in med användarnamn och lösen
                        try
                        {
                            string[] userData = parameters.Split('|');
                            Connection.SendNewPlayer(userData[0]);
                            Connection.Player.Username = userData[0];
                            Logger.LogEvent("Player " + Connection.Player.Username + " signed in.");
                            answer = "u" + userData[0];
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.InnerException+"\n"+e.StackTrace);
                            Parse("-" + Connection.Player.Username, Connection);
                        }
                        break;
                    }
                case 'l':
                    {// returnera spelarlista
                        answer = "l";
                        foreach (Connection connection in Connection.Server.Connections)
                        {
                            if(connection.Player.Username != null && connection.Player.Username.Trim().Length > 0)
                                answer += connection.Player.Username + "|";
                        }
                        break;
                    }
                case 'r':
                    {// skicka request till anvigen spelare
                        Connection connection = Connection.Server.GetConnectionByUsername(parameters);
                        if (connection != null) connection.SendRequest(Connection.Player.Username);
                        break;
                    }
                case 'n':
                    {// starta nytt spel
                        if (Connection.LastRequest.Equals(parameters))
                        {
                            Connection.Server.Games.Add(new Game(new List<Player>() { Connection.Player, Connection.Server.GetPlayer(parameters) }));
                            answer = "n" + parameters + "w";
                            Connection.Server.GetConnectionByUsername(parameters).SendNewgame(Connection.Player.Username, false);
                        }
                        break;
                    }
                case 't':
                    {// skicka text till spelares chatt fönster
                        Connection.SendText(parameters);
                        Connection.Server.GetConnectionByUsername(Connection.Player.Opponent.Username).SendText(parameters);
                        break;
                    }
                case 'm':
                    { // flytta pjäs
                        try
                        {
                            Piece piece = Connection.Player.Game.Board[int.Parse(parameters[0].ToString()), int.Parse(parameters[1].ToString())].Piece;
                            if (piece.Player.Game.isTurn(piece.Player))
                            {
                                //Emulera ett drag för att testa schack mm.

                                Square moveTo = Connection.Player.Game.Board[int.Parse(parameters[2].ToString()), int.Parse(parameters[3].ToString())];
                                bool fail = false;
                                KingMoveBehaviour kmv = (KingMoveBehaviour)piece.Player.King.MoveBehaviours.First();
                                Piece newSquarePiece = moveTo.Piece; //the piece on the square which to move to
                                Square newSquarePieceSquare = null; //the square which the piece is currently on
                                Square oldSquare = piece.Square;
                                List<Square> accesibleSquares = piece.GetAccessibleSquares();
                                if (accesibleSquares.Contains(moveTo))
                                {
                                    //rockád
                                    if (piece.Player.King == piece &&
                                        ((moveTo == moveTo.Board[7, piece.Square.Y] && moveTo.Board[8, piece.Square.Y].Piece != null && !moveTo.Board[8, piece.Square.Y].Piece.Moved) ||
                                        (moveTo == moveTo.Board[2, piece.Square.Y] && moveTo.Board[1, piece.Square.Y].Piece != null && !moveTo.Board[1, piece.Square.Y].Piece.Moved)) &&
                                        piece.GetAccessibleSquares().Contains(moveTo) && !piece.Moved)
                                    {
                                        Piece rook = null;
                                        if (moveTo.X == 7) rook = moveTo.Board[8, piece.Square.Y].Piece;
                                        else rook = moveTo.Board[1, piece.Square.Y].Piece;
                                        Square rookSquare = rook.Square;
                                        Square newRookSquare = null;
                                        Square newKingSquare = null;
                                        switch (moveTo.X)
                                        {
                                            case 7:
                                                newRookSquare = piece.Square.Board[6, piece.Square.Y];
                                                newKingSquare = piece.Square.Board[7, piece.Square.Y];
                                                break;
                                            case 2:
                                                newRookSquare = piece.Square.Board[3, piece.Square.Y];
                                                newKingSquare = piece.Square.Board[2, piece.Square.Y];
                                                break;
                                        }

                                        rook.Square.Piece = null;
                                        piece.Square.Piece = null;
                                        newRookSquare.Piece = rook;
                                        newKingSquare.Piece = piece;
                                        newRookSquare.Piece.Square = newRookSquare;
                                        newKingSquare.Piece.Square = newKingSquare;
                                        if (kmv.CheckChess())
                                        {
                                            fail = true;
                                            newRookSquare.Piece = null;
                                            newKingSquare.Piece = null;
                                            rook.Square.Piece = newSquarePiece;
                                            piece.Square.Piece = piece;
                                        }
                                        else
                                        {
                                            parameters = oldSquare.X.ToString() + oldSquare.Y.ToString() +
                                                newKingSquare.X.ToString() + newKingSquare.Y.ToString() + "|" +
                                                rookSquare.X.ToString() + rookSquare.Y.ToString() +
                                                newRookSquare.X.ToString() + newRookSquare.Y.ToString();
                                            answer = "m" + parameters;
                                        }
                                    }
                                    else
                                    {
                                        if (moveTo.Piece != null)
                                        {
                                            newSquarePieceSquare = moveTo.Piece.Square;
                                            newSquarePiece.Player.Pieces.Remove(newSquarePiece);
                                        }
                                        moveTo.Piece = piece;
                                        piece.Square.Piece = null;
                                        moveTo.Piece.Square = moveTo;
                                        if (kmv.CheckChess())
                                        {
                                            fail = true;
                                            moveTo.Piece = newSquarePiece;
                                            piece.Square = oldSquare;
                                            piece.Square.Piece = piece;
                                            if (moveTo.Piece != null)
                                            {
                                                moveTo.Piece.Square = newSquarePieceSquare;
                                                newSquarePiece.Player.Pieces.Add(newSquarePiece);
                                            }
                                        }
                                        else
                                        {
                                            answer = Message;
                                        }
                                    }
                                    if (fail) return "me" + piece.Square.X.ToString() + piece.Square.Y.ToString();

                                    piece.Moved = true;

                                    //kod för checkmate
                                    bool checkMate = false;
                                    if (((KingMoveBehaviour)piece.Player.Opponent.King.MoveBehaviours.First()).CheckChess())
                                    { // här kollar vi om det är schackmatt på g, denna kod dock halvtrasig!
                                        checkMate = true;
                                        foreach (Piece p in piece.Player.Opponent.Pieces)
                                        {
                                            foreach (Square s in p.GetAccessibleSquares())
                                            {
                                                if (p.Player.Game.ChessTestTurn(p, s)) checkMate = false;
                                            }
                                            if (!checkMate) break;
                                        }

                                        if (checkMate)
                                        {
                                            Connection.Server.GetConnectionByUsername(Connection.Player.Opponent.Username).SendVictory();
                                            return "c"; //checkmate
                                        }
                                    }
                                    
                                    piece.Player.Game.nextTurn();
                                    
                                    Connection.Server.GetConnectionByUsername(Connection.Player.Opponent.Username).SendMove(parameters);
                                }
                                else answer = "me" + parameters[0] + parameters[1];
                            }
                            else answer = "me";
                        }
                        catch (Exception Ex)
                        {
                            answer = "me";
                            Logger.LogEvent(Ex.StackTrace);
                        }
                        break;
                    }
                case '-':
                    {
                        string username = Connection.Player.Username;
                        Connection.Player.Username = null;
                        Connection.SendPlayerQuit(username);
                        break;
                    }
                case 'p':
                    {
                        Piece piece = Connection.Player.Game.Board[int.Parse(parameters[1].ToString()), int.Parse(parameters[2].ToString())].Piece;
                        if (piece != null && piece.MoveBehaviours[0].ToString().Contains("Pawn") &&
                            (piece.Square.Y == 8 || piece.Square.Y == 1))
                        {
                            switch (parameters[0])
                            {
                                case 'k': PieceFactory.ConvertToKnight(piece); break;
                                case 'b': PieceFactory.ConvertToBishop(piece); break;
                                case 'r': PieceFactory.ConvertToRook(piece); break;
                                case 'q': PieceFactory.ConvertToQueen(piece); break;
                            }

                            answer = "p" + parameters;
                            Connection.Server.GetConnectionByUsername(Connection.Player.Opponent.Username).SendPromotion(parameters);

                        }
                        break;
                    }
            }
            return answer;
        }
    }
}
