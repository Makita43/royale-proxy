// *******************************************************
// Created at 22/08/2017
// *******************************************************

namespace Royale_Proxy
{
    using Sodium;

    public class ClientState : State
    {
        public KeyPair ClientKey;
        public byte[] ServerKey, Nonce;
        public ServerState ServerState;
    }
}