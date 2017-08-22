// *******************************************************
// Created at 22/08/2017
// *******************************************************

namespace Royale_Proxy.Packets.Definitions.Types.Client
{
    class Session_Request : Type
    {
        public Session_Request(Reader reader, ushort id)
            : base(reader, id)
        {
        }

        public override void Decode()
        {
            this.Json.Add("protocol", this.Reader.ReadInt32());
            this.Json.Add("keyVersion", this.Reader.ReadInt32());
            this.Json.Add("majorVersion", this.Reader.ReadInt32());
            this.Json.Add("minorVersion", this.Reader.ReadInt32());
            this.Json.Add("build", this.Reader.ReadInt32());
            this.Json.Add("contentHash", this.Reader.ReadString());
            this.Json.Add("deviceType", this.Reader.ReadInt32());
            this.Json.Add("appStore", this.Reader.ReadInt32());
        }
    }
}