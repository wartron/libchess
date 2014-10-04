using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using LibChess;

namespace Client
{
    public class Connection
    {
        private TcpClient tcpClient;
        private NetworkStream networkStream;
        private StreamReader streamReader;
        private StreamWriter streamWriter;
        private Client client;
        private Thread readThread;

        public Connection(Client Client)
        {
            try
            {
                client = Client;
                ServerAddressForm addressForm = new ServerAddressForm();
                addressForm.ShowDialog();
                IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(addressForm.Address), 1337);
                tcpClient = new TcpClient();
                tcpClient.Connect(serverEndPoint);
                networkStream = tcpClient.GetStream();
                streamReader = new StreamReader(networkStream);
                streamWriter = new StreamWriter(networkStream);
                readThread = new Thread(new ThreadStart(Read));
                readThread.IsBackground = true;
                readThread.Start();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Failed to connect!");
            }
        }

        private uint IPAddressToLong(string IPAddr)
        {
            System.Net.IPAddress oIP = System.Net.IPAddress.Parse(IPAddr);
            byte[] byteIP = oIP.GetAddressBytes();


            uint ip = (uint)byteIP[3] << 24;
            ip += (uint)byteIP[2] << 16;
            ip += (uint)byteIP[1] << 8;
            ip += (uint)byteIP[0];

            return ip;
        }

        public Client Client
        {
            get { return client; }
        }

        public void SendLogin(string Username, string Password)
        {
            if(client.Player.Username == null) Send("u" + Username + "|" + Password);
        }

        public void SendLogout()
        {
            Send("-" + client.Player.Username);
        }

        public void SendRequest(string Username)
        {
            Send("r" + Username);
        }

        public void SendText(string Text)
        {
            Send("t" + Text);
        }

        public void MovePiece(Piece Piece, Square Square)
        {
            Send("m" + Piece.Square.X + Piece.Square.Y + Square.X + Square.Y);
        }

        private void Send(string Message)
        {
            try
            {
                streamWriter.WriteLine(Message);
                streamWriter.Flush();
            }
            catch (Exception Ex) { }
        }

        private void Read()
        {
            while (true)
            {
                try
                {
                    string answer = Command.Parse(streamReader.ReadLine(), this);
                    if (answer != null)
                    {
                        streamWriter.WriteLine(answer);
                        streamWriter.Flush();
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Connection lost!" + Ex.StackTrace);
                    Application.Exit();
                }
            }
        }
    }
}
