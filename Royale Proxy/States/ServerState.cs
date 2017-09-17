using Sodium;

namespace Royale_Proxy
{
    public class ServerState : State
    {
        public byte[] ClientKey, Nonce, SessionKey, SharedKey;
        public ClientState ClientState;
        public KeyPair ServerKey;
    }
}