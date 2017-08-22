// *******************************************************
// Created at 22/08/2017
// *******************************************************

namespace Royale_Proxy
{
    using Sodium;

    public class ServerState : State
    {
        public byte[] ClientKey, Nonce, SessionKey, SharedKey;
        public ClientState ClientState;
        public KeyPair ServerKey;
    }
}