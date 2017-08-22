// *******************************************************
// Created at 22/08/2017
// *******************************************************

namespace Royale_Proxy.Packets.Definitions.Types.Client
{
    class Visit_Home : Type
    {
        public Visit_Home(Reader reader, ushort id)
            : base(reader, id)
        {
        }

        public override void Decode()
        {
            this.Json.Add("accountId", this.Reader.ReadInt64());
        }
    }
}