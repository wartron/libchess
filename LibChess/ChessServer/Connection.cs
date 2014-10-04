using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using LibChess;

namespace Server
{
    class Connection
    {
        private Socket socket;
        private NetworkStream networkStream;
        private StreamReader streamReader;
        private StreamWriter streamWriter;
        private Server server;
        private Player player = new Player();
        private string lastRequest;

        public Connection(Socket Socket, Server Server)
        {
            socket = Socket;
            server = Server;
            networkStream = new NetworkStream(socket);
            streamReader = new StreamReader(networkStream);
            streamWriter = new StreamWriter(networkStream);
            Logger.LogEvent("Player connected.");
            new Thread(new ThreadStart(Read)).Start();
        }

        public Player Player
        {
            get { return player; }
            set { player = value; }
        }

        public string LastRequest
        {
            get { return lastRequest; }
        }

        public Server Server
        {
            get { return server; }
        }

        public void SendNewgame(string Username, bool White)
        {
            string lol = "";
            if (White) lol = "w";
            else lol = "b";
            Send("n" + Username + lol);
        }

        public void SendPromotion(string Parameters)
        {
            Send("p" + Parameters);
        }

        public void SendPlayerQuit(string Username)
        {
            foreach (Connection c in Server.Connections)
            {
                if (c.Player.Username != null) c.Send("-" + Username);
                else break;
            }
        }

        public void SendVictory()
        {
            Send("v");
        }

        public void SendMove(string Move)
        {
            Send("m" + Move);
        }

        public void SendRequest(string Username)
        {
            lastRequest = Username;
            Send("r" + Username);
        }

        public void SendNewPlayer(string Username)
        {
            Connection co = null;
            foreach (Connection c in Server.Connections)
            {
                if (c.Player.Username == Username) 
                {
                    throw new Exception();
                }
                if (c.Player.Username != null || co==null)
                {
                    co = c;
                }
            }
            co.Send("+" + Username);
        }

        public void SendText(string Text)
        {
            Send("t" + Text);
        }

        private void Send(string Message)
        {
            try
            {
                streamWriter.WriteLine(Message);
                streamWriter.Flush();
                Logger.LogEvent("Sent: " + Message);
            }
            catch (IOException Ex)
            {
                if (this.Player.Username != null) SendPlayerQuit(this.Player.Username);
                server.Connections.Remove(this);
            }
        }

        private void Read()
        {
            while (true)
            {
                try
                {
                    string recieved = streamReader.ReadLine();
                    Logger.LogEvent("Recieved: " + recieved);
                    string answer = Command.Parse(recieved, this);
                    if (answer != null)
                    {
                        streamWriter.WriteLine(answer);
                        streamWriter.Flush();
                        Logger.LogEvent("Sent: " + answer);
                    }
                }
                catch (Exception Ex)
                {
                    Logger.LogEvent("Lost connection to: " + socket.RemoteEndPoint);
                    Server.Connections.Remove(this);
                    break;
                }
            }
            if (this.Player.Username != null) SendPlayerQuit(this.Player.Username);
            this.Player.Username = null;
            server.Connections.Remove(this);
        }
    }
}
