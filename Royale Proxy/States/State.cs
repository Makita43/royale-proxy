using System.Net.Sockets;

namespace Royale_Proxy
{
    public class State
    {
        public const int BufferSize = 2048;
        public byte[] Buffer = new byte[BufferSize];
        public byte[] Packet = new byte[0];
        public Socket Socket;
    }
}