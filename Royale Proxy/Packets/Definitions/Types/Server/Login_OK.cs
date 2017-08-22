// *******************************************************
// Created at 22/08/2017
// *******************************************************

namespace Royale_Proxy.Packets.Definitions.Types.Server
{
    class Login_OK : Type
    {
        public Login_OK(Reader reader, ushort id)
            : base(reader, id)
        {
        }

        public override void Decode()
        {
            this.Json.Add("accountId", this.Reader.ReadInt64());
            this.Json.Add("homeId", this.Reader.ReadInt64());
            this.Json.Add("token", this.Reader.ReadString());
            this.Json.Add("gameCenterId", this.Reader.ReadString());
            this.Json.Add("facebookId", this.Reader.ReadString());
            this.Json.Add("majorVersion", this.Reader.ReadVInt());
            this.Json.Add("build", this.Reader.ReadVInt());
            this.Json.Add("build2", this.Reader.ReadVInt());
            this.Json.Add("contentVersion", this.Reader.ReadVInt());
            this.Json.Add("environment", this.Reader.ReadString());
            this.Json.Add("sessionCount", this.Reader.ReadVInt());
            this.Json.Add("playTimeSeconds", this.Reader.ReadVInt());
            this.Json.Add("daysSinceStartedPlaying", this.Reader.ReadVInt());
            this.Json.Add("facebookAppId", this.Reader.ReadString());
            this.Json.Add("serverTime", this.Reader.ReadString());
            this.Json.Add("accountCreatedDate", this.Reader.ReadString());
            this.Json.Add("unknown", this.Reader.ReadVInt());
            this.Json.Add("googleServiceId", this.Reader.ReadString());
            this.Json.Add("unknown2", this.Reader.ReadString());
            this.Json.Add("unknown3", this.Reader.ReadString());
            this.Json.Add("region", this.Reader.ReadString());
            this.Json.Add("city", this.Reader.ReadString());
            this.Json.Add("eventAssetURL", this.Reader.ReadString());
            this.Json.Add("unknown4", this.Reader.ReadByte());
        }
    }
}