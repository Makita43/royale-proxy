// *******************************************************
// Created at 22/08/2017
// *******************************************************

namespace Royale_Proxy.Packets.Definitions.Types.Server
{
    using System.IO;

    class Visited_Home_Data : Type
    {
        public Visited_Home_Data(Reader reader, ushort id)
            : base(reader, id)
        {
        }

        public override void Decode()
        {
            this.Reader.ReadVInt();
            this.Reader.ReadVInt();
            this.Reader.ReadVInt();

            for (int _Index = 0; _Index < 8; _Index++)
            {
                this.Json.Add($"card_{_Index + 1}", this.Reader.ReadVInt());
                this.Json.Add($"card_{_Index + 1}_level", this.Reader.ReadVInt());
                this.Json.Add($"card_{_Index + 1}_unknown1", this.Reader.ReadVInt());
                this.Json.Add($"card_{_Index + 1}_count", this.Reader.ReadVInt());
                this.Json.Add($"card_{_Index + 1}_unknown2", this.Reader.ReadVInt());
                this.Json.Add($"card_{_Index + 1}_unknown3", this.Reader.ReadVInt());
                this.Json.Add($"card_{_Index + 1}_IsNew", this.Reader.ReadVInt());
            }
        }
    }
}