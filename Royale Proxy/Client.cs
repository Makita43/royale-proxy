// *******************************************************
// Created at 22/08/2017
// *******************************************************

namespace Royale_Proxy
{
    using System;
    using System.Net.Sockets;

    public class Client : ClientCrypto
    {
        public readonly Socket Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public ClientState State = new ClientState();

        public Client(ServerState serverstate)
        {
            this.State.ClientKey = this.clientKey;
            this.State.ServerKey = Key.OriginalPublicKey;

            try
            {
                this.State.Socket = this.Socket;

                this.Socket.Connect(Program.Hostname, Program.Port);
                this.Socket.BeginReceive(this.State.Buffer, 0, 2048, 0, ReceiveCallback, this.State);

                Console.WriteLine($"Client has been linked to {this.Socket.RemoteEndPoint}.");
            }
            catch (Exception)
            {
            }
        }
    }
}