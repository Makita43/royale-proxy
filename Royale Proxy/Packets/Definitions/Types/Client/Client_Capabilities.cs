// *******************************************************
// Created at 22/08/2017
// *******************************************************

namespace Royale_Proxy.Packets.Definitions.Types.Client
{
    class Client_Capabilities : Type
    {
        public Client_Capabilities(Reader reader, ushort id)
            : base(reader, id)
        {
        }

        public override void Decode()
        {
            this.Json.Add("ping", this.Reader.ReadVInt());
        }
    }
}