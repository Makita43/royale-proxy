// *******************************************************
// Created at 27/08/2017 - Last Edit at 27/08/2017
// *******************************************************

namespace Royale_Proxy
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;
    using Sodium;

    public class Server : ServerCrypto
    {
        static readonly ManualResetEvent Wait = new ManualResetEvent(false);
        static readonly Socket Listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public Server()
        {
            try
            {
                Listener.Bind(new IPEndPoint(IPAddress.Any, Program.Port));
                Listener.SendBufferSize = 2048;
                Listener.ReceiveBufferSize = 2048;
                Listener.Listen(200);

                Console.WriteLine($"Proxy is listening on {Listener.LocalEndPoint}.");

                while (true)
                {
                    Wait.Reset();

                    Listener.BeginAccept(AcceptCallback, Listener);

                    Wait.WaitOne();
                }
            }
            catch (Exception)
            {
            }
        }

        public static void AcceptCallback(IAsyncResult Result)
        {
            try
            {
                Wait.Set();

                Socket socket = (Result.AsyncState as Socket).EndAccept(Result);

                var state = new ServerState
                {
                    Socket = socket,
                    ServerKey = PublicKeyBox.GenerateKeyPair(Key.PrivateKey)
                };

                Console.WriteLine($"Accepted new client {socket.RemoteEndPoint}.");

                var client = new Client();
                client.State.ServerState = state;
                state.ClientState = client.State;

                socket.BeginReceive(state.Buffer, 0, State.BufferSize, 0, ReceiveCallback, state);
            }
            catch (Exception)
            {
            }
        }
    }
}