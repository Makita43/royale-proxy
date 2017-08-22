// *******************************************************
// Created at 22/08/2017
// *******************************************************

namespace Royale_Proxy
{
    using System.Net.Sockets;

    public class State
    {
        public const int BufferSize = 2048;
        public byte[] Buffer = new byte[BufferSize];
        public byte[] Packet = new byte[0];
        public Socket Socket;
    }
}