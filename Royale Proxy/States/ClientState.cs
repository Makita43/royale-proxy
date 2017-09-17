using Sodium;

namespace Royale_Proxy
{
    public class ClientState : State
    {
        public KeyPair ClientKey;
        public byte[] ServerKey, Nonce;
        public ServerState ServerState;
    }
}