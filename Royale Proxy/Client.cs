using System;
using System.Net.Sockets;

namespace Royale_Proxy
{
    public class Client : ClientCrypto
    {
        public readonly Socket Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public ClientState State = new ClientState();

        public Client()
        {
            State.ClientKey = clientKey;
            State.ServerKey = Key.OriginalPublicKey;

            try
            {
                State.Socket = Socket;

                Socket.Connect(Program.Hostname, Program.Port);
                Socket.BeginReceive(State.Buffer, 0, 2048, 0, ReceiveCallback, State);

                Console.WriteLine($"Client has been linked to {Socket.RemoteEndPoint}.");
            }
            catch (Exception)
            {
            }
        }
    }
}