using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibChess;

namespace Client
{
    static class Command
    {
        public delegate void GameWindowDelegate(Connection Connection, string Parameters);
        public static void StartNewGame(Connection Connection, string Parameters)
        {
            try
            {
                if (Connection.Client.InvokeRequired) Connection.Client.Invoke(new GameWindowDelegate(StartNewGame), new Object[] { Connection, Parameters });
                else
                {
                    List<Player> players;
                    string username = Parameters.Substring(0, Parameters.Length - 1);
                    if (Parameters.ToCharArray().Last() == 'w') players = new List<Player>() { Connection.Client.Player, new Player(username) };
                    else if (Parameters.ToCharArray().Last() == 'b') players = new List<Player>() { new Player(username), Connection.Client.Player };
                    else return;
                    Game g = new Game(players);
                    Connection.Client.GameWindow = new GameWindow(Connection.Client, g);
                }
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);
            }
            
        }

        public delegate void RecievePlayerListDelegate(Connection Connection, string Parameters);
        public static void RecievePlayerList(Connection Connection, string Parameters)
        {
            Connection.Client.Player.Username = Connection.Client.EmailTextbox.Text;
            if (Connection.Client.PlayerList.InvokeRequired) Connection.Client.Invoke(new RecievePlayerListDelegate(RecievePlayerList), new Object[] { Connection, Parameters } );
            else
            {
                Connection.Client.PlayerList.Items.Clear();
                Parameters = Parameters.Remove(Parameters.LastIndexOf('|'));
                Connection.Client.PlayerList.Items.AddRange(Parameters.Split('|'));
                Connection.Client.PlayerList.Items.Remove(Connection.Client.Player.Username);
            }
        }

        public delegate void UpdateChatDelegate(Connection Connection, string Parameters);
        public static void UpdateChat(Connection Connection, string Parameters)
        {
            if(Connection.Client.PlayerList.InvokeRequired) Connection.Client.Invoke(new UpdateChatDelegate(UpdateChat), new Object[] { Connection, Parameters });
            else
            {
                Connection.Client.GameWindow.updateChat(Parameters);
            }
        }

        public delegate void RemovePlayerDelegate(Connection Connection, string Parameters);
        public static void RemovePlayer(Connection Connection, string Parameters)
        {
            if (Connection.Client.PlayerList.InvokeRequired) Connection.Client.Invoke(new RemovePlayerDelegate(RemovePlayer), new Object[] { Connection, Parameters });
            else
            {
                Connection.Client.PlayerList.Items.Remove(Parameters);
                Connection.Client.PlayerList.Invalidate();
            }
        }

        public delegate void AddPlayerDelegate(Connection Connection, string Parameters);
        public static void AddPlayer(Connection Connection, string Parameters)
        {
            if (Connection.Client.PlayerList.InvokeRequired) Connection.Client.Invoke(new AddPlayerDelegate(AddPlayer), new Object[] { Connection, Parameters });
            else
            {
                Connection.Client.PlayerList.Items.Add(Parameters);
                Connection.Client.PlayerList.Invalidate();
            }
        }

        public static string Parse(string Message, Connection Connection)
        {
            string answer = null;

            if (Message.Length < 1) return answer;

            char command;
            string parameters;
            if (Message != null)
            {
                command = Message[0];
                parameters = Message.Substring(1, Message.Length - 1);
            }
            else
            {
                command = 'e';
                parameters = "";
            }
            switch(command)
            {
                case '-':
                    { // ta bort spelare (disconnected)
                      RemovePlayer(Connection, parameters);
                      //if (Connection.Client.Player.Opponent.Username == parameters) ;//stäng av spelet
                      break;
                    }
                case '+':
                    { // lägg till spelare (connect)
                        AddPlayer(Connection, parameters);
                      break;
                    }
                case 'u':
                    {// logga in med användarnamn
                        Connection.Client.Player.Username = parameters;
                        if (Connection.Client.InvokeRequired) Connection.Client.Invoke(new MethodInvoker(Connection.Client.enterPage2));
                        else Connection.Client.enterPage2();
                        answer = "l";
                        break;
                    }
                case 'l':
                    {// ta emot spelarlista
                        RecievePlayerList(Connection, parameters);
                        break;
                    }
                case 'r':
                    {// ta emot spelrequest
                        DialogResult newGame = MessageBox.Show("Do you want to start a new game with " + parameters + "?", "New game", MessageBoxButtons.YesNo);
                        if (newGame == DialogResult.Yes) answer = "n" + parameters;
                        else answer = "d" + parameters;
                        break;
                    }
                case 'n':
                    {// starta nytt spel
                        StartNewGame(Connection, parameters.Trim());
                        break;
                    }
                case 't':
                    {// uppdatera texten i spelares chatt fönster
                        UpdateChat(Connection, parameters);
                        break;
                    }
                case 'c':
                    {
                        DialogResult lol = MessageBox.Show("CHECKMATE", "Checkmate!", MessageBoxButtons.OK);
                        if (lol == DialogResult.OK) Connection.Client.GameWindow.Close();
                        break;
                    }
                case 'v':
                    {
                        DialogResult lol = MessageBox.Show("VICTORY!", "Victory!", MessageBoxButtons.OK);
                        if (lol == DialogResult.OK) Connection.Client.GameWindow.Close();
                        break;
                    }
                case 'm':
                    { // flytta pjäs
                        if (Message[1] == 'e')
                        {
                            if (Message.Length > 2)
                            {
                                Piece errorPiece = Connection.Client.Player.Game.Board[int.Parse(parameters[1].ToString()), int.Parse(parameters[2].ToString())].Piece;
                                List<Square> errorSquares = errorPiece.GetAccessibleSquares();
                                errorSquares.Add(errorPiece.Square);
                                Connection.Client.GameWindow.UpdateSquares(errorSquares);
                            }
                            return null;
                        }
                        List<Square> affectedSquares = new List<Square>();
                        bool moreMoves = true;
                        while (moreMoves)
                        {
                            Piece p = Connection.Client.Player.Game.Board[int.Parse(parameters[0].ToString()), int.Parse(parameters[1].ToString())].Piece;
                            affectedSquares.Add(p.Square);
                            affectedSquares.AddRange(p.GetAccessibleSquares());
                            Square moveTo = Connection.Client.Player.Game.Board[int.Parse(parameters[2].ToString()), int.Parse(parameters[3].ToString())];
                            affectedSquares.Add(moveTo);
                            if (moveTo.Piece != null)
                            {
                                Connection.Client.Player.LostPieces.Add(moveTo.Piece);
                                Connection.Client.Player.Pieces.Remove(moveTo.Piece);
                                Connection.Client.Player.Opponent.LostPieces.Add(moveTo.Piece);
                                Connection.Client.Player.Opponent.Pieces.Remove(moveTo.Piece);
                                Connection.Client.GameWindow.update();
                            }
                            p.Square.Piece = null;
                            p.Square = moveTo;
                            moveTo.Piece = p;
                            p.Moved = true;
                            if (parameters.Length >= 5 && parameters.Contains('|')) parameters = parameters.Split('|').Last();
                            else moreMoves = false;
                        }

                        Connection.Client.GameWindow.UpdateSquares(affectedSquares);
                        Piece piece = Connection.Client.Player.Game.Board[int.Parse(parameters[2].ToString()), int.Parse(parameters[3].ToString())].Piece;

                        if ((piece.Square.Y == 8 || piece.Square.Y == 1) && piece.Player == Connection.Client.Player
                            && piece.MoveBehaviours[0].ToString().Contains("Pawn"))
                        {
                            PromoDialog dialog = new PromoDialog();
                            dialog.ShowDialog();
                            string choice = "q";

                            if (dialog.Knightbutton.Checked == true)
                            {
                                choice = "k";
                            }
                            else if (dialog.Bishopbutton.Checked == true)
                            {
                                choice = "b";
                            }
                            else if (dialog.Rookbutton.Checked == true)
                            {
                                choice = "r";
                            }
                            else if (dialog.Queenbutton.Checked == true)
                            {
                                choice = "q";
                            }
                            answer = "p" + choice + piece.Square.X.ToString() + piece.Square.Y.ToString();
                        }
                        Connection.Client.Player.Game.nextTurn();
                        break;
                    }
                case 'p':
                    {
                        Piece piece = Connection.Client.Player.Game.Board[int.Parse(parameters[1].ToString()), int.Parse(parameters[2].ToString())].Piece;
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

                            Connection.Client.GameWindow.UpdateSquare(piece.Square);
                        }
                        break;
                    }
            }
            return answer;
        }
    }
}
