using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using LibChess;

namespace Server
{
    class Server
    {
        private TcpListener tcpListener;
        private List<Connection> connections = new List<Connection>();
        private List<Game> games = new List<Game>();

        public Server()
        {
            tcpListener = new TcpListener(/*Dns.GetHostEntry("localhost").AddressList[0],*/ 1337);
            tcpListener.Start();
            Logger.LogEvent("Server started.");

            while(true)
            {
                connections.Add(new Connection(tcpListener.AcceptSocket(), this));
            }
        }

        public List<Connection> Connections
        {
            get { return connections; }
        }

        public Player GetPlayer(string Username)
        {
            Connection connection = GetConnectionByUsername(Username);
            if (connection != null) return connection.Player;
            else return null;
        }

        public Connection GetConnectionByUsername(string Username)
        {
            foreach (Connection connection in connections)
            {
                if(connection.Player.Username.Equals(Username))
                {
                    return connection;
                }
            }
            return null;
        }

        public List<Game> Games
        {
            get { return games; }
        }

        static void Main(string[] args)
        {
            new Server();
        }
    }
}
