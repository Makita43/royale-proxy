// *******************************************************
// Created at 27/08/2017 - Last Edit at 27/08/2017
// *******************************************************

namespace Royale_Proxy.Packets.Definitions.Types.Client
{
    class Login : Type
    {
        public Login(Reader reader, ushort id)
            : base(reader, id)
        {
        }

        public override void Decode()
        {
            this.Json.Add("accountId", this.Reader.ReadInt64());
            this.Json.Add("accountToken", this.Reader.ReadString());
            this.Json.Add("majorVersion", this.Reader.ReadVInt());
            this.Json.Add("minorVersion", this.Reader.ReadVInt());
            this.Json.Add("build", this.Reader.ReadVInt());
            this.Json.Add("resourceSha", this.Reader.ReadString());
            this.Json.Add("UDID", this.Reader.ReadString());
            this.Json.Add("openUDID", this.Reader.ReadString());
            this.Json.Add("macAddress", this.Reader.ReadString());
            this.Json.Add("device", this.Reader.ReadString());
            this.Json.Add("advertisingGuid", this.Reader.ReadString());
            this.Json.Add("osVersion", this.Reader.ReadString());
            this.Json.Add("isAndroid", this.Reader.ReadBoolean());
            this.Json.Add("unknown", this.Reader.ReadString());
            this.Json.Add("AndroidId", this.Reader.ReadString());
            this.Json.Add("preferredDeviceLanguage", this.Reader.ReadString());
        }
    }
}