// *******************************************************
// Created at 27/08/2017 - Last Edit at 27/08/2017
// *******************************************************

namespace Royale_Proxy.Packets.Definitions.Types.Server
{
    class UDP_Info : Type
    {
        public UDP_Info(Reader reader, ushort id)
            : base(reader, id)
        {
        }

        public override void Decode()
        {
            this.Json.Add("UDP_Server_Port", this.Reader.ReadVInt());
            this.Json.Add("UDP_Server_Ip", this.Reader.ReadString());
            this.Json.Add("nonce", this.Reader.ReadString());
            this.Json.Add("session_Key", this.Reader.ReadString());
        }
    }
}